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
        #region SDL_log.h

        /* Begin nameless enum SDL_LOG_CATEGORY */
        public const int SDL_LOG_CATEGORY_APPLICATION = 0;
        public const int SDL_LOG_CATEGORY_ERROR = 1;
        public const int SDL_LOG_CATEGORY_ASSERT = 2;
        public const int SDL_LOG_CATEGORY_SYSTEM = 3;
        public const int SDL_LOG_CATEGORY_AUDIO = 4;
        public const int SDL_LOG_CATEGORY_VIDEO = 5;
        public const int SDL_LOG_CATEGORY_RENDER = 6;
        public const int SDL_LOG_CATEGORY_INPUT = 7;
        public const int SDL_LOG_CATEGORY_TEST = 8;

        /* Reserved for future SDL library use */
        public const int SDL_LOG_CATEGORY_RESERVED1 = 9;
        public const int SDL_LOG_CATEGORY_RESERVED2 = 10;
        public const int SDL_LOG_CATEGORY_RESERVED3 = 11;
        public const int SDL_LOG_CATEGORY_RESERVED4 = 12;
        public const int SDL_LOG_CATEGORY_RESERVED5 = 13;
        public const int SDL_LOG_CATEGORY_RESERVED6 = 14;
        public const int SDL_LOG_CATEGORY_RESERVED7 = 15;
        public const int SDL_LOG_CATEGORY_RESERVED8 = 16;
        public const int SDL_LOG_CATEGORY_RESERVED9 = 17;
        public const int SDL_LOG_CATEGORY_RESERVED10 = 18;

        /* Beyond this point is reserved for application use, e.g.
            enum {
                LOG_CATEGORY_AWESOME1 = SDL_LOG_CATEGORY_CUSTOM,
                LOG_CATEGORY_AWESOME2,
                LOG_CATEGORY_AWESOME3,
                ...
            };
        */
        public const int SDL_LOG_CATEGORY_CUSTOM = 19;
        /* End nameless enum SDL_LOG_CATEGORY */

        /// <summary>
        /// An enumeration of the predefined log priorities.
        /// </summary>
        public enum SDL_LogPriority
        {
            SDL_LOG_PRIORITY_VERBOSE = 1,
            SDL_LOG_PRIORITY_DEBUG,
            SDL_LOG_PRIORITY_INFO,
            SDL_LOG_PRIORITY_WARN,
            SDL_LOG_PRIORITY_ERROR,
            SDL_LOG_PRIORITY_CRITICAL,
            SDL_NUM_LOG_PRIORITIES
        }

        /// <summary>
        /// Used as a callback for <see cref="SDL_LogGetOutputFunction()"/> and <see cref="SDL_LogSetOutputFunction()"/>
        /// </summary>
        /// <param name="userdata">what was passed as userdata to <see cref="SDL_LogSetOutputFunction()"/></param>
        /// <param name="category">the category of the message; see Remarks for details</param>
        /// <param name="priority">the priority of the message; see Remarks for details</param>
        /// <param name="message">the message being output</param>
        /// <remarks>The category can be one of SDL_LOG_CATEGORY*</remarks>
        /// <remarks>The priority can be one of SDL_LOG_PRIORITY*</remarks>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SDL_LogOutputFunction(
            IntPtr userdata, // void*
            int category,
            SDL_LogPriority priority,
            IntPtr message // const char*
        );

        /// <summary>
        /// Use this function to log a message with SDL_LOG_CATEGORY_APPLICATION and SDL_LOG_PRIORITY_INFO.
        /// </summary>
        /// <param name="fmt">a printf() style message format string</param>
        /// <param name="...">additional parameters matching % tokens in the fmt string, if any</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Log(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string fmt,
            __arglist
        );

        /// <summary>
        /// Use this function to log a message with SDL_LOG_PRIORITY_VERBOSE.
        /// </summary>
        /// <param name="category">the category of the message; see Remarks for details</param>
        /// <param name="fmt">a printf() style message format string</param>
        /// <param name="...">additional parameters matching % tokens in the fmt string, if any</param>
        /// <remarks>The category can be one of SDL_LOG_CATEGORY*</remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogVerbose(
            int category,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string fmt,
            __arglist
        );

        /// <summary>
        /// Use this function to log a message with SDL_LOG_PRIORITY_DEBUG.
        /// </summary>
        /// <param name="category">the category of the message; see Remarks for details</param>
        /// <param name="fmt">a printf() style message format string</param>
        /// <param name="...">additional parameters matching % tokens in the fmt string, if any</param>
        /// <remarks>The category can be one of SDL_LOG_CATEGORY*</remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogDebug(
            int category,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string fmt,
            __arglist
        );

        /// <summary>
        /// Use this function to log a message with SDL_LOG_PRIORITY_INFO.
        /// </summary>
        /// <param name="category">the category of the message; see Remarks for details</param>
        /// <param name="fmt">a printf() style message format string</param>
        /// <param name="...">additional parameters matching % tokens in the fmt string, if any</param>
        /// <remarks>The category can be one of SDL_LOG_CATEGORY*</remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogInfo(
            int category,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string fmt,
            __arglist
        );

        /// <summary>
        /// Use this function to log a message with SDL_LOG_PRIORITY_WARN.
        /// </summary>
        /// <param name="category">the category of the message; see Remarks for details</param>
        /// <param name="fmt">a printf() style message format string</param>
        /// <param name="...">additional parameters matching % tokens in the fmt string, if any</param>
        /// <remarks>The category can be one of SDL_LOG_CATEGORY*</remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogWarn(
            int category,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string fmt,
            __arglist
        );

        /// <summary>
        /// Use this function to log a message with SDL_LOG_PRIORITY_ERROR.
        /// </summary>
        /// <param name="category">the category of the message; see Remarks for details</param>
        /// <param name="fmt">a printf() style message format string</param>
        /// <param name="...">additional parameters matching % tokens in the fmt string, if any</param>
        /// <remarks>The category can be one of SDL_LOG_CATEGORY*</remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogError(
            int category,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string fmt,
            __arglist
        );

        /// <summary>
        /// Use this function to log a message with SDL_LOG_PRIORITY_CRITICAL.
        /// </summary>
        /// <param name="category">the category of the message; see Remarks for details</param>
        /// <param name="fmt">a printf() style message format string</param>
        /// <param name="...">additional parameters matching % tokens in the fmt string, if any</param>
        /// <remarks>The category can be one of SDL_LOG_CATEGORY*</remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogCritical(
            int category,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string fmt,
            __arglist
        );

        /// <summary>
        /// Use this function to log a message with the specified category and priority.
        /// </summary>
        /// <param name="category">the category of the message; see Remarks for details</param>
        /// <param name="priority">the priority of the message; see Remarks for details</param>
        /// <param name="fmt">a printf() style message format string</param>
        /// <param name="...">additional parameters matching % tokens in the fmt string, if any</param>
        /// <remarks>The category can be one of SDL_LOG_CATEGORY*</remarks>
        /// <remarks>The priority can be one of SDL_LOG_PRIORITY*</remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogMessage(
            int category,
            SDL_LogPriority priority,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string fmt,
            __arglist
        );

        /// <summary>
        /// Use this function to log a message with the specified category and priority.
        /// This version of <see cref="SDL_LogMessage"/> uses a stdarg variadic argument list.
        /// </summary>
        /// <param name="category">the category of the message; see Remarks for details</param>
        /// <param name="priority">the priority of the message; see Remarks for details</param>
        /// <param name="fmt">a printf() style message format string</param>
        /// <param name="...">additional parameters matching % tokens in the fmt string, if any</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogMessageV(
            int category,
            SDL_LogPriority priority,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string fmt,
            __arglist
        );

        /// <summary>
        /// Use this function to get the priority of a particular log category.
        /// </summary>
        /// <param name="category">the category to query; see Remarks for details</param>
        /// <returns>Returns the <see cref="SDL_LogPriority"/> for the requested category; see Remarks for details. </returns>
        /// <remarks>The category can be one of SDL_LOG_CATEGORY*</remarks>
        /// <remarks>The returned priority will be one of SDL_LOG_PRIORITY*</remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_LogPriority SDL_LogGetPriority(
            int category
        );

        /// <summary>
        /// Use this function to set the priority of a particular log category.
        /// </summary>
        /// <param name="category">the category to query; see Remarks for details</param>
        /// <param name="priority">the <see cref="SDL_LogPriority"/> of the message; see Remarks for details</param>
        /// <remarks>The category can be one of SDL_LOG_CATEGORY*</remarks>
        /// <remarks>The priority can be one of SDL_LOG_PRIORITY*</remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogSetPriority(
            int category,
            SDL_LogPriority priority
        );

        /// <summary>
        /// Use this function to set the priority of all log categories.
        /// </summary>
        /// <param name="priority">the <see cref="SDL_LogPriority"/> of the message; see Remarks for details</param>
        /// <remarks>The priority can be one of SDL_LOG_PRIORITY*</remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogSetAllPriority(
            SDL_LogPriority priority
        );

        /// <summary>
        /// Use this function to reset all priorities to default.
        /// </summary>
        /// <remarks>This is called in <see cref="SDL_Quit()"/>. </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogResetPriorities();

        /// <summary>
        /// Use this function to get the current log output function.
        /// </summary>
        /// <param name="callback">a pointer filled in with the current log callback; see Remarks for details</param>
        /// <param name="userdata">a pointer filled in with the pointer that is passed to callback (refers to void*)</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogGetOutputFunction(
            out SDL_LogOutputFunction callback,
            out IntPtr userdata
        );

        /* userdata refers to a void* */
        /// <summary>
        /// Use this function to replace the default log output function with one of your own.
        /// </summary>
        /// <param name="callback">the function to call instead of the default; see Remarks for details</param>
        /// <param name="userdata">a pointer that is passed to callback (refers to void*)</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogSetOutputFunction(
            SDL_LogOutputFunction callback,
            IntPtr userdata
        );

        #endregion
    }
}
