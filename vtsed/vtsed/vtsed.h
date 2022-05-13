/*
    VTSED

    This project is under MIT license (https://mit-license.org)
    and is available on GitHub (https://github.com/realluke/VTSED)

    AUTHOR:     Realluke (https://github.com/realluke/)
    VERSION:    1.0.0
*/

#pragma once
#include <Windows.h>


#pragma unmanaged

#ifdef STD

// Code for C/C++.

#ifdef EXCLIX_EXPORTS
#define EXCLIX_API __declspec(dllexport)
#else
#define EXCLIX_API __declspec(dllimport)
#endif

namespace VTSEDCpp
{
	extern "C" int __declspec(dllexport) __stdcall EnableVTS();
	extern "C" int __declspec(dllexport) __stdcall DisableVTS();
}

#else

// Code for C.

namespace VTSEDCpp
{
	int __stdcall EnableVTS();
	int __stdcall DisableVTS();
}

#endif
