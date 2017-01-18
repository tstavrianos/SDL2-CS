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
        #region SDL_version.h

        /* Similar to the headers, this is the version we're expecting to be
         * running with. You will likely want to check this somewhere in your
         * program!
         */
        public const int SDL_MAJOR_VERSION =    2;
        public const int SDL_MINOR_VERSION =    0;
        public const int SDL_PATCHLEVEL =    4;

        public static readonly int SDL_COMPILEDVERSION = SDL_VERSIONNUM(
            SDL_MAJOR_VERSION,
            SDL_MINOR_VERSION,
            SDL_PATCHLEVEL
        );

        /// <summary>
        /// A structure that contains information about the version of SDL in use.
        /// </summary>
        /// <remarks>Represents the library's version as three levels: </remarks>
        /// <remarks>major revision (increments with massive changes, additions, and enhancements) </remarks>
        /// <remarks>minor revision (increments with backwards-compatible changes to the major revision), and </remarks>
        /// <remarks>patchlevel (increments with fixes to the minor revision)</remarks>
        /// <remarks><see cref="SDL_VERSION"/> can be used to populate this structure with information</remarks>
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_version
        {
            public byte major;
            public byte minor;
            public byte patch;
        }

        /// <summary>
        /// Use this macro to determine the SDL version your program was compiled against.
        /// </summary>
        /// <param name="x">an <see cref="SDL_version"/> structure to initialize</param>
        public static void SDL_VERSION(out SDL_version x)
        {
            x.major = SDL_MAJOR_VERSION;
            x.minor = SDL_MINOR_VERSION;
            x.patch = SDL_PATCHLEVEL;
        }

        /// <summary>
        /// Use this macro to convert separate version components into a single numeric value.
        /// </summary>
        /// <param name="X">major version; reported in thousands place</param>
        /// <param name="Y">minor version; reported in hundreds place</param>
        /// <param name="Z">update version (patchlevel); reported in tens and ones places</param>
        /// <returns></returns>
        /// <remarks>This assumes that there will never be more than 100 patchlevels.</remarks>
        /// <remarks>Example: SDL_VERSIONNUM(1,2,3) -> (1203)</remarks>
        public static int SDL_VERSIONNUM(int X, int Y, int Z)
        {
            return (X * 1000) + (Y * 100) + Z;
        }

        /// <summary>
        /// Use this macro to determine whether the SDL version compiled against is at least as new as the specified version.
        /// </summary>
        /// <param name="X">major version</param>
        /// <param name="Y">minor version</param>
        /// <param name="Z">update version (patchlevel)</param>
        /// <returns>This macro will evaluate to true if compiled with SDL version at least X.Y.Z. </returns>
        public static bool SDL_VERSION_ATLEAST(int X, int Y, int Z)
        {
            return (SDL_COMPILEDVERSION >= SDL_VERSIONNUM(X, Y, Z));
        }

        /// <summary>
        /// Use this function to get the version of SDL that is linked against your program.
        /// </summary>
        /// <param name="ver">the <see cref="SDL_version"/> structure that contains the version information</param>
        /// <remarks>This function may be called safely at any time, even before SDL_Init(). </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetVersion(out SDL_version ver);

        #endregion
    }
}
