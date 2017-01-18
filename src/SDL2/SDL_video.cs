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
        #region SDL_video.h

        /* Actually, this is from SDL_blendmode.h */
        /// <summary>
        /// An enumeration of blend modes used in SDL_RenderCopy() and drawing operations.
        /// </summary>
        [Flags]
        public enum SDL_BlendMode
        {
            SDL_BLENDMODE_NONE =    0x00000000,
            SDL_BLENDMODE_BLEND =    0x00000001,
            SDL_BLENDMODE_ADD =    0x00000002,
            SDL_BLENDMODE_MOD =    0x00000004
        }

        /// <summary>
        /// An enumeration of OpenGL configuration attributes.
        /// </summary>
        public enum SDL_GLattr
        {
            SDL_GL_RED_SIZE,
            SDL_GL_GREEN_SIZE,
            SDL_GL_BLUE_SIZE,
            SDL_GL_ALPHA_SIZE,
            SDL_GL_BUFFER_SIZE,
            SDL_GL_DOUBLEBUFFER,
            SDL_GL_DEPTH_SIZE,
            SDL_GL_STENCIL_SIZE,
            SDL_GL_ACCUM_RED_SIZE,
            SDL_GL_ACCUM_GREEN_SIZE,
            SDL_GL_ACCUM_BLUE_SIZE,
            SDL_GL_ACCUM_ALPHA_SIZE,
            SDL_GL_STEREO,
            SDL_GL_MULTISAMPLEBUFFERS,
            SDL_GL_MULTISAMPLESAMPLES,
            SDL_GL_ACCELERATED_VISUAL,
            SDL_GL_RETAINED_BACKING,
            SDL_GL_CONTEXT_MAJOR_VERSION,
            SDL_GL_CONTEXT_MINOR_VERSION,
            SDL_GL_CONTEXT_EGL,
            SDL_GL_CONTEXT_FLAGS,
            SDL_GL_CONTEXT_PROFILE_MASK,
            SDL_GL_SHARE_WITH_CURRENT_CONTEXT,
            SDL_GL_FRAMEBUFFER_SRGB_CAPABLE,
            SDL_GL_CONTEXT_RELEASE_BEHAVIOR
        }

        /// <summary>
        /// An enumeration of OpenGL profiles.
        /// </summary>
        [Flags]
        public enum SDL_GLprofile
        {
            SDL_GL_CONTEXT_PROFILE_CORE                = 0x0001,
            SDL_GL_CONTEXT_PROFILE_COMPATIBILITY    = 0x0002,
            SDL_GL_CONTEXT_PROFILE_ES                = 0x0004
        }

        /// <summary>
        /// This enumeration is used in conjunction with SDL_GL_SetAttribute
        /// and SDL_GL_CONTEXT_FLAGS. Multiple flags can be OR'd together.
        /// </summary>
        [Flags]
        public enum SDL_GLcontext
        {
            SDL_GL_CONTEXT_DEBUG_FLAG                = 0x0001,
            SDL_GL_CONTEXT_FORWARD_COMPATIBLE_FLAG    = 0x0002,
            SDL_GL_CONTEXT_ROBUST_ACCESS_FLAG        = 0x0004,
            SDL_GL_CONTEXT_RESET_ISOLATION_FLAG        = 0x0008
        }

        /// <summary>
        /// An enumeration of window events.
        /// </summary>
        public enum SDL_WindowEventID : byte
        {
            SDL_WINDOWEVENT_NONE,
            SDL_WINDOWEVENT_SHOWN,
            SDL_WINDOWEVENT_HIDDEN,
            SDL_WINDOWEVENT_EXPOSED,
            SDL_WINDOWEVENT_MOVED,
            SDL_WINDOWEVENT_RESIZED,
            SDL_WINDOWEVENT_SIZE_CHANGED,
            SDL_WINDOWEVENT_MINIMIZED,
            SDL_WINDOWEVENT_MAXIMIZED,
            SDL_WINDOWEVENT_RESTORED,
            SDL_WINDOWEVENT_ENTER,
            SDL_WINDOWEVENT_LEAVE,
            SDL_WINDOWEVENT_FOCUS_GAINED,
            SDL_WINDOWEVENT_FOCUS_LOST,
            SDL_WINDOWEVENT_CLOSE,
            /* Available in 2.0.5 or higher */
            SDL_WINDOWEVENT_TAKE_FOCUS,
            SDL_WINDOWEVENT_HIT_TEST
        }

        /// <summary>
        /// An enumeration of window states.
        /// </summary>
        [Flags]
        public enum SDL_WindowFlags : uint
        {
            SDL_WINDOW_FULLSCREEN =        0x00000001,
            SDL_WINDOW_OPENGL =        0x00000002,
            SDL_WINDOW_SHOWN =        0x00000004,
            SDL_WINDOW_HIDDEN =        0x00000008,
            SDL_WINDOW_BORDERLESS =        0x00000010,
            SDL_WINDOW_RESIZABLE =        0x00000020,
            SDL_WINDOW_MINIMIZED =        0x00000040,
            SDL_WINDOW_MAXIMIZED =        0x00000080,
            SDL_WINDOW_INPUT_GRABBED =    0x00000100,
            SDL_WINDOW_INPUT_FOCUS =    0x00000200,
            SDL_WINDOW_MOUSE_FOCUS =    0x00000400,
            SDL_WINDOW_FULLSCREEN_DESKTOP =
                (SDL_WINDOW_FULLSCREEN | 0x00001000),
            SDL_WINDOW_FOREIGN =        0x00000800,
            SDL_WINDOW_ALLOW_HIGHDPI =    0x00002000,    /* Only available in 2.0.1 */
            SDL_WINDOW_MOUSE_CAPTURE =    0x00004000,    /* Only available in 2.0.4 */
        }

        /// <summary>
        /// Possible return values from the SDL_HitTest callback.
        /// This is only available in 2.0.4.
        /// </summary>
        public enum SDL_HitTestResult
        {
            SDL_HITTEST_NORMAL,        /* Region is normal. No special properties. */
            SDL_HITTEST_DRAGGABLE,        /* Region can drag entire window. */
            SDL_HITTEST_RESIZE_TOPLEFT,
            SDL_HITTEST_RESIZE_TOP,
            SDL_HITTEST_RESIZE_TOPRIGHT,
            SDL_HITTEST_RESIZE_RIGHT,
            SDL_HITTEST_RESIZE_BOTTOMRIGHT,
            SDL_HITTEST_RESIZE_BOTTOM,
            SDL_HITTEST_RESIZE_BOTTOMLEFT,
            SDL_HITTEST_RESIZE_LEFT
        }

        public const int SDL_WINDOWPOS_UNDEFINED_MASK =    0x1FFF0000;
        public const int SDL_WINDOWPOS_CENTERED_MASK =    0x2FFF0000;
        public const int SDL_WINDOWPOS_UNDEFINED =        0x1FFF0000;
        public const int SDL_WINDOWPOS_CENTERED =        0x2FFF0000;

        public static int SDL_WINDOWPOS_UNDEFINED_DISPLAY(int X)
        {
            return (SDL_WINDOWPOS_UNDEFINED_MASK | X);
        }

        public static bool SDL_WINDOWPOS_ISUNDEFINED(int X)
        {
            return (X & 0xFFFF0000) == SDL_WINDOWPOS_UNDEFINED_MASK;
        }

        public static int SDL_WINDOWPOS_CENTERED_DISPLAY(int X)
        {
            return (SDL_WINDOWPOS_CENTERED_MASK | X);
        }

        public static bool SDL_WINDOWPOS_ISCENTERED(int X)
        {
            return (X & 0xFFFF0000) == SDL_WINDOWPOS_CENTERED_MASK;
        }

        /// <summary>
        /// A structure that describes a display mode.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_DisplayMode
        {
            public uint format;
            public int w;
            public int h;
            public int refresh_rate;
            public IntPtr driverdata; // void*
        }

        /* win refers to an SDL_Window*, area to a cosnt SDL_Point*, data to a void* */
        /* Only available in 2.0.4 */
        public delegate SDL_HitTestResult SDL_HitTest(IntPtr win, IntPtr area, IntPtr data);

        /// <summary>
        /// Use this function to create a window with the specified position, dimensions, and flags.
        /// </summary>
        /// <param name="title">the title of the window, in UTF-8 encoding</param>
        /// <param name="x">the x position of the window, SDL_WINDOWPOS_CENTERED, or SDL_WINDOWPOS_UNDEFINED</param>
        /// <param name="y">the y position of the window, SDL_WINDOWPOS_CENTERED, or SDL_WINDOWPOS_UNDEFINED</param>
        /// <param name="w">the width of the window</param>
        /// <param name="h">the height of the window</param>
        /// <param name="flags">0, or one or more <see cref="SDL_WindowFlags"/> OR'd together;
        /// see Remarks for details</param>
        /// <returns>Returns the window that was created or NULL on failure; call <see cref="SDL_GetError()"/>
        /// for more information. (refers to an <see cref="SDL_Window"/>)</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateWindow(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string title,
            int x,
            int y,
            int w,
            int h,
            SDL_WindowFlags flags
        );

        /// <summary>
        /// Use this function to create a window and default renderer.
        /// </summary>
        /// <param name="width">The width of the window</param>
        /// <param name="height">The height of the window</param>
        /// <param name="window_flags">The flags used to create the window (see <see cref="SDL_CreateWindow()"/>)</param>
        /// <param name="window">A pointer filled with the window, or NULL on error (<see cref="SDL_Window*"/>)</param>
        /// <param name="renderer">A pointer filled with the renderer, or NULL on error <see cref="(SDL_Renderer*)"/></param>
        /// <returns>Returns 0 on success, or -1 on error; call <see cref="SDL_GetError()"/> for more information. </returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_CreateWindowAndRenderer(
            int width,
            int height,
            SDL_WindowFlags window_flags,
            out IntPtr window,
            out IntPtr renderer
        );

        /// <summary>
        /// Use this function to create an SDL window from an existing native window.
        /// </summary>
        /// <param name="data">a pointer to driver-dependent window creation data, typically your native window cast to a void*</param>
        /// <returns>Returns the window (<see cref="SDL_Window"/>) that was created or NULL on failure;
        /// call <see cref="SDL_GetError()"/> for more information. </returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateWindowFrom(IntPtr data);

        /// <summary>
        /// Use this function to destroy a window.
        /// </summary>
        /// <param name="window">the window to destroy (<see cref="SDL_Window"/>)</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DestroyWindow(IntPtr window);

        /// <summary>
        /// Use this function to prevent the screen from being blanked by a screen saver.
        /// </summary>
        /// <remarks>If you disable the screensaver, it is automatically re-enabled when SDL quits. </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DisableScreenSaver();

        /// <summary>
        /// Use this function to allow the screen to be blanked by a screen saver.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_EnableScreenSaver();

        /* IntPtr refers to an SDL_DisplayMode. Just use closest. */
        /// <summary>
        /// Use this function to get the closest match to the requested display mode.
        /// </summary>
        /// <param name="displayIndex">the index of the display to query</param>
        /// <param name="mode">an <see cref="SDL_DisplayMode"/> structure containing the desired display mode </param>
        /// <param name="closest">an <see cref="SDL_DisplayMode"/> structure filled in with
        /// the closest match of the available display modes </param>
        /// <returns>Returns the passed in value closest or NULL if no matching video mode was available;
        /// (refers to a <see cref="SDL_DisplayMode"/>)
        /// call <see cref="SDL_GetError()"/> for more information. </returns>
        /// <remarks>The available display modes are scanned and closest is filled in with the closest mode
        /// matching the requested mode and returned. The mode format and refresh rate default to the desktop
        /// mode if they are set to 0. The modes are scanned with size being first priority, format being
        /// second priority, and finally checking the refresh rate. If all the available modes are too small,
        /// then NULL is returned. </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetClosestDisplayMode(
            int displayIndex,
            ref SDL_DisplayMode mode,
            out SDL_DisplayMode closest
        );

        /// <summary>
        /// Use this function to get information about the current display mode.
        /// </summary>
        /// <param name="displayIndex">the index of the display to query</param>
        /// <param name="mode">an <see cref="SDL_DisplayMode"/> structure filled in with the current display mode</param>
        /// <returns>Returns 0 on success or a negative error code on failure;
        /// call <see cref="SDL_GetError()"/> for more information. </returns>
        /// <remarks>There's a difference between this function and <see cref="SDL_GetDesktopDisplayMode"/> when SDL
        /// runs fullscreen and has changed the resolution. In that case this function will return the
        /// current display mode, and not the previous native display mode. </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetCurrentDisplayMode(
            int displayIndex,
            out SDL_DisplayMode mode
        );

        /// <summary>
        /// Use this function to return the name of the currently initialized video driver.
        /// </summary>
        /// <returns>Returns the name of the current video driver or NULL if no driver has been initialized. </returns>
        /// <remarks>There's a difference between this function and <see cref="SDL_GetCurrentDisplayMode"/> when SDL
        /// runs fullscreen and has changed the resolution. In that case this function will return the
        /// previous native display mode, and not the current display mode. </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDL_GetCurrentVideoDriver();

        /// <summary>
        /// Use this function to get information about the desktop display mode.
        /// </summary>
        /// <param name="displayIndex">the index of the display to query</param>
        /// <param name="mode">an <see cref="SDL_DisplayMode"/> structure filled in with the current display mode</param>
        /// <returns>Returns 0 on success or a negative error code on failure;
        /// call <see cref="SDL_GetError()"/> for more information. </returns>
        /// <remarks>There's a difference between this function and <see cref="SDL_GetCurrentDisplayMode"/> when SDL
        /// runs fullscreen and has changed the resolution. In that case this function will return the
        /// previous native display mode, and not the current display mode. </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDesktopDisplayMode(
            int displayIndex,
            out SDL_DisplayMode mode
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDL_GetDisplayName(int index);

        /// <summary>
        /// Use this function to get the desktop area represented by a display, with the primary display located at 0,0.
        /// </summary>
        /// <param name="displayIndex">the index of the display to query</param>
        /// <param name="rect">the <see cref="SDL_Rect"/> structure filled in with the display bounds</param>
        /// <returns>Returns 0 on success or a negative error code on failure;
        /// call <see cref="SDL_GetError()"/> for more information. </returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDisplayBounds(
            int displayIndex,
            out SDL_Rect rect
        );

        /* This function is only available in 2.0.4 or higher */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDisplayDPI(
            int displayIndex,
            out float ddpi,
            out float hdpi,
            out float vdpi
        );

        /// <summary>
        /// Use this function to get information about a specific display mode.
        /// </summary>
        /// <param name="displayIndex">the index of the display to query</param>
        /// <param name="modeIndex">the index of the display mode to query</param>
        /// <param name="mode">an <see cref="SDL_DisplayMode"/> structure filled in with the mode at modeIndex</param>
        /// <returns>Returns 0 on success or a negative error code on failure;
        /// call <see cref="SDL_GetError()"/> for more information. </returns>
        /// <remarks>The display modes are sorted in this priority:
        /// <remarks>bits per pixel -> more colors to fewer colors</remarks>
        /// <remarks>width -> largest to smallest</remarks>
        /// <remarks>height -> largest to smallest</remarks>
        /// <remarks>refresh rate -> highest to lowest</remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDisplayMode(
            int displayIndex,
            int modeIndex,
            out SDL_DisplayMode mode
        );

        /* Available in 2.0.5 or higher */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDisplayUsableBounds(
            int displayIndex,
            out SDL_Rect rect
        );

        /// <summary>
        /// Use this function to return the number of available display modes.
        /// </summary>
        /// <param name="displayIndex">the index of the display to query</param>
        /// <returns>Returns a number >= 1 on success or a negative error code on failure;
        /// call <see cref="SDL_GetError()"/> for more information. </returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumDisplayModes(
            int displayIndex
        );

        /// <summary>
        /// Use this function to return the number of available video displays.
        /// </summary>
        /// <returns>Returns a number >= 1 or a negative error code on failure;
        /// call <see cref="SDL_GetError()"/> for more information. </returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumVideoDisplays();

        /// <summary>
        /// Use this function to get the number of video drivers compiled into SDL.
        /// </summary>
        /// <returns>Returns a number >= 1 on success or a negative error code on failure;
        /// call <see cref="SDL_GetError()"/> for more information. </returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumVideoDrivers();

        /// <summary>
        /// Use this function to get the name of a built in video driver.
        /// </summary>
        /// <param name="index">the index of a video driver</param>
        /// <returns>Returns the name of the video driver with the given index. </returns>
        /// <remarks>The video drivers are presented in the order in which they are normally checked during initialization. </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDL_GetVideoDriver(
            int index
        );

        /// <summary>
        /// Use this function to get the brightness (gamma correction) for a window.
        /// </summary>
        /// <param name="window">the window to query (<see cref="SDL_Window"/>)</param>
        /// <returns>Returns the brightness for the window where 0.0 is completely dark and 1.0 is normal brightness. </returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float SDL_GetWindowBrightness(
            IntPtr window
        );

        /* window refers to an SDL_Window* */
        /* Available in 2.0.5 or higher */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowOpacity(
            IntPtr window,
            float opacity
        );

        /* window refers to an SDL_Window* */
        /* Available in 2.0.5 or higher */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowOpacity(
            IntPtr window,
            out float out_opacity
        );

        /* modal_window and parent_window refer to an SDL_Window*s */
        /* Available in 2.0.5 or higher */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowModalFor(
            IntPtr modal_window,
            IntPtr parent_window
        );

        /* window refers to an SDL_Window* */
        /* Available in 2.0.5 or higher */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowInputFocus(IntPtr window);

        /// <summary>
        /// Use this function to retrieve the data pointer associated with a window.
        /// </summary>
        /// <param name="window">the window to query (<see cref="SDL_Window"/>)</param>
        /// <param name="name">the name of the pointer</param>
        /// <returns>Returns the value associated with name. (void*)</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetWindowData(
            IntPtr window,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string name
        );

        /// <summary>
        /// Use this function to get the index of the display associated with a window.
        /// </summary>
        /// <param name="window">the window to query (<see cref="SDL_Window"/>)</param>
        /// <returns>Returns the index of the display containing the center of the window
        /// on success or a negative error code on failure;
        /// call <see cref="SDL_GetError()"/> for more information. </returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowDisplayIndex(
            IntPtr window
        );

        /// <summary>
        /// Use this function to fill in information about the display mode to use when a window is visible at fullscreen.
        /// </summary>
        /// <param name="window">the window to query (<see cref="SDL_Window"/>)</param>
        /// <param name="mode">an <see cref="SDL_DisplayMode"/> structure filled in with the fullscreen display mode</param>
        /// <returns>Returns 0 on success or a negative error code on failure;
        /// call <see cref="SDL_GetError()"/> for more information. </returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowDisplayMode(
            IntPtr window,
            out SDL_DisplayMode mode
        );

        /// <summary>
        /// Use this function to get the window flags.
        /// </summary>
        /// <param name="window">the window to query (<see cref="SDL_Window"/>)</param>
        /// <returns>Returns a mask of the <see cref="SDL_WindowFlags"/> associated with window; see Remarks for details.</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetWindowFlags(IntPtr window);

        /// <summary>
        /// Use this function to get a window from a stored ID.
        /// </summary>
        /// <param name="id">the ID of the window</param>
        /// <returns>Returns the window associated with id or NULL if it doesn't exist (<see cref="SDL_Window"/>);
        /// call <see cref="SDL_GetError()"/> for more information. </returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetWindowFromID(uint id);

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowGammaRamp(
            IntPtr window,
            [Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
                ushort[] red,
            [Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
                ushort[] green,
            [Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
                ushort[] blue
        );

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_GetWindowGrab(IntPtr window);

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetWindowID(IntPtr window);

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetWindowPixelFormat(
            IntPtr window
        );

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetWindowMaximumSize(
            IntPtr window,
            out int max_w,
            out int max_h
        );

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetWindowMinimumSize(
            IntPtr window,
            out int min_w,
            out int min_h
        );

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetWindowPosition(
            IntPtr window,
            out int x,
            out int y
        );

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetWindowSize(
            IntPtr window,
            out int w,
            out int h
        );

        /* IntPtr refers to an SDL_Surface*, window to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetWindowSurface(IntPtr window);

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDL_GetWindowTitle(
            IntPtr window
        );

        /* texture refers to an SDL_Texture* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_BindTexture(
            IntPtr texture,
            out float texw,
            out float texh
        );

        /* IntPtr and window refer to an SDL_GLContext and SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GL_CreateContext(IntPtr window);

        /* context refers to an SDL_GLContext */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_DeleteContext(IntPtr context);

        /* IntPtr refers to a function pointer */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GL_GetProcAddress(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string proc
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_LoadLibrary(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string path
        );
                
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_UnloadLibrary();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_GL_ExtensionSupported(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string extension
        );

        /* Only available in SDL 2.0.2 or higher */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_ResetAttributes();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_GetAttribute(
            SDL_GLattr attr,
            out int value
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_GetSwapInterval();

        /* window and context refer to an SDL_Window* and SDL_GLContext */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_MakeCurrent(
            IntPtr window,
            IntPtr context
        );

        /* IntPtr refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GL_GetCurrentWindow();

        /* IntPtr refers to an SDL_Context */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GL_GetCurrentContext();

        /* window refers to an SDL_Window*, This function is only available in SDL 2.0.1 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_GetDrawableSize(
            IntPtr window,
            out int w,
            out int h
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_SetAttribute(
            SDL_GLattr attr,
            int value
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_SetSwapInterval(int interval);

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_SwapWindow(IntPtr window);

        /* texture refers to an SDL_Texture* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_UnbindTexture(IntPtr texture);

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_HideWindow(IntPtr window);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_IsScreenSaverEnabled();

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MaximizeWindow(IntPtr window);

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MinimizeWindow(IntPtr window);

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RaiseWindow(IntPtr window);

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RestoreWindow(IntPtr window);

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowBrightness(
            IntPtr window,
            float brightness
        );

        /* IntPtr and userdata are void*, window is an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_SetWindowData(
            IntPtr window,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string name,
            IntPtr userdata
        );

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowDisplayMode(
            IntPtr window,
            ref SDL_DisplayMode mode
        );

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowFullscreen(
            IntPtr window,
            uint flags
        );

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowGammaRamp(
            IntPtr window,
            [In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
                ushort[] red,
            [In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
                ushort[] green,
            [In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
                ushort[] blue
        );

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowGrab(
            IntPtr window,
            SDL_bool grabbed
        );

        /* window refers to an SDL_Window*, icon to an SDL_Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowIcon(
            IntPtr window,
            IntPtr icon
        );

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowMaximumSize(
            IntPtr window,
            int max_w,
            int max_h
        );

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowMinimumSize(
            IntPtr window,
            int min_w,
            int min_h
        );

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowPosition(
            IntPtr window,
            int x,
            int y
        );

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowSize(
            IntPtr window,
            int w,
            int h
        );

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowBordered(
            IntPtr window,
            SDL_bool bordered
        );

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowBordersSize(
            IntPtr window,
            out int top,
            out int left,
            out int bottom,
            out int right
        );

        /* window refers to an SDL_Window* */
        /* Available in 2.0.5 or higher */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowResizable(
            IntPtr window,
            SDL_bool resizable
        );

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowTitle(
            IntPtr window,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string title
        );

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ShowWindow(IntPtr window);

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateWindowSurface(IntPtr window);

        /* window refers to an SDL_Window* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateWindowSurfaceRects(
            IntPtr window,
            [In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 2)]
                SDL_Rect[] rects,
            int numrects
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_VideoInit(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string driver_name
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_VideoQuit();

        /* window refers to an SDL_Window*, callback_data to a void* */
        /* Only available in 2.0.4 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowHitTest(
            IntPtr window,
            SDL_HitTest callback,
            IntPtr callback_data
        );

        /* IntPtr refers to an SDL_Window* */
        /* Only available in 2.0.4 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetGrabbedWindow();

        #endregion
    }
}
