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
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace TS.SDL2
{
    public static partial class SDL
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string dllToLoad);

        static SDL()
        {
            var myPath = new Uri(Assembly.GetEntryAssembly().CodeBase).LocalPath;
            var myFolder = Path.GetDirectoryName(myPath);

            var is64 = IntPtr.Size == 8;
            var subfolder = is64 ? "\\x64\\" : "\\x86\\";

            LoadLibrary(myFolder + subfolder + nativeLibName);
        }

        #region SDL2# Variables

        /// <summary>
        /// Used by DllImport to load the native library.
        /// </summary>
        private const string nativeLibName = "SDL2.dll";

        #endregion

        #region SDL.h

        public const uint SDL_INIT_TIMER =        0x00000001;
        public const uint SDL_INIT_AUDIO =        0x00000010;
        public const uint SDL_INIT_VIDEO =        0x00000020;
        public const uint SDL_INIT_JOYSTICK =        0x00000200;
        public const uint SDL_INIT_HAPTIC =        0x00001000;
        public const uint SDL_INIT_GAMECONTROLLER =    0x00002000;
        public const uint SDL_INIT_NOPARACHUTE =    0x00100000;
        public const uint SDL_INIT_EVERYTHING = (
            SDL_INIT_TIMER | SDL_INIT_AUDIO | SDL_INIT_VIDEO |
            SDL_INIT_JOYSTICK | SDL_INIT_HAPTIC |
            SDL_INIT_GAMECONTROLLER
        );

        /// <summary>
        /// Use this function to initialize the SDL library.
        /// This must be called before using any other SDL function.
        /// </summary>
        /// <param name="flags">subsystem initialization flags; see Remarks for details</param>
        /// <returns>Returns 0 on success or a negative error code on failure.
        /// Call <see cref="SDL_GetError()"/> for more information.</returns>
        /// <remarks>The Event Handling, File I/O, and Threading subsystems are initialized by default.
        /// You must specifically initialize other subsystems if you use them in your application.</remarks>
        /// <remarks>Unless the SDL_INIT_NOPARACHUTE flag is set, it will install cleanup signal handlers
        /// for some commonly ignored fatal signals (like SIGSEGV). </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_Init(uint flags);

        /// <summary>
        /// Use this function to initialize specific SDL subsystems.
        /// </summary>
        /// <param name="flags">any of the flags used by SDL_Init(); see Remarks for details</param>
        /// <returns>Returns 0 on success or a negative error code on failure.
        /// Call <see cref="SDL_GetError()"/> for more information.</returns>
        /// <remarks>After SDL has been initialized with <see cref="SDL_Init()"/> you may initialize
        /// uninitialized subsystems with <see cref="SDL_InitSubSystem()"/>.</remarks>
        /// <remarks>If you want to initialize subsystems separately you would call <see cref="SDL_Init(0)"/>
        /// followed by <see cref="SDL_InitSubSystem()"/> with the desired subsystem flag. </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_InitSubSystem(uint flags);

        /// <summary>
        /// Use this function to clean up all initialized subsystems.
        /// You should call it upon all exit conditions.
        /// </summary>
        /// <remarks>You should call this function even if you have already shutdown each initialized
        /// subsystem with <see cref="SDL_QuitSubSystem()"/>.</remarks>
        /// <remarks>If you start a subsystem using a call to that subsystem's init function (for example
        /// <see cref="SDL_VideoInit()"/>) instead of <see cref="SDL_Init()"/> or <see cref="SDL_InitSubSystem()"/>,
        /// then you must use that subsystem's quit function (<see cref="SDL_VideoQuit()"/>) to shut it down
        /// before calling <see cref="SDL_Quit()"/>.</remarks>
        /// <remarks>You can use this function with atexit() to ensure that it is run when your application is
        /// shutdown, but it is not wise to do this from a library or other dynamically loaded code. </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Quit();

        /// <summary>
        /// Use this function to shut down specific SDL subsystems.
        /// </summary>
        /// <param name="flags">any of the flags used by <see cref="SDL_Init()"/>; see Remarks for details</param>
        /// <remarks>If you start a subsystem using a call to that subsystem's init function (for example
        /// <see cref="SDL_VideoInit()"/>) instead of <see cref="SDL_Init()"/> or <see cref="SDL_InitSubSystem()"/>,
        /// then you must use that subsystem's quit function (<see cref="SDL_VideoQuit()"/>) to shut it down
        /// before calling <see cref="SDL_Quit()"/>.</remarks>
        /// <remarks>You can use this function with atexit() to en
        /// <remarks>You still need to call <see cref="SDL_Quit()"/> even if you close all open subsystems with SDL_QuitSubSystem(). </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_QuitSubSystem(uint flags);

        /// <summary>
        /// Use this function to return a mask of the specified subsystems which have previously been initialized.
        /// </summary>
        /// <param name="flags">any of the flags used by <see cref="SDL_Init()"/>; see Remarks for details</param>
        /// <returns>If flags is 0 it returns a mask of all initialized subsystems, otherwise it returns the
        /// initialization status of the specified subsystems. The return value does not include SDL_INIT_NOPARACHUTE.</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WasInit(uint flags);

        #endregion
    }
}
