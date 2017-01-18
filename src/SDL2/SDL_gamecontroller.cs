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
        #region SDL_gamecontroller.h

        public enum SDL_GameControllerBindType
        {
            SDL_CONTROLLER_BINDTYPE_NONE,
            SDL_CONTROLLER_BINDTYPE_BUTTON,
            SDL_CONTROLLER_BINDTYPE_AXIS,
            SDL_CONTROLLER_BINDTYPE_HAT
        }

        public enum SDL_GameControllerAxis
        {
            SDL_CONTROLLER_AXIS_INVALID = -1,
            SDL_CONTROLLER_AXIS_LEFTX,
            SDL_CONTROLLER_AXIS_LEFTY,
            SDL_CONTROLLER_AXIS_RIGHTX,
            SDL_CONTROLLER_AXIS_RIGHTY,
            SDL_CONTROLLER_AXIS_TRIGGERLEFT,
            SDL_CONTROLLER_AXIS_TRIGGERRIGHT,
            SDL_CONTROLLER_AXIS_MAX
        }

        public enum SDL_GameControllerButton
        {
            SDL_CONTROLLER_BUTTON_INVALID = -1,
            SDL_CONTROLLER_BUTTON_A,
            SDL_CONTROLLER_BUTTON_B,
            SDL_CONTROLLER_BUTTON_X,
            SDL_CONTROLLER_BUTTON_Y,
            SDL_CONTROLLER_BUTTON_BACK,
            SDL_CONTROLLER_BUTTON_GUIDE,
            SDL_CONTROLLER_BUTTON_START,
            SDL_CONTROLLER_BUTTON_LEFTSTICK,
            SDL_CONTROLLER_BUTTON_RIGHTSTICK,
            SDL_CONTROLLER_BUTTON_LEFTSHOULDER,
            SDL_CONTROLLER_BUTTON_RIGHTSHOULDER,
            SDL_CONTROLLER_BUTTON_DPAD_UP,
            SDL_CONTROLLER_BUTTON_DPAD_DOWN,
            SDL_CONTROLLER_BUTTON_DPAD_LEFT,
            SDL_CONTROLLER_BUTTON_DPAD_RIGHT,
            SDL_CONTROLLER_BUTTON_MAX,
        }

        // FIX ME: I'd rather this somehow be private...
        [StructLayout(LayoutKind.Sequential)]
        internal struct INTERNAL_GameControllerButtonBind_hat
        {
            public int hat;
            public int hat_mask;
        }

        /* This struct has a union in it, hence the Explicit layout. */
        [StructLayout(LayoutKind.Explicit)]
        public struct SDL_GameControllerButtonBind
        {
            /* Note: enum size is 4 bytes. */
            [FieldOffset(0)]
            public SDL_GameControllerBindType bindType;
            [FieldOffset(4)]
            public int button;
            [FieldOffset(4)]
            public int axis;
            [FieldOffset(4)]
            internal INTERNAL_GameControllerButtonBind_hat hat;
        }

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerAddMapping(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string mappingString
        );

        /* THIS IS AN RWops FUNCTION! */
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerAddMappingsFromRW", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_SDL_GameControllerAddMappingsFromRW(
            IntPtr rw,
            int freerw
        );
        public static int SDL_GameControllerAddMappingsFromFile(string file)
        {
            IntPtr rwops = INTERNAL_SDL_RWFromFile(file, "rb");
            return INTERNAL_SDL_GameControllerAddMappingsFromRW(rwops, 1);
        }

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDL_GameControllerMappingForGUID(
            Guid guid
        );

        /* gamecontroller refers to an SDL_GameController* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDL_GameControllerMapping(
            IntPtr gamecontroller
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_IsGameController(int joystick_index);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDL_GameControllerNameForIndex(
            int joystick_index
        );

        /* IntPtr refers to an SDL_GameController* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GameControllerOpen(int joystick_index);

        /* gamecontroller refers to an SDL_GameController* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDL_GameControllerName(
            IntPtr gamecontroller
        );

        /* gamecontroller refers to an SDL_GameController* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_GameControllerGetAttached(
            IntPtr gamecontroller
        );

        /* IntPtr refers to an SDL_Joystick*
         * gamecontroller refers to an SDL_GameController*
         */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GameControllerGetJoystick(
            IntPtr gamecontroller
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerEventState(int state);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GameControllerUpdate();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_GameControllerAxis SDL_GameControllerGetAxisFromString(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string pchString
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDL_GameControllerGetStringForAxis(
            SDL_GameControllerAxis axis
        );

        /* gamecontroller refers to an SDL_GameController* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_GameControllerButtonBind SDL_GameControllerGetBindForAxis(
            IntPtr gamecontroller,
            SDL_GameControllerAxis axis
        );

        /* gamecontroller refers to an SDL_GameController* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern short SDL_GameControllerGetAxis(
            IntPtr gamecontroller,
            SDL_GameControllerAxis axis
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_GameControllerButton SDL_GameControllerGetButtonFromString(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string pchString
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDL_GameControllerGetStringForButton(
            SDL_GameControllerButton button
        );

        /* gamecontroller refers to an SDL_GameController* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_GameControllerButtonBind SDL_GameControllerGetBindForButton(
            IntPtr gamecontroller,
            SDL_GameControllerButton button
        );

        /* gamecontroller refers to an SDL_GameController* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_GameControllerGetButton(
            IntPtr gamecontroller,
            SDL_GameControllerButton button
        );

        /* gamecontroller refers to an SDL_GameController* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GameControllerClose(
            IntPtr gamecontroller
        );

        /* int refers to an SDL_JoystickID, IntPtr to an SDL_GameController*.
         * This function is only available in 2.0.4 or higher.
         */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GameControllerFromInstanceID(int joyid);

        #endregion
    }
}
