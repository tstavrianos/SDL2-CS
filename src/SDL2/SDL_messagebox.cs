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
        #region SDL_messagebox.h

        [Flags]
        public enum SDL_MessageBoxFlags : uint
        {
            SDL_MESSAGEBOX_ERROR =        0x00000010,
            SDL_MESSAGEBOX_WARNING =    0x00000020,
            SDL_MESSAGEBOX_INFORMATION =    0x00000040
        }

        [Flags]
        public enum SDL_MessageBoxButtonFlags : uint
        {
            SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT = 0x00000001,
            SDL_MESSAGEBOX_BUTTON_ESCAPEKEY_DEFAULT = 0x00000002
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct INTERNAL_SDL_MessageBoxButtonData
        {
            public SDL_MessageBoxButtonFlags flags;
            public int buttonid;
            public IntPtr text; /* The UTF-8 button text */
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_MessageBoxButtonData
        {
            public SDL_MessageBoxButtonFlags flags;
            public int buttonid;
            public string text; /* The UTF-8 button text */
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_MessageBoxColor
        {
            public byte r, g, b;
        }

        public enum SDL_MessageBoxColorType
        {
            SDL_MESSAGEBOX_COLOR_BACKGROUND,
            SDL_MESSAGEBOX_COLOR_TEXT,
            SDL_MESSAGEBOX_COLOR_BUTTON_BORDER,
            SDL_MESSAGEBOX_COLOR_BUTTON_BACKGROUND,
            SDL_MESSAGEBOX_COLOR_BUTTON_SELECTED,
            SDL_MESSAGEBOX_COLOR_MAX
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_MessageBoxColorScheme
        {
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = (int)SDL_MessageBoxColorType.SDL_MESSAGEBOX_COLOR_MAX)]
                public SDL_MessageBoxColor[] colors;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct INTERNAL_SDL_MessageBoxData
        {
            public SDL_MessageBoxFlags flags;
            public IntPtr window;                /* Parent window, can be NULL */
            public IntPtr title;                /* UTF-8 title */
            public IntPtr message;                /* UTF-8 message text */
            public int numbuttons;
            public IntPtr buttons;
            public IntPtr colorScheme;            /* Can be NULL to use system settings */
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_MessageBoxData
        {
            public SDL_MessageBoxFlags flags;
            public IntPtr window;                /* Parent window, can be NULL */
            public string title;                /* UTF-8 title */
            public string message;                /* UTF-8 message text */
            public int numbuttons;
            public SDL_MessageBoxButtonData[] buttons;
            public SDL_MessageBoxColorScheme? colorScheme;    /* Can be NULL to use system settings */
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="messageboxdata"></param>
        /// <param name="buttonid"></param>
        /// <returns></returns>
        [DllImport(nativeLibName, EntryPoint = "SDL_ShowMessageBox", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_SDL_ShowMessageBox([In()] ref INTERNAL_SDL_MessageBoxData messageboxdata, out int buttonid);

        /// <summary>
        ///
        /// </summary>
        /// <param name="messageboxdata"></param>
        /// <param name="buttonid"></param>
        /// <returns></returns>
        public static unsafe int SDL_ShowMessageBox([In()] ref SDL_MessageBoxData messageboxdata, out int buttonid)
        {
            var utf8 = LPUtf8StrMarshaler.GetInstance(null);

            var data = new INTERNAL_SDL_MessageBoxData()
            {
                flags = messageboxdata.flags,
                window = messageboxdata.window,
                title = utf8.MarshalManagedToNative(messageboxdata.title),
                message = utf8.MarshalManagedToNative(messageboxdata.message),
                numbuttons = messageboxdata.numbuttons,
            };

            var buttons = new INTERNAL_SDL_MessageBoxButtonData[messageboxdata.numbuttons];
            for (int i = 0; i < messageboxdata.numbuttons; i++)
            {
                buttons[i] = new INTERNAL_SDL_MessageBoxButtonData()
                {
                    flags = messageboxdata.buttons[i].flags,
                    buttonid = messageboxdata.buttons[i].buttonid,
                    text = utf8.MarshalManagedToNative(messageboxdata.buttons[i].text),
                };
            }

            if (messageboxdata.colorScheme != null)
            {
                data.colorScheme = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SDL_MessageBoxColorScheme)));
                Marshal.StructureToPtr(messageboxdata.colorScheme.Value, data.colorScheme, false);
            }

            int result;
            fixed (INTERNAL_SDL_MessageBoxButtonData* buttonsPtr = &buttons[0])
            {
                data.buttons = (IntPtr)buttonsPtr;
                result = INTERNAL_SDL_ShowMessageBox(ref data, out buttonid);
            }

            Marshal.FreeHGlobal(data.colorScheme);
            for (int i = 0; i < messageboxdata.numbuttons; i++)
            {
                utf8.CleanUpNativeData(buttons[i].text);
            }
            utf8.CleanUpNativeData(data.message);
            utf8.CleanUpNativeData(data.title);

            return result;
        }

        /// <summary>
        /// Use this function to display a simple message box.
        /// </summary>
        /// <param name="flags">An <see cref="SDL_MessageBoxFlag"/>; see Remarks for details;</param>
        /// <param name="title">UTF-8 title text</param>
        /// <param name="message">UTF-8 message text</param>
        /// <param name="window">the parent window, or NULL for no parent (refers to a <see cref="SDL_Window"/></param>
        /// <returns>0 on success or a negative error code on failure; call SDL_GetError() for more information. </returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_ShowSimpleMessageBox(
            SDL_MessageBoxFlags flags,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string title,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string message,
            IntPtr window
        );

        #endregion
    }
}
