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
        #region SDL_revision.h

        /// <summary>
        /// Use this function to get the code revision of SDL that is linked against your program.
        /// </summary>
        /// <returns>Returns an arbitrary string, uniquely identifying the exact revision
        /// of the SDL library in use. </returns>
        /// <remarks>The revision is a string including sequential revision number that is
        /// incremented with each commit, and a hash of the last code change.</remarks>
        /// <remarks>Example: hg-5344:94189aa89b54</remarks>
        /// <remarks>This value is the revision of the code you are linked with and may be
        /// different from the code you are compiling with, which is found in the constant SDL_REVISION.</remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDL_GetRevision();

        /// <summary>
        /// Use this function to get the revision number of SDL that is linked against your program.
        /// </summary>
        /// <returns>Returns a number uniquely identifying the exact revision of the SDL library in use.</returns>
        /// <remarks>This is an incrementing number based on commits to hg.libsdl.org.</remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRevisionNumber();

        #endregion
    }
}
