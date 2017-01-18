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
    /// <summary>
    /// Entry point for all SDL-related (non-extension) types and methods
    /// </summary>
    public static partial class SDL
    {
        #region SDL_rwops.h

        /* Note about SDL2# and Internal RWops:
         * These functions are currently not supported for public use.
         * They are only meant to be used internally in functions marked with
         * the phrase "THIS IS AN RWops FUNCTION!"
         */

        /// <summary>
        /// Use this function to create a new SDL_RWops structure for reading from and/or writing to a named file.
        /// </summary>
        /// <param name="file">a UTF-8 string representing the filename to open</param>
        /// <param name="mode">an ASCII string representing the mode to be used for opening the file; see Remarks for details</param>
        /// <returns>Returns a pointer to the SDL_RWops structure that is created, or NULL on failure; call SDL_GetError() for more information.</returns>
        [DllImport(nativeLibName, EntryPoint = "SDL_RWFromFile", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr INTERNAL_SDL_RWFromFile(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string file,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string mode
        );

        /* These are the public RWops functions. They should be used by
         * functions marked with the phrase "THIS IS A PUBLIC RWops FUNCTION!"
         */

        /* IntPtr refers to an SDL_RWops */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RWFromMem(byte[] mem, int size);

        #endregion
    }
}
