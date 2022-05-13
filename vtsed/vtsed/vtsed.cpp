/*
    VTSED

    This project is under MIT license (https://mit-license.org)
    and is available on GitHub (https://github.com/realluke/VTSED)

    AUTHOR:     Realluke (https://github.com/realluke/)
    VERSION:    1.0.0
*/

#include "pch.h"
#include "vtsed.h"


// Code for C/C++.
#pragma unmanaged

namespace VTSEDCpp
{
    // This code is based on (https://docs.microsoft.com/en-us/windows/console/console-virtual-terminal-sequences).

    
    // Enable VTS.
    // Return '0' if it worked otherwise '-1'.
    int __stdcall EnableVTS()
    {
        // Get Std output.
        HANDLE hOut = GetStdHandle(STD_OUTPUT_HANDLE);
        if (hOut == INVALID_HANDLE_VALUE)
        {
            return -1;
        }

        // Get console mode.
        DWORD dwMode = 0;
        if (!GetConsoleMode(hOut, &dwMode))
        {
            return -1;
        }

        // Set console mode.
        dwMode |= 0x0004 | 0x0008;
        if (!SetConsoleMode(hOut, dwMode))
        {
            return -1;
        }

        return 0;
    }


    // Disable VTS.
    // Return '0' if it worked otherwise '-1'.
    int __stdcall DisableVTS()
    {
        // Get Std output.
        HANDLE hOut = GetStdHandle(STD_OUTPUT_HANDLE);
        if (hOut == INVALID_HANDLE_VALUE)
        {
            return -1;
        }

        // Get console mode.
        DWORD dwMode = 0;
        if (!GetConsoleMode(hOut, &dwMode))
        {
            return -1;
        }

        // Set console mode.
        dwMode &= ~0x0004 & ~0x0008;
        if (!SetConsoleMode(hOut, dwMode))
        {
            return -1;
        }

        return 0;
    }
}


// Code for .NET
#pragma managed

#ifndef STD

namespace VTSEDNet
{
    /// <summary>
    /// Methods for using VTS.
    /// </summary>
    public ref class VTS
    {

    public:

        /// <summary>
        /// Enable VTS.
        /// </summary>
        /// <returns>Return '0' if it worked otherwise '-1'.</returns>
        static int EnableVTS()
        {
            return VTSEDCpp::EnableVTS();
        }


        /// <summary>
        /// Disable VTS-
        /// </summary>
        /// <returns>Return '0' if it worked otherwise '-1'.</returns>
        static int DisableVTS()
        {
            return VTSEDCpp::DisableVTS();
        }

    };
}

#endif
