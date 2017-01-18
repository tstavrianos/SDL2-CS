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
        #region SDL_stdinc.h

        public static uint SDL_FOURCC(byte A, byte B, byte C, byte D)
        {
            return (uint) (A | (B << 8) | (C << 16) | (D << 24));
        }

        public enum SDL_bool
        {
            SDL_FALSE = 0,
            SDL_TRUE = 1
        }

        /* malloc/free are used by the marshaler! -flibit */

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr SDL_malloc(IntPtr size);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SDL_free(IntPtr memblock);

        #endregion
    }
}
