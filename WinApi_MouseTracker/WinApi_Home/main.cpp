#pragma once
#define NOMINMAX
#include <windows.h>
#include "my_app.h"



int WINAPI wWinMain(HINSTANCE instance,
	HINSTANCE,
	LPWSTR ,
	int show_command)
{
	my_app App{ instance };
	return App.run(show_command);
}