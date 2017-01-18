﻿#region License
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
        #region SDL_events.h

        /* General keyboard/mouse state definitions. */
        public const byte SDL_PRESSED =        1;
        public const byte SDL_RELEASED =    0;

        /* Default size is according to SDL2 default. */
        public const int SDL_TEXTEDITINGEVENT_TEXT_SIZE = 32;
        public const int SDL_TEXTINPUTEVENT_TEXT_SIZE = 32;

        /* The types of events that can be delivered. */
        public enum SDL_EventType : uint
        {
            SDL_FIRSTEVENT =        0,

            /* Application events */
            SDL_QUIT =             0x100,

            /* Window events */
            SDL_WINDOWEVENT =         0x200,
            SDL_SYSWMEVENT,

            /* Keyboard events */
            SDL_KEYDOWN =             0x300,
            SDL_KEYUP,
            SDL_TEXTEDITING,
            SDL_TEXTINPUT,

            /* Mouse events */
            SDL_MOUSEMOTION =         0x400,
            SDL_MOUSEBUTTONDOWN,
            SDL_MOUSEBUTTONUP,
            SDL_MOUSEWHEEL,

            /* Joystick events */
            SDL_JOYAXISMOTION =        0x600,
            SDL_JOYBALLMOTION,
            SDL_JOYHATMOTION,
            SDL_JOYBUTTONDOWN,
            SDL_JOYBUTTONUP,
            SDL_JOYDEVICEADDED,
            SDL_JOYDEVICEREMOVED,

            /* Game controller events */
            SDL_CONTROLLERAXISMOTION =     0x650,
            SDL_CONTROLLERBUTTONDOWN,
            SDL_CONTROLLERBUTTONUP,
            SDL_CONTROLLERDEVICEADDED,
            SDL_CONTROLLERDEVICEREMOVED,
            SDL_CONTROLLERDEVICEREMAPPED,

            /* Touch events */
            SDL_FINGERDOWN =         0x700,
            SDL_FINGERUP,
            SDL_FINGERMOTION,

            /* Gesture events */
            SDL_DOLLARGESTURE =        0x800,
            SDL_DOLLARRECORD,
            SDL_MULTIGESTURE,

            /* Clipboard events */
            SDL_CLIPBOARDUPDATE =        0x900,

            /* Drag and drop events */
            SDL_DROPFILE =            0x1000,
            /* Only available in 2.0.4 or higher */
            SDL_DROPTEXT,
            SDL_DROPBEGIN,
            SDL_DROPCOMPLETE,

            /* Audio hotplug events */
            /* Only available in SDL 2.0.4 or higher */
            SDL_AUDIODEVICEADDED =        0x1100,
            SDL_AUDIODEVICEREMOVED,

            /* Render events */
            /* Only available in SDL 2.0.2 or higher */
            SDL_RENDER_TARGETS_RESET =    0x2000,
            /* Only available in SDL 2.0.4 or higher */
            SDL_RENDER_DEVICE_RESET,

            /* Events SDL_USEREVENT through SDL_LASTEVENT are for
             * your use, and should be allocated with
             * SDL_RegisterEvents()
             */
            SDL_USEREVENT =            0x8000,

            /* The last event, used for bouding arrays. */
            SDL_LASTEVENT =            0xFFFF
        }

        /* Only available in 2.0.4 or higher */
        public enum SDL_MouseWheelDirection : uint
        {
            SDL_MOUSEHWEEL_NORMAL,
            SDL_MOUSEWHEEL_FLIPPED
        }

        /* Fields shared by every event */
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_GenericEvent
        {
            public SDL_EventType type;
            public UInt32 timestamp;
        }

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /* Window state change event data (event.window.*) */
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_WindowEvent
        {
            public SDL_EventType type;
            public UInt32 timestamp;
            public UInt32 windowID;
            public SDL_WindowEventID windowEvent; // event, lolC#
            private byte padding1;
            private byte padding2;
            private byte padding3;
            public Int32 data1;
            public Int32 data2;
        }
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /* Keyboard button event structure (event.key.*) */
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_KeyboardEvent
        {
            public SDL_EventType type;
            public UInt32 timestamp;
            public UInt32 windowID;
            public byte state;
            public byte repeat; /* non-zero if this is a repeat */
            private byte padding2;
            private byte padding3;
            public SDL_Keysym keysym;
        }
#pragma warning restore 0169

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SDL_TextEditingEvent
        {
            public SDL_EventType type;
            public UInt32 timestamp;
            public UInt32 windowID;
            public fixed byte text[SDL_TEXTEDITINGEVENT_TEXT_SIZE];
            public Int32 start;
            public Int32 length;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SDL_TextInputEvent
        {
            public SDL_EventType type;
            public UInt32 timestamp;
            public UInt32 windowID;
            public fixed byte text[SDL_TEXTINPUTEVENT_TEXT_SIZE];
        }

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /* Mouse motion event structure (event.motion.*) */
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_MouseMotionEvent
        {
            public SDL_EventType type;
            public UInt32 timestamp;
            public UInt32 windowID;
            public UInt32 which;
            public byte state; /* bitmask of buttons */
            private byte padding1;
            private byte padding2;
            private byte padding3;
            public Int32 x;
            public Int32 y;
            public Int32 xrel;
            public Int32 yrel;
        }
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /* Mouse button event structure (event.button.*) */
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_MouseButtonEvent
        {
            public SDL_EventType type;
            public UInt32 timestamp;
            public UInt32 windowID;
            public UInt32 which;
            public byte button; /* button id */
            public byte state; /* SDL_PRESSED or SDL_RELEASED */
            public byte clicks; /* 1 for single-click, 2 for double-click, etc. */
            private byte padding1;
            public Int32 x;
            public Int32 y;
        }
#pragma warning restore 0169

        /* Mouse wheel event structure (event.wheel.*) */
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_MouseWheelEvent
        {
            public SDL_EventType type;
            public UInt32 timestamp;
            public UInt32 windowID;
            public UInt32 which;
            public Int32 x; /* amount scrolled horizontally */
            public Int32 y; /* amount scrolled vertically */
            public UInt32 direction; /* Set to one of the SDL_MOUSEWHEEL_* defines */
        }

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /* Joystick axis motion event structure (event.jaxis.*) */
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_JoyAxisEvent
        {
            public SDL_EventType type;
            public UInt32 timestamp;
            public Int32 which; /* SDL_JoystickID */
            public byte axis;
            private byte padding1;
            private byte padding2;
            private byte padding3;
            public Int16 axisValue; /* value, lolC# */
            public UInt16 padding4;
        }
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /* Joystick trackball motion event structure (event.jball.*) */
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_JoyBallEvent
        {
            public SDL_EventType type;
            public UInt32 timestamp;
            public Int32 which; /* SDL_JoystickID */
            public byte ball;
            private byte padding1;
            private byte padding2;
            private byte padding3;
            public Int16 xrel;
            public Int16 yrel;
        }
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /* Joystick hat position change event struct (event.jhat.*) */
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_JoyHatEvent
        {
            public SDL_EventType type;
            public UInt32 timestamp;
            public Int32 which; /* SDL_JoystickID */
            public byte hat; /* index of the hat */
            public byte hatValue; /* value, lolC# */
            private byte padding1;
            private byte padding2;
        }
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /* Joystick button event structure (event.jbutton.*) */
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_JoyButtonEvent
        {
            public SDL_EventType type;
            public UInt32 timestamp;
            public Int32 which; /* SDL_JoystickID */
            public byte button;
            public byte state; /* SDL_PRESSED or SDL_RELEASED */
            private byte padding1;
            private byte padding2;
        }
#pragma warning restore 0169

        /* Joystick device event structure (event.jdevice.*) */
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_JoyDeviceEvent
        {
            public SDL_EventType type;
            public UInt32 timestamp;
            public Int32 which; /* SDL_JoystickID */
        }

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /* Game controller axis motion event (event.caxis.*) */
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_ControllerAxisEvent
        {
            public SDL_EventType type;
            public UInt32 timestamp;
            public Int32 which; /* SDL_JoystickID */
            public byte axis;
            private byte padding1;
            private byte padding2;
            private byte padding3;
            public Int16 axisValue; /* value, lolC# */
            private UInt16 padding4;
        }
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /* Game controller button event (event.cbutton.*) */
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_ControllerButtonEvent
        {
            public SDL_EventType type;
            public UInt32 timestamp;
            public Int32 which; /* SDL_JoystickID */
            public byte button;
            public byte state;
            private byte padding1;
            private byte padding2;
        }
#pragma warning restore 0169

        /* Game controller device event (event.cdevice.*) */
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_ControllerDeviceEvent
        {
            public SDL_EventType type;
            public UInt32 timestamp;
            public Int32 which;    /* joystick id for ADDED,
                         * else instance id
                         */
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_TouchFingerEvent
        {
            public UInt32 type;
            public UInt32 timestamp;
            public Int64 touchId; // SDL_TouchID
            public Int64 fingerId; // SDL_GestureID
            public float x;
            public float y;
            public float dx;
            public float dy;
            public float pressure;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_MultiGestureEvent
        {
            public UInt32 type;
            public UInt32 timestamp;
            public Int64 touchId; // SDL_TouchID
            public float dTheta;
            public float dDist;
            public float x;
            public float y;
            public UInt16 numFingers;
            public UInt16 padding;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_DollarGestureEvent
        {
            public UInt32 type;
            public UInt32 timestamp;
            public Int64 touchId; // SDL_TouchID
            public Int64 gestureId; // SDL_GestureID
            public UInt32 numFingers;
            public float error;
            public float x;
            public float y;
        }

        /* File open request by system (event.drop.*), disabled by
         * default
         */
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_DropEvent
        {
            public SDL_EventType type;
            public UInt32 timestamp;
            public IntPtr file; /* char* filename, to be freed */
        }

        /* The "quit requested" event */
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_QuitEvent
        {
            public SDL_EventType type;
            public UInt32 timestamp;
        }

        /* A user defined event (event.user.*) */
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_UserEvent
        {
            public UInt32 type;
            public UInt32 timestamp;
            public UInt32 windowID;
            public Int32 code;
            public IntPtr data1; /* user-defined */
            public IntPtr data2; /* user-defined */
        }

        /* A video driver dependent event (event.syswm.*), disabled */
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_SysWMEvent
        {
            public SDL_EventType type;
            public UInt32 timestamp;
            public IntPtr msg; /* SDL_SysWMmsg*, system-dependent*/
        }

        /* General event structure */
        // C# doesn't do unions, so we do this ugly thing. */
        [StructLayout(LayoutKind.Explicit)]
        public struct SDL_Event
        {
            [FieldOffset(0)]
            public SDL_EventType type;
            [FieldOffset(0)]
            public SDL_WindowEvent window;
            [FieldOffset(0)]
            public SDL_KeyboardEvent key;
            [FieldOffset(0)]
            public SDL_TextEditingEvent edit;
            [FieldOffset(0)]
            public SDL_TextInputEvent text;
            [FieldOffset(0)]
            public SDL_MouseMotionEvent motion;
            [FieldOffset(0)]
            public SDL_MouseButtonEvent button;
            [FieldOffset(0)]
            public SDL_MouseWheelEvent wheel;
            [FieldOffset(0)]
            public SDL_JoyAxisEvent jaxis;
            [FieldOffset(0)]
            public SDL_JoyBallEvent jball;
            [FieldOffset(0)]
            public SDL_JoyHatEvent jhat;
            [FieldOffset(0)]
            public SDL_JoyButtonEvent jbutton;
            [FieldOffset(0)]
            public SDL_JoyDeviceEvent jdevice;
            [FieldOffset(0)]
            public SDL_ControllerAxisEvent caxis;
            [FieldOffset(0)]
            public SDL_ControllerButtonEvent cbutton;
            [FieldOffset(0)]
            public SDL_ControllerDeviceEvent cdevice;
            [FieldOffset(0)]
            public SDL_QuitEvent quit;
            [FieldOffset(0)]
            public SDL_UserEvent user;
            [FieldOffset(0)]
            public SDL_SysWMEvent syswm;
            [FieldOffset(0)]
            public SDL_TouchFingerEvent tfinger;
            [FieldOffset(0)]
            public SDL_MultiGestureEvent mgesture;
            [FieldOffset(0)]
            public SDL_DollarGestureEvent dgesture;
            [FieldOffset(0)]
            public SDL_DropEvent drop;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int SDL_EventFilter(
            IntPtr userdata, // void*
            IntPtr sdlevent // SDL_Event* event, lolC#
        );

        /* Pump the event loop, getting events from the input devices*/
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_PumpEvents();

        public enum SDL_eventaction
        {
            SDL_ADDEVENT,
            SDL_PEEKEVENT,
            SDL_GETEVENT
        }

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_PeepEvents(
            [Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 1)]
                SDL_Event[] events,
            int numevents,
            SDL_eventaction action,
            SDL_EventType minType,
            SDL_EventType maxType
        );

        /* Checks to see if certain events are in the event queue */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_HasEvent(SDL_EventType type);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_HasEvents(
            SDL_EventType minType,
            SDL_EventType maxType
        );

        /* Clears events from the event queue */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FlushEvent(SDL_EventType type);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FlushEvents(
            SDL_EventType min,
            SDL_EventType max
        );

        /* Polls for currently pending events */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_PollEvent(out SDL_Event _event);

        /* Waits indefinitely for the next event */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_WaitEvent(out SDL_Event _event);

        /* Waits until the specified timeout (in ms) for the next event
         */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_WaitEventTimeout(out SDL_Event _event, int timeout);

        /* Add an event to the event queue */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_PushEvent(ref SDL_Event _event);

        /* userdata refers to a void* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetEventFilter(
            SDL_EventFilter filter,
            IntPtr userdata
        );

        /* userdata refers to a void* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_GetEventFilter(
            out SDL_EventFilter filter,
            out IntPtr userdata
        );

        /* userdata refers to a void* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_AddEventWatch(
            SDL_EventFilter filter,
            IntPtr userdata
        );

        /* userdata refers to a void* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DelEventWatch(
            SDL_EventFilter filter,
            IntPtr userdata
        );

        /* userdata refers to a void* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FilterEvents(
            SDL_EventFilter filter,
            IntPtr userdata
        );

        /* These are for SDL_EventState() */
        public const int SDL_QUERY =         -1;
        public const int SDL_IGNORE =         0;
        public const int SDL_DISABLE =        0;
        public const int SDL_ENABLE =         1;

        /* This function allows you to enable/disable certain events */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_EventState(SDL_EventType type, int state);

        /* Get the state of an event */
        public static byte SDL_GetEventState(SDL_EventType type)
        {
            return SDL_EventState(type, SDL_QUERY);
        }

        /* Allocate a set of user-defined events */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 SDL_RegisterEvents(int numevents);
        #endregion
    }
}
