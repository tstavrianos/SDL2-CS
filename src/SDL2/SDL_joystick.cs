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
        #region SDL_joystick.h

        public const byte SDL_HAT_CENTERED =    0x00;
        public const byte SDL_HAT_UP =        0x01;
        public const byte SDL_HAT_RIGHT =    0x02;
        public const byte SDL_HAT_DOWN =    0x04;
        public const byte SDL_HAT_LEFT =    0x08;
        public const byte SDL_HAT_RIGHTUP =    SDL_HAT_RIGHT | SDL_HAT_UP;
        public const byte SDL_HAT_RIGHTDOWN =    SDL_HAT_RIGHT | SDL_HAT_DOWN;
        public const byte SDL_HAT_LEFTUP =    SDL_HAT_LEFT | SDL_HAT_UP;
        public const byte SDL_HAT_LEFTDOWN =    SDL_HAT_LEFT | SDL_HAT_DOWN;

        public enum SDL_JoystickPowerLevel
        {
            SDL_JOYSTICK_POWER_UNKNOWN = -1,
            SDL_JOYSTICK_POWER_EMPTY,
            SDL_JOYSTICK_POWER_LOW,
            SDL_JOYSTICK_POWER_MEDIUM,
            SDL_JOYSTICK_POWER_FULL,
            SDL_JOYSTICK_POWER_WIRED,
            SDL_JOYSTICK_POWER_MAX
        }

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickClose(IntPtr joystick);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickEventState(int state);

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern short SDL_JoystickGetAxis(
            IntPtr joystick,
            int axis
        );

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickGetBall(
            IntPtr joystick,
            int ball,
            out int dx,
            out int dy
        );

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_JoystickGetButton(
            IntPtr joystick,
            int button
        );

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_JoystickGetHat(
            IntPtr joystick,
            int hat
        );

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDL_JoystickName(
            IntPtr joystick
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDL_JoystickNameForIndex(
            int device_index
        );

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumAxes(IntPtr joystick);

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumBalls(IntPtr joystick);

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumButtons(IntPtr joystick);

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumHats(IntPtr joystick);

        /* IntPtr refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_JoystickOpen(int device_index);

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickOpened(int device_index);

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickUpdate();

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_NumJoysticks();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Guid SDL_JoystickGetDeviceGUID(
            int device_index
        );

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Guid SDL_JoystickGetGUID(
            IntPtr joystick
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickGetGUIDString(
            Guid guid,
            byte[] pszGUID,
            int cbGUID
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Guid SDL_JoystickGetGUIDFromString(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string pchGUID
        );

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_JoystickGetAttached(IntPtr joystick);

        /* int refers to an SDL_JoystickID, joystick to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickInstanceID(IntPtr joystick);

        /* joystick refers to an SDL_Joystick*.
         * This function is only available in 2.0.4 or higher.
         */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_JoystickPowerLevel SDL_JoystickCurrentPowerLevel(
            IntPtr joystick
        );

        /* int refers to an SDL_JoystickID, IntPtr to an SDL_Joystick*.
         * This function is only available in 2.0.4 or higher.
         */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_JoystickFromInstanceID(int joyid);

        #endregion
    }
}
