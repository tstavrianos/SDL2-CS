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
        #region SDL_hints.h

        public const string SDL_HINT_FRAMEBUFFER_ACCELERATION =
            "SDL_FRAMEBUFFER_ACCELERATION";
        public const string SDL_HINT_RENDER_DRIVER =
            "SDL_RENDER_DRIVER";
        public const string SDL_HINT_RENDER_OPENGL_SHADERS =
            "SDL_RENDER_OPENGL_SHADERS";
        public const string SDL_HINT_RENDER_DIRECT3D_THREADSAFE =
            "SDL_RENDER_DIRECT3D_THREADSAFE";
        public const string SDL_HINT_RENDER_VSYNC =
            "SDL_RENDER_VSYNC";
        public const string SDL_HINT_VIDEO_X11_XVIDMODE =
            "SDL_VIDEO_X11_XVIDMODE";
        public const string SDL_HINT_VIDEO_X11_XINERAMA =
            "SDL_VIDEO_X11_XINERAMA";
        public const string SDL_HINT_VIDEO_X11_XRANDR =
            "SDL_VIDEO_X11_XRANDR";
        public const string SDL_HINT_GRAB_KEYBOARD =
            "SDL_GRAB_KEYBOARD";
        public const string SDL_HINT_VIDEO_MINIMIZE_ON_FOCUS_LOSS =
            "SDL_VIDEO_MINIMIZE_ON_FOCUS_LOSS";
        public const string SDL_HINT_IDLE_TIMER_DISABLED =
            "SDL_IOS_IDLE_TIMER_DISABLED";
        public const string SDL_HINT_ORIENTATIONS =
            "SDL_IOS_ORIENTATIONS";
        public const string SDL_HINT_XINPUT_ENABLED =
            "SDL_XINPUT_ENABLED";
        public const string SDL_HINT_GAMECONTROLLERCONFIG =
            "SDL_GAMECONTROLLERCONFIG";
        public const string SDL_HINT_JOYSTICK_ALLOW_BACKGROUND_EVENTS =
            "SDL_JOYSTICK_ALLOW_BACKGROUND_EVENTS";
        public const string SDL_HINT_ALLOW_TOPMOST =
            "SDL_ALLOW_TOPMOST";
        public const string SDL_HINT_TIMER_RESOLUTION =
            "SDL_TIMER_RESOLUTION";
        public const string SDL_HINT_RENDER_SCALE_QUALITY =
            "SDL_RENDER_SCALE_QUALITY";

        /* Only available in SDL 2.0.1 or higher */
        public const string SDL_HINT_VIDEO_HIGHDPI_DISABLED =
            "SDL_VIDEO_HIGHDPI_DISABLED";

        /* Only available in SDL 2.0.2 or higher */
        public const string SDL_HINT_CTRL_CLICK_EMULATE_RIGHT_CLICK =
            "SDL_CTRL_CLICK_EMULATE_RIGHT_CLICK";
        public const string SDL_HINT_VIDEO_WIN_D3DCOMPILER =
            "SDL_VIDEO_WIN_D3DCOMPILER";
        public const string SDL_HINT_MOUSE_RELATIVE_MODE_WARP =
            "SDL_MOUSE_RELATIVE_MODE_WARP";
        public const string SDL_HINT_VIDEO_WINDOW_SHARE_PIXEL_FORMAT =
            "SDL_VIDEO_WINDOW_SHARE_PIXEL_FORMAT";
        public const string SDL_HINT_VIDEO_ALLOW_SCREENSAVER =
            "SDL_VIDEO_ALLOW_SCREENSAVER";
        public const string SDL_HINT_ACCELEROMETER_AS_JOYSTICK =
            "SDL_ACCELEROMETER_AS_JOYSTICK";
        public const string SDL_HINT_VIDEO_MAC_FULLSCREEN_SPACES =
            "SDL_VIDEO_MAC_FULLSCREEN_SPACES";

        /* Only available in SDL 2.0.4 or higher */
        public const string SDL_HINT_NO_SIGNAL_HANDLERS =
            "SDL_NO_SIGNAL_HANDLERS";
        public const string SDL_HINT_IME_INTERNAL_EDITING =
            "SDL_IME_INTERNAL_EDITING";
        public const string SDL_HINT_ANDROID_SEPARATE_MOUSE_AND_TOUCH =
            "SDL_ANDROID_SEPARATE_MOUSE_AND_TOUCH";
        public const string SDL_HINT_EMSCRIPTEN_KEYBOARD_ELEMENT =
            "SDL_EMSCRIPTEN_KEYBOARD_ELEMENT";
        public const string SDL_HINT_THREAD_STACK_SIZE =
            "SDL_THREAD_STACK_SIZE";
        public const string SDL_HINT_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN =
            "SDL_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN";
        public const string SDL_HINT_WINDOWS_ENABLE_MESSAGELOOP =
            "SDL_WINDOWS_ENABLE_MESSAGELOOP";
        public const string SDL_HINT_WINDOWS_NO_CLOSE_ON_ALT_F4 =
            "SDL_WINDOWS_NO_CLOSE_ON_ALT_F4";
        public const string SDL_HINT_XINPUT_USE_OLD_JOYSTICK_MAPPING =
            "SDL_XINPUT_USE_OLD_JOYSTICK_MAPPING";
        public const string SDL_HINT_MAC_BACKGROUND_APP =
            "SDL_MAC_BACKGROUND_APP";
        public const string SDL_HINT_VIDEO_X11_NET_WM_PING =
            "SDL_VIDEO_X11_NET_WM_PING";
        public const string SDL_HINT_ANDROID_APK_EXPANSION_MAIN_FILE_VERSION =
            "SDL_ANDROID_APK_EXPANSION_MAIN_FILE_VERSION";
        public const string SDL_HINT_ANDROID_APK_EXPANSION_PATCH_FILE_VERSION =
            "SDL_ANDROID_APK_EXPANSION_PATCH_FILE_VERSION";

        /* Only available in 2.0.5 or higher */
        public const string SDL_HINT_MOUSE_FOCUS_CLICKTHROUGH =
            "SDL_MOUSE_FOCUS_CLICKTHROUGH";
        public const string SDL_HINT_BMP_SAVE_LEGACY_FORMAT =
            "SDL_BMP_SAVE_LEGACY_FORMAT";
        public const string SDL_HINT_WINDOWS_DISABLE_THREAD_NAMING =
            "SDL_WINDOWS_DISABLE_THREAD_NAMING";
        public const string SDL_HINT_APPLE_TV_REMOTE_ALLOW_ROTATION =
            "SDL_APPLE_TV_REMOTE_ALLOW_ROTATION";

        public enum SDL_HintPriority
        {
            SDL_HINT_DEFAULT,
            SDL_HINT_NORMAL,
            SDL_HINT_OVERRIDE
        }

        /// <summary>
        /// Use this function to clear all hints.
        /// </summary>
        /// <remarks>This function is automatically called during <see cref="SDL_Quit()"/>. </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ClearHints();

        /// <summary>
        /// Use this function to get the value of a hint.
        /// </summary>
        /// <param name="name">the hint to query; see the list of hints on
        /// <a href="http://wiki.libsdl.org/moin.cgi/CategoryHints#Hints">CategoryHints</a> for details</param>
        /// <returns>Returns the string value of a hint or NULL if the hint isn't set.</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDL_GetHint(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string name
        );

        /// <summary>
        /// Use this function to set a hint with normal priority.
        /// </summary>
        /// <param name="name">the hint to query; see the list of hints on
        /// <a href="http://wiki.libsdl.org/moin.cgi/CategoryHints#Hints">CategoryHints</a> for details</param>
        /// <param name="value">the value of the hint variable</param>
        /// <returns>Returns SDL_TRUE if the hint was set, SDL_FALSE otherwise.</returns>
        /// <remarks>Hints will not be set if there is an existing override hint or environment
        /// variable that takes precedence. You can use <see cref="SDL_SetHintWithPriority()"/> to set the hint with
        /// override priority instead.</remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_SetHint(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string name,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string value
        );

        /// <summary>
        /// Use this function to set a hint with a specific priority.
        /// </summary>
        /// <param name="name">the hint to query; see the list of hints on
        /// <a href="http://wiki.libsdl.org/moin.cgi/CategoryHints#Hints">CategoryHints</a> for details</param>
        /// <param name="value">the value of the hint variable</param>
        /// <param name="priority">the <see cref="SDL_HintPriority"/> level for the hint</param>
        /// <returns>Returns SDL_TRUE if the hint was set, SDL_FALSE otherwise.</returns>
        /// <remarks>The priority controls the behavior when setting a hint that already has a value.
        /// Hints will replace existing hints of their priority and lower. Environment variables are
        /// considered to have override priority. </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_SetHintWithPriority(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string name,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string value,
            SDL_HintPriority priority
        );

        /* Available in 2.0.5 or higher */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_GetHintBoolean(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string name,
            SDL_bool default_value
        );

        #endregion    
    }
}
