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
        #region SDL_audio.h

        public const ushort SDL_AUDIO_MASK_BITSIZE =    0xFF;
        public const ushort SDL_AUDIO_MASK_DATATYPE =    (1 << 8);
        public const ushort SDL_AUDIO_MASK_ENDIAN =    (1 << 12);
        public const ushort SDL_AUDIO_MASK_SIGNED =    (1 << 15);

        public static ushort SDL_AUDIO_BITSIZE(ushort x)
        {
            return (ushort) (x & SDL_AUDIO_MASK_BITSIZE);
        }

        public static bool SDL_AUDIO_ISFLOAT(ushort x)
        {
            return (x & SDL_AUDIO_MASK_DATATYPE) != 0;
        }

        public static bool SDL_AUDIO_ISBIGENDIAN(ushort x)
        {
            return (x & SDL_AUDIO_MASK_ENDIAN) != 0;
        }

        public static bool SDL_AUDIO_ISSIGNED(ushort x)
        {
            return (x & SDL_AUDIO_MASK_SIGNED) != 0;
        }

        public static bool SDL_AUDIO_ISINT(ushort x)
        {
            return (x & SDL_AUDIO_MASK_DATATYPE) == 0;
        }

        public static bool SDL_AUDIO_ISLITTLEENDIAN(ushort x)
        {
            return (x & SDL_AUDIO_MASK_ENDIAN) == 0;
        }

        public static bool SDL_AUDIO_ISUNSIGNED(ushort x)
        {
            return (x & SDL_AUDIO_MASK_SIGNED) == 0;
        }

        public const ushort AUDIO_U8 =        0x0008;
        public const ushort AUDIO_S8 =        0x8008;
        public const ushort AUDIO_U16LSB =    0x0010;
        public const ushort AUDIO_S16LSB =    0x8010;
        public const ushort AUDIO_U16MSB =    0x1010;
        public const ushort AUDIO_S16MSB =    0x9010;
        public const ushort AUDIO_U16 =        AUDIO_U16LSB;
        public const ushort AUDIO_S16 =        AUDIO_S16LSB;
        public const ushort AUDIO_S32LSB =    0x8020;
        public const ushort AUDIO_S32MSB =    0x9020;
        public const ushort AUDIO_S32 =        AUDIO_S32LSB;
        public const ushort AUDIO_F32LSB =    0x8120;
        public const ushort AUDIO_F32MSB =    0x9120;
        public const ushort AUDIO_F32 =        AUDIO_F32LSB;

        public static readonly ushort AUDIO_U16SYS =
            BitConverter.IsLittleEndian ? AUDIO_U16LSB : AUDIO_U16MSB;
        public static readonly ushort AUDIO_S16SYS =
            BitConverter.IsLittleEndian ? AUDIO_S16LSB : AUDIO_S16MSB;
        public static readonly ushort AUDIO_S32SYS =
            BitConverter.IsLittleEndian ? AUDIO_S32LSB : AUDIO_S32MSB;
        public static readonly ushort AUDIO_F32SYS =
            BitConverter.IsLittleEndian ? AUDIO_F32LSB : AUDIO_F32MSB;

        public const uint SDL_AUDIO_ALLOW_FREQUENCY_CHANGE =    0x00000001;
        public const uint SDL_AUDIO_ALLOW_FORMAT_CHANGE =    0x00000001;
        public const uint SDL_AUDIO_ALLOW_CHANNELS_CHANGE =    0x00000001;
        public const uint SDL_AUDIO_ALLOW_ANY_CHANGE = (
            SDL_AUDIO_ALLOW_FREQUENCY_CHANGE |
            SDL_AUDIO_ALLOW_FORMAT_CHANGE |
            SDL_AUDIO_ALLOW_CHANNELS_CHANGE
        );

        public const int SDL_MIX_MAXVOLUME = 128;

        public enum SDL_AudioStatus
        {
            SDL_AUDIO_STOPPED,
            SDL_AUDIO_PLAYING,
            SDL_AUDIO_PAUSED
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_AudioSpec
        {
            public int freq;
            public ushort format; // SDL_AudioFormat
            public byte channels;
            public byte silence;
            public ushort samples;
            public uint size;
            public SDL_AudioCallback callback;
            public IntPtr userdata; // void*
        }

        /// <summary>
        /// This function is called when the audio device needs more data.
        /// </summary>
        /// <param name="userdata">An application-specific parameter saved in the SDL_AudioSpec structure. Refers to a void*.</param>
        /// <param name="stream">A pointer to the audio data buffer. Refers to a Uint8.</param>
        /// <param name="len"></param>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SDL_AudioCallback(
            IntPtr userdata,
            IntPtr stream,
            int len
        );

        /* dev refers to an SDL_AudioDeviceID */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_AudioDeviceConnected(uint dev);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_AudioInit(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string driver_name
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_AudioQuit();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_CloseAudio();

        /* dev refers to an SDL_AudioDeviceID */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_CloseAudioDevice(uint dev);

        /* audio_buf refers to a malloc()'d buffer from SDL_LoadWAV */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeWAV(IntPtr audio_buf);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDL_GetAudioDeviceName(
            int index,
            int iscapture
        );

        /* dev refers to an SDL_AudioDeviceID */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_AudioStatus SDL_GetAudioDeviceStatus(
            uint dev
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDL_GetAudioDriver(int index);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_AudioStatus SDL_GetAudioStatus();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDL_GetCurrentAudioDriver();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumAudioDevices(int iscapture);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumAudioDrivers();

        /* audio_buf will refer to a malloc()'d byte buffer */
        /* THIS IS AN RWops FUNCTION! */
        [DllImport(nativeLibName, EntryPoint = "SDL_LoadWAV_RW", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_LoadWAV_RW(
            IntPtr src,
            int freesrc,
            ref SDL_AudioSpec spec,
            out IntPtr audio_buf,
            out uint audio_len
        );
        public static SDL_AudioSpec SDL_LoadWAV(
            string file,
            ref SDL_AudioSpec spec,
            out IntPtr audio_buf,
            out uint audio_len
        ) {
            SDL_AudioSpec result;
            IntPtr rwops = INTERNAL_SDL_RWFromFile(file, "rb");
            IntPtr result_ptr = INTERNAL_SDL_LoadWAV_RW(
                rwops,
                1,
                ref spec,
                out audio_buf,
                out audio_len
            );
            result = (SDL_AudioSpec) Marshal.PtrToStructure(
                result_ptr,
                typeof(SDL_AudioSpec)
            );
            return result;
        }

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LockAudio();

        /* dev refers to an SDL_AudioDeviceID */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LockAudioDevice(uint dev);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MixAudio(
            [Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)]
                byte[] dst,
            [In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)]
                byte[] src,
            uint len,
            int volume
        );

        /* format refers to an SDL_AudioFormat */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MixAudioFormat(
            [Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)]
                byte[] dst,
            [In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)]
                byte[] src,
            ushort format,
            uint len,
            int volume
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_OpenAudio(
            ref SDL_AudioSpec desired,
            out SDL_AudioSpec obtained
        );

        /* uint refers to an SDL_AudioDeviceID */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_OpenAudioDevice(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string device,
            int iscapture,
            ref SDL_AudioSpec desired,
            out SDL_AudioSpec obtained,
            int allowed_changes
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_PauseAudio(int pause_on);

        /* dev refers to an SDL_AudioDeviceID */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_PauseAudioDevice(
            uint dev,
            int pause_on
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockAudio();

        /* dev refers to an SDL_AudioDeviceID */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockAudioDevice(uint dev);

        /* dev refers to an SDL_AudioDeviceID, data to a void* */
        /* Only available in 2.0.4 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_QueueAudio(
            uint dev,
            IntPtr data,
            UInt32 len
        );

        /* dev refers to an SDL_AudioDeviceID, data to a void* */
        /* Only available in 2.0.5 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_DequeueAudio(
            uint dev,
            IntPtr data,
            uint len
        );

        /* dev refers to an SDL_AudioDeviceID */
        /* Only available in 2.0.4 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 SDL_GetQueuedAudioSize(uint dev);

        /* dev refers to an SDL_AudioDeviceID */
        /* Only available in 2.0.4 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ClearQueuedAudio(uint dev);

        #endregion
    }
}
