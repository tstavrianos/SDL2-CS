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
        #region SDL_error.h

        /// <summary>
        /// Use this function to clear any previous error message.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ClearError();

        /// <summary>
        /// Use this function to retrieve a message about the last error that occurred.
        /// </summary>
        /// <returns>Returns a message with information about the specific error that occurred,
        /// or an empty string if there hasn't been an error since the last call to <see cref="SDL_ClearError()"/>.
        /// Without calling <see cref="SDL_ClearError()"/>, the message is only applicable when an SDL function
        /// has signaled an error. You must check the return values of SDL function calls to determine
        /// when to appropriately call <see cref="SDL_GetError()"/>.
        /// This string is statically allocated and must not be freed by the application.</returns>
        /// <remarks>It is possible for multiple errors to occur before calling SDL_GetError(). Only the last error is returned. </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDL_GetError();

        /// <summary>
        /// Use this function to set the SDL error string.
        /// </summary>
        /// <param name="fmt">a printf() style message format string </param>
        /// <param name="...">additional parameters matching % tokens in the fmt string, if any</param>
        /// <remarks>Calling this function will replace any previous error message that was set.</remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetError(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string fmt,
            __arglist
        );

        #endregion
    }
}
