#include "my_app.h"
#include <stdexcept>
#include <string>
std::wstring const my_app::s_class_name{ L"My_App Window" };
Queue queue;


bool my_app::register_class()
{
	WNDCLASSEXW desc{};
	if (GetClassInfoExW(m_instance, s_class_name.c_str(),
		&desc) != 0)
		return true;
	desc = {
	.cbSize = sizeof(WNDCLASSEXW),
	.lpfnWndProc = window_proc_static,
	.hInstance = m_instance,
	.hCursor = LoadCursorW(nullptr, L"IDC_ARROW"),
	.lpszClassName = s_class_name.c_str()
	};
	return RegisterClassExW(&desc) != 0;
}

HWND my_app::create_window(DWORD main_style)
{
	m_main = CreateWindowExW(
		WS_EX_TOOLWINDOW | WS_EX_LAYERED | WS_EX_TOPMOST | WS_EX_NOACTIVATE | WS_EX_TRANSPARENT,
		s_class_name.c_str(),
		L"",
		main_style, 
		CW_USEDEFAULT, 
		0,
		GetSystemMetrics(SM_CXSCREEN),
		GetSystemMetrics(SM_CYSCREEN),
		nullptr,
		nullptr,
		m_instance,
		this);
	return m_main;
}

LRESULT my_app::window_proc_static(
	HWND window,
	UINT message,
	WPARAM wparam,
	LPARAM lparam)
{
	my_app* App = nullptr;
	if (message == WM_NCCREATE)
	{
		App = static_cast<my_app*>(
			reinterpret_cast<LPCREATESTRUCTW>(lparam)->lpCreateParams);
		SetWindowLongPtrW(window, GWLP_USERDATA,
			reinterpret_cast<LONG_PTR>(App));
	}
	else
		App = reinterpret_cast<my_app*>(
			GetWindowLongPtrW(window, GWLP_USERDATA));
	LRESULT res = App ?
		App->window_proc(window, message, wparam, lparam) :
		DefWindowProcW(window, message, wparam, lparam);
	if (message == WM_NCDESTROY)
		SetWindowLongPtrW(window, GWLP_USERDATA, 0);
	return res;
}


LRESULT my_app::window_proc(
	HWND window,
	UINT message,
	WPARAM wparam,
	LPARAM lparam)
{
	switch (message)
	{
	case WM_CREATE:
		if (!RegisterHotKey(window, 1, MOD_ALT | MOD_SHIFT, 0x43) ||
			!RegisterHotKey(window, 2, MOD_ALT | MOD_SHIFT, VK_F4) ||
			!RegisterHotKey(window, 3, MOD_CONTROL, VK_F12))
		{
			DWORD errorCode = GetLastError();
			LPWSTR errorMsgBuffer;
			FormatMessage(
				FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM,
				NULL,
				errorCode,
				0,
				(LPWSTR)&errorMsgBuffer,
				0,
				NULL
			);
			wchar_t errorMessage[256];
			swprintf_s(errorMessage, L"Failed with error %d:\n%s", errorCode, errorMsgBuffer);

			MessageBoxW(m_main, errorMessage, L"Error", MB_OK | MB_DEFAULT_DESKTOP_ONLY);
			DestroyWindow(m_main);
			PostQuitMessage(0);
		}
		trayMess = RegisterWindowMessage(L"TrayMess");
		openConfig = RegisterWindowMessage(L"OpenConfig");
		reloadConfig = RegisterWindowMessage(L"ReloadConfig");
		pickColor = RegisterWindowMessage(L"PickColor");
		exit = RegisterWindowMessage(L"exit");
		icon_tray.cbSize = sizeof(NOTIFYICONDATA);
		icon_tray.hWnd = window;
		icon_tray.uID = 1;
		icon_tray.uFlags = NIF_ICON | NIF_MESSAGE | NIF_TIP;
		icon_tray.uCallbackMessage = trayMess;
		icon_tray.hIcon = hIcon;
		lstrcpy(icon_tray.szTip, TEXT("my_app"));

		Shell_NotifyIcon(NIM_ADD, &icon_tray);

		hMenu = CreatePopupMenu();
		AppendMenu(hMenu, MF_STRING, openConfig, TEXT("Open config file"));
		AppendMenu(hMenu, MF_STRING, reloadConfig, TEXT("Reload config"));
		AppendMenu(hMenu, MF_STRING, pickColor, TEXT("Pick color..."));
		AppendMenu(hMenu, MF_STRING, exit, TEXT("Exit"));
		break;


	case WM_COMMAND:
	{
		if (wparam == openConfig)
		{
			ShellExecute(NULL, L"open", L"..\\x64\\Debug\\config.ini", nullptr, nullptr, SW_SHOWNORMAL);
		}
		else if (wparam == reloadConfig)
		{
			colorB = GetPrivateProfileInt(L"my_app", L"colorBlue", 0, L"..\\x64\\Debug\\config.ini");
			colorG = GetPrivateProfileInt(L"my_app", L"colorGreen", 0, L"..\\x64\\Debug\\config.ini");
			colorR = GetPrivateProfileInt(L"my_app", L"colorRed", 0, L"..\\x64\\Debug\\config.ini");
		}
		else if (wparam == exit)
		{
			Shell_NotifyIcon(NIM_DELETE, &icon_tray);
			DestroyWindow(m_main);
		}
		else if (wparam == pickColor)
		{
			CHOOSECOLOR color;
			COLORREF color_ref[16];
			ZeroMemory(&color, sizeof(color));
			color.lStructSize = sizeof(color);
			color.hwndOwner = m_main;
			color.rgbResult = RGB(colorR, colorG, colorB); 
			color.Flags = CC_FULLOPEN | CC_RGBINIT;
			color.lpCustColors = (LPDWORD)color_ref;
			if (ChooseColor(&color)) {
				
				colorR = GetRValue(color.rgbResult);
				colorG = GetGValue(color.rgbResult);
				colorB = GetBValue(color.rgbResult);
			}
		}
		break;
	}
	case WM_CLOSE:
		DestroyWindow(m_main);
		Shell_NotifyIcon(NIM_DELETE, &icon_tray);
		return 0;
	case WM_DESTROY:
		wchar_t colorRed[256];
		swprintf_s(colorRed, 256, L"%d", colorR);
		wchar_t colorGreen[256];
		swprintf_s(colorGreen, 256, L"%d", colorG);
		wchar_t colorBlue[256];
		swprintf_s(colorBlue, 256, L"%d", colorB);
		WritePrivateProfileString(L"my_app", L"colorRed", colorRed, L"..\\x64\\Debug\\config.ini");
		WritePrivateProfileString(L"my_app", L"colorGreen", colorGreen, L"..\\x64\\Debug\\config.ini");
		WritePrivateProfileString(L"my_app", L"colorBlue", colorBlue, L"..\\x64\\Debug\\config.ini");
		Shell_NotifyIcon(NIM_DELETE, &icon_tray);
		DestroyIcon(hIcon);
		if (window == m_main)
			PostQuitMessage(EXIT_SUCCESS);
		return 0;
	case WM_TIMER:
	{
		if (wparam == 1)
		{
			Transparent();
		}
		if (wparam == 2)
			pulse(window);
		break;
	}
	case WM_HOTKEY:
	{
		if (wparam == 1)
			if (ifPulse == true)
			{
				currentSize = maxSize;
				currentSize = maxSize;
				Transparent();
				KillTimer(m_main, 2);
				ifPulse = false;
			}
			else
			{
				SetTimer(m_main, 2, probka, nullptr);
				ifPulse = true;
			}
		if (wparam == 2)
		{
			DestroyWindow(m_main);
		}
		if (wparam == 3)
		{
			if (menu == false)
			{
				menu = true;
				Transparent();
			}
			else
			{
				menu = false;
				Transparent();
			}
		}
	}
	}
	if (message == trayMess)
	{
		if (LOWORD(lparam) == WM_RBUTTONDOWN || LOWORD(lparam) == WM_CONTEXTMENU)
		{
			POINT pt;
			GetCursorPos(&pt);
			TrackPopupMenu(hMenu, TPM_RIGHTALIGN | TPM_BOTTOMALIGN, pt.x, pt.y, 0, m_main, NULL);
		}
		return 0;
	}
	return DefWindowProcW(window, message, wparam, lparam);
}

#include<filesystem>
my_app::my_app(HINSTANCE instance)
	: m_instance{ instance }, m_main{}
{
	minSize = 50;
	maxSize = 100;
	stepSize = -1;
	probka = 10;
	currentSize = 100;
	ifPulse = true;
	menu = true;
	register_class(); 
	DWORD main_style = WS_POPUP;
	std::string a = std::filesystem::current_path().string();
	colorB = GetPrivateProfileInt(L"my_app", L"colorBlue",0,  L"..\\x64\\Debug\\config.ini");
	colorG = GetPrivateProfileInt(L"my_app", L"colorGreen", 0, L"..\\x64\\Debug\\config.ini");
	colorR = GetPrivateProfileInt(L"my_app", L"colorRed", 0, L"..\\x64\\Debug\\config.ini");
	hIcon = (HICON)LoadImage(NULL, L".\\icon.ico", IMAGE_ICON, 0, 0, LR_LOADFROMFILE);
	HHOOK hook = SetWindowsHookEx(WH_KEYBOARD_LL, this->GetKey, NULL, 0);
	m_main = create_window(main_style); 
}


int my_app::run(int show_command)
{
	ShowWindow(m_main, show_command);
	MSG msg{};
	BOOL result = TRUE;
	SetTimer(m_main, 1, 50, nullptr);
	SetTimer(m_main, 2, probka, nullptr);
	while ((result = GetMessageW(&msg, nullptr, 0, 0)) != 0)
	{
		if (result == -1)
			return EXIT_FAILURE;
		TranslateMessage(&msg);
		DispatchMessageW(&msg);
	}
	return EXIT_SUCCESS;
}

void my_app::Transparent()
{
	HDC paintScreen = GetDC(m_main);
	HDC paintMap = CreateCompatibleDC(paintScreen);
	POINT p;
	HBITMAP bitMap = CreateCompatibleBitmap(paintScreen, GetSystemMetrics(SM_CXSCREEN), GetSystemMetrics(SM_CYSCREEN));
	HBITMAP oldBitMap = (HBITMAP)SelectObject(paintMap, bitMap);
	BLENDFUNCTION blend = { 0 };
	blend.SourceConstantAlpha = 50;
	blend.AlphaFormat = 0;
	POINT pos = { 0, 0 };
	POINT ptSrc = { 0, 0 };
	GetCursorPos(&p);
	HBRUSH brush = CreateSolidBrush(RGB(colorR, colorG, colorB));
	HBRUSH prevBrush = (HBRUSH)SelectObject(paintMap, brush);
	SIZE size = { GetSystemMetrics(SM_CXSCREEN), GetSystemMetrics(SM_CYSCREEN) };
	Ellipse(paintMap, p.x - currentSize / 2, p.y - currentSize / 2,
		p.x + currentSize / 2, p.y + currentSize / 2);
	if (menu == true)
	{
		SetTextColor(paintMap, RGB(0, 0, 255));
		SetBkColor(paintMap, RGB(255, 255, 255));
		TCHAR s[] = TEXT(" Instrukcja:");
		TextOut(paintMap, 55, 55, s, (int)wcslen(s));
		TCHAR s1[] = TEXT("1. W³¹czenie/Wy³¹czenie instrukcji Ctrl+F12");
		SetBkColor(paintMap, RGB(255, 255, 255));
		TextOut(paintMap, 55, 85, s1, (int)wcslen(s1));
		TCHAR s2[] = TEXT("2. W³¹czenie/Wy³¹czenie pulsowania Alt+Shift+C");
		TextOut(paintMap, 55, 105, s2, (int)wcslen(s2));
		TCHAR s3[] = TEXT("3. Wy³¹czenie aplikacji Alt+Ahift+F4");
		TextOut(paintMap, 55, 125, s3, (int)wcslen(s3));
	}
	SetTextColor(paintMap, RGB(colorR, colorG, colorB));
	for (int i = 0; i < queue.counter; i++)
	{
		SetBkColor(paintMap, RGB(0,0,0));
		TextOut(paintMap, 10, queue.coordTable[i]-35, queue.tab[i].c_str(), queue.tab[i].size());
	}
	queue.DeleteKey();
	UpdateLayeredWindow(m_main, paintScreen, &pos, &size, paintMap, &ptSrc, NULL, &blend, ULW_ALPHA | ULW_COLORKEY);
	ReleaseDC(m_main, paintScreen);
	SelectObject(paintMap, oldBitMap);
	SelectObject(paintMap, prevBrush);
	DeleteObject(bitMap);
	DeleteObject(brush);
	DeleteObject(prevBrush);
	DeleteDC(paintMap);
}


void my_app::pulse(HWND window)
{
	currentSize += stepSize;
	if (currentSize >= maxSize) 
	{
		stepSize = -abs(stepSize);
	}
	else if (currentSize <= minSize) 
	{
		 stepSize = abs(stepSize);
	}
	Transparent();
}

LRESULT CALLBACK my_app::GetKey(int keyID, WPARAM wparam, LPARAM lparam)
{
	if (keyID == HC_ACTION)
	{
		KBDLLHOOKSTRUCT* presseKeyInfo = (KBDLLHOOKSTRUCT*)lparam;
		if (wparam == WM_KEYDOWN)
		{
			std::wstring myKey = L"";
			LPKBDLLHOOKSTRUCT lparamStruct = (LPKBDLLHOOKSTRUCT)lparam;
			PKBDLLHOOKSTRUCT coded = (PKBDLLHOOKSTRUCT)lparam;
			myKey += MapVirtualKey(coded->vkCode, MAPVK_VK_TO_CHAR);;
			queue.AddKey(myKey);
		}
	}
	return CallNextHookEx(NULL, keyID, wparam, lparam);
}

void Queue::AddKey(std::wstring key)
{
	if (counter == 0)
	{
		tab[0] = key;
		addedTime[0] = std::time(NULL);
		counter++;
		return;
	}
	if (counter < 10)
	{
		for (int i = counter; i > 0; i--)
		{
			tab[i] = tab[i - 1];
			addedTime[i] = addedTime[i - 1];
		}
		tab[0] = key;
		addedTime[0] = std::time(NULL);
		counter++;
		return;
	}
	for (int i = 9;i>0; i--)
	{
		tab[i] = tab[i - 1];
		addedTime[i] = addedTime[i - 1];
	}
	tab[0] = key;
	addedTime[0] = std::time(NULL);
	return;
}

void Queue::MakeCoordTable()
{
	int y = GetSystemMetrics(SM_CYSCREEN)-30;
	for (int i = 0; i < 10;i++)
	{
		coordTable[i] = y;
		y -= 20;
	}
}

void Queue::DeleteKey()
{
	if (counter > 0)
	{
		double diff = std::difftime(std::time(NULL), addedTime[counter-1]);
		if (diff >= 5.0)
		{
			counter--;
		}
	}
}
