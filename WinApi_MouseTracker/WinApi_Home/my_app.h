#pragma once
#include <windows.h>
#include <string>
# define WIN32_LEAN_AND_MEAN
class my_app
{
private:
	bool register_class();
	static std::wstring const s_class_name;
	static LRESULT CALLBACK window_proc_static(
		HWND window,
		UINT message,
		WPARAM wparam,
		LPARAM lparam);
	LRESULT window_proc(
		HWND window,
		UINT message,
		WPARAM wparam,
		LPARAM lparam);
	HWND create_window(DWORD style = NULL);
	HINSTANCE m_instance;
	HWND m_main;
public:
	my_app(HINSTANCE hinstance);
	int run(int show_command);
	void pulse(HWND window);
	int minSize;
	int maxSize;
	int stepSize;
	int probka;
	int currentSize;
	bool ifPulse;
	bool menu;
	int colorR;
	int colorG;
	int colorB;
	UINT trayMess;
	UINT openConfig;
	UINT reloadConfig;
	UINT pickColor;
	UINT exit;
	HMENU hMenu;
	NOTIFYICONDATA icon_tray;
	HICON hIcon;
	void Transparent();
	static LRESULT CALLBACK GetKey(int keyID, WPARAM wparam, LPARAM lparam);
};
	

class Queue
{
public:
	void MakeCoordTable();
	void AddKey(std::wstring key);
	std::wstring tab[10];
	time_t addedTime[10];
	int coordTable[10];
	int counter;
	void DeleteKey();
	Queue()
	{
		counter = 0;
		MakeCoordTable();
	}
};
