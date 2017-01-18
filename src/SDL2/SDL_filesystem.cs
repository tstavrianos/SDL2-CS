#region License
/* SDL2# - C# Wrapper for SDL2
 *
 * Copyright (c) 2013-2016 Ethan Lee.
 *
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from
 * the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 * claim that you wrote the original software. If you use this software in a
 * product, an acknowledgment in the product documentation would be
 * appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not be
 * misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source distribution.
 *
 * Ethan "flibitijibibo" Lee <flibitijibibo@flibitijibibo.com>
 *
 */
#endregion

using System;
using System.Runtime.InteropServices;

namespace TS.SDL2
{
    public static partial class SDL
    {
        #region SDL_filesystem.h

        /// <summary>
        /// Get the path where the application resides.
        ///
        /// Get the "base path". This is the directory where the application was run
        /// from, which is probably the installation directory, and may or may not
        /// be the process's current working directory.
        ///
        /// This returns an absolute path in UTF-8 encoding, and is garunteed to
        /// end with a path separator ('\\' on Windows, '/' most other places).
        /// </summary>
        /// <returns>string of base dir in UTF-8 encoding</returns>
        /// <remarks>The underlying C string is owned by the application,
        /// and can be NULL on some platforms.
        ///
        /// This function is not necessarily fast, so you should only
        /// call it once and save the string if you need it.
        ///
        /// This function is only available in SDL 2.0.1 and later.</remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
        public static extern string SDL_GetBasePath();

        /// <summary>
        /// Get the user-and-app-specific path where files can be written.
        ///
        /// Get the "pref dir". This is meant to be where users can write personal
        /// files (preferences and save games, etc) that are specific to your
        /// application. This directory is unique per user, per application.
        ///
        /// This function will decide the appropriate location in the native filesystem¸
        /// create the directory if necessary, and return a string of the absolute
        /// path to the directory in UTF-8 encoding.
        /// </summary>
        /// <param name="org">The name of your organization.</param>
        /// <param name="app">The name of your application.</param>
        /// <returns>UTF-8 string of user dir in platform-dependent notation. NULL
        /// if there's a problem (creating directory failed, etc).</returns>
        /// <remarks>The underlying C string is owned by the application,
        /// and can be NULL on some platforms. .NET provides some similar functions.
        ///
        /// This function is not necessarily fast, so you should only
        /// call it once and save the string if you need it.
        ///
        /// This function is only available in SDL 2.0.1 and later.</remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
        public static extern string SDL_GetPrefPath(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
            string org,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
            string app
        );

        #endregion
    }
}
