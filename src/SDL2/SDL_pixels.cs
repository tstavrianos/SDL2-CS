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
        #region SDL_pixels.h

        public static uint SDL_DEFINE_PIXELFOURCC(byte A, byte B, byte C, byte D)
        {
            return SDL_FOURCC(A, B, C, D);
        }

        public static uint SDL_DEFINE_PIXELFORMAT(
            SDL_PIXELTYPE_ENUM type,
            SDL_PIXELORDER_ENUM order,
            SDL_PACKEDLAYOUT_ENUM layout,
            byte bits,
            byte bytes
        ) {
            return (uint) (
                (1 << 28) |
                (((byte) type) << 24) |
                (((byte) order) << 20) |
                (((byte) layout) << 16) |
                (bits << 8) |
                (bytes)
            );
        }

        public static byte SDL_PIXELFLAG(uint X)
        {
            return (byte) ((X >> 28) & 0x0F);
        }

        public static byte SDL_PIXELTYPE(uint X)
        {
            return (byte) ((X >> 24) & 0x0F);
        }

        public static byte SDL_PIXELORDER(uint X)
        {
            return (byte) ((X >> 20) & 0x0F);
        }

        public static byte SDL_PIXELLAYOUT(uint X)
        {
            return (byte) ((X >> 16) & 0x0F);
        }

        public static byte SDL_BITSPERPIXEL(uint X)
        {
            return (byte) ((X >> 8) & 0xFF);
        }

        public static byte SDL_BYTESPERPIXEL(uint X)
        {
            if (SDL_ISPIXELFORMAT_FOURCC(X))
            {
                if (    (X == SDL_PIXELFORMAT_YUY2) ||
                        (X == SDL_PIXELFORMAT_UYVY) ||
                        (X == SDL_PIXELFORMAT_YVYU)    )
                {
                    return 2;
                }
                return 1;
            }
            return (byte) (X & 0xFF);
        }

        public static bool SDL_ISPIXELFORMAT_INDEXED(uint format)
        {
            if (SDL_ISPIXELFORMAT_FOURCC(format))
            {
                return false;
            }
            SDL_PIXELTYPE_ENUM pType =
                    (SDL_PIXELTYPE_ENUM) SDL_PIXELTYPE(format);
            return (
                pType == SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX1 ||
                pType == SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX4 ||
                pType == SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX8
            );
        }

        public static bool SDL_ISPIXELFORMAT_ALPHA(uint format)
        {
            if (SDL_ISPIXELFORMAT_FOURCC(format))
            {
                return false;
            }
            SDL_PIXELORDER_ENUM pOrder =
                    (SDL_PIXELORDER_ENUM) SDL_PIXELORDER(format);
            return (
                pOrder == SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ARGB ||
                pOrder == SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_RGBA ||
                pOrder == SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ABGR ||
                pOrder == SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_BGRA
            );
        }

        public static bool SDL_ISPIXELFORMAT_FOURCC(uint format)
        {
            return (format == 0) && (SDL_PIXELFLAG(format) != 1);
        }

        public enum SDL_PIXELTYPE_ENUM
        {
            SDL_PIXELTYPE_UNKNOWN,
            SDL_PIXELTYPE_INDEX1,
            SDL_PIXELTYPE_INDEX4,
            SDL_PIXELTYPE_INDEX8,
            SDL_PIXELTYPE_PACKED8,
            SDL_PIXELTYPE_PACKED16,
            SDL_PIXELTYPE_PACKED32,
            SDL_PIXELTYPE_ARRAYU8,
            SDL_PIXELTYPE_ARRAYU16,
            SDL_PIXELTYPE_ARRAYU32,
            SDL_PIXELTYPE_ARRAYF16,
            SDL_PIXELTYPE_ARRAYF32
        }

        public enum SDL_PIXELORDER_ENUM
        {
            /* BITMAPORDER */
            SDL_BITMAPORDER_NONE,
            SDL_BITMAPORDER_4321,
            SDL_BITMAPORDER_1234,
            /* PACKEDORDER */
            SDL_PACKEDORDER_NONE = 0,
            SDL_PACKEDORDER_XRGB,
            SDL_PACKEDORDER_RGBX,
            SDL_PACKEDORDER_ARGB,
            SDL_PACKEDORDER_RGBA,
            SDL_PACKEDORDER_XBGR,
            SDL_PACKEDORDER_BGRX,
            SDL_PACKEDORDER_ABGR,
            SDL_PACKEDORDER_BGRA,
            /* ARRAYORDER */
            SDL_ARRAYORDER_NONE = 0,
            SDL_ARRAYORDER_RGB,
            SDL_ARRAYORDER_RGBA,
            SDL_ARRAYORDER_ARGB,
            SDL_ARRAYORDER_BGR,
            SDL_ARRAYORDER_BGRA,
            SDL_ARRAYORDER_ABGR
        }

        public enum SDL_PACKEDLAYOUT_ENUM
        {
            SDL_PACKEDLAYOUT_NONE,
            SDL_PACKEDLAYOUT_332,
            SDL_PACKEDLAYOUT_4444,
            SDL_PACKEDLAYOUT_1555,
            SDL_PACKEDLAYOUT_5551,
            SDL_PACKEDLAYOUT_565,
            SDL_PACKEDLAYOUT_8888,
            SDL_PACKEDLAYOUT_2101010,
            SDL_PACKEDLAYOUT_1010102
        }

        public static readonly uint SDL_PIXELFORMAT_UNKNOWN = 0;
        public static readonly uint SDL_PIXELFORMAT_INDEX1LSB =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX1,
                SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321,
                0,
                1, 0
            );
        public static readonly uint SDL_PIXELFORMAT_INDEX1MSB =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX1,
                SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_1234,
                0,
                1, 0
            );
        public static readonly uint SDL_PIXELFORMAT_INDEX4LSB =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX4,
                SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321,
                0,
                4, 0
            );
        public static readonly uint SDL_PIXELFORMAT_INDEX4MSB =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX4,
                SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_1234,
                0,
                4, 0
            );
        public static readonly uint SDL_PIXELFORMAT_INDEX8 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX8,
                0,
                0,
                8, 1
            );
        public static readonly uint SDL_PIXELFORMAT_RGB332 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED8,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_XRGB,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_332,
                8, 1
            );
        public static readonly uint SDL_PIXELFORMAT_RGB444 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_XRGB,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_4444,
                12, 2
            );
        public static readonly uint SDL_PIXELFORMAT_RGB555 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_XRGB,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_1555,
                15, 2
            );
        public static readonly uint SDL_PIXELFORMAT_BGR555 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX1,
                SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_1555,
                15, 2
            );
        public static readonly uint SDL_PIXELFORMAT_ARGB4444 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ARGB,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_4444,
                16, 2
            );
        public static readonly uint SDL_PIXELFORMAT_RGBA4444 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_RGBA,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_4444,
                16, 2
            );
        public static readonly uint SDL_PIXELFORMAT_ABGR4444 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ABGR,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_4444,
                16, 2
            );
        public static readonly uint SDL_PIXELFORMAT_BGRA4444 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_BGRA,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_4444,
                16, 2
            );
        public static readonly uint SDL_PIXELFORMAT_ARGB1555 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ARGB,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_1555,
                16, 2
            );
        public static readonly uint SDL_PIXELFORMAT_RGBA5551 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_RGBA,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_5551,
                16, 2
            );
        public static readonly uint SDL_PIXELFORMAT_ABGR1555 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ABGR,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_1555,
                16, 2
            );
        public static readonly uint SDL_PIXELFORMAT_BGRA5551 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_BGRA,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_5551,
                16, 2
            );
        public static readonly uint SDL_PIXELFORMAT_RGB565 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_XRGB,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_565,
                16, 2
            );
        public static readonly uint SDL_PIXELFORMAT_BGR565 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_XBGR,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_565,
                16, 2
            );
        public static readonly uint SDL_PIXELFORMAT_RGB24 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_ARRAYU8,
                SDL_PIXELORDER_ENUM.SDL_ARRAYORDER_RGB,
                0,
                24, 3
            );
        public static readonly uint SDL_PIXELFORMAT_BGR24 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_ARRAYU8,
                SDL_PIXELORDER_ENUM.SDL_ARRAYORDER_BGR,
                0,
                24, 3
            );
        public static readonly uint SDL_PIXELFORMAT_RGB888 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_XRGB,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888,
                24, 4
            );
        public static readonly uint SDL_PIXELFORMAT_RGBX8888 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_RGBX,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888,
                24, 4
            );
        public static readonly uint SDL_PIXELFORMAT_BGR888 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_XBGR,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888,
                24, 4
            );
        public static readonly uint SDL_PIXELFORMAT_BGRX8888 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_BGRX,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888,
                24, 4
            );
        public static readonly uint SDL_PIXELFORMAT_ARGB8888 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ARGB,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888,
                32, 4
            );
        public static readonly uint SDL_PIXELFORMAT_RGBA8888 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_RGBA,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888,
                32, 4
            );
        public static readonly uint SDL_PIXELFORMAT_ABGR8888 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ABGR,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888,
                32, 4
            );
        public static readonly uint SDL_PIXELFORMAT_BGRA8888 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_BGRA,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888,
                32, 4
            );
        public static readonly uint SDL_PIXELFORMAT_ARGB2101010 =
            SDL_DEFINE_PIXELFORMAT(
                SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32,
                SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ARGB,
                SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_2101010,
                32, 4
            );
        public static readonly uint SDL_PIXELFORMAT_YV12 =
            SDL_DEFINE_PIXELFOURCC(
                (byte) 'Y', (byte) 'V', (byte) '1', (byte) '2'
            );
        public static readonly uint SDL_PIXELFORMAT_IYUV =
            SDL_DEFINE_PIXELFOURCC(
                (byte) 'I', (byte) 'Y', (byte) 'U', (byte) 'V'
            );
        public static readonly uint SDL_PIXELFORMAT_YUY2 =
            SDL_DEFINE_PIXELFOURCC(
                (byte) 'Y', (byte) 'U', (byte) 'Y', (byte) '2'
            );
        public static readonly uint SDL_PIXELFORMAT_UYVY =
            SDL_DEFINE_PIXELFOURCC(
                (byte) 'U', (byte) 'Y', (byte) 'V', (byte) 'Y'
            );
        public static readonly uint SDL_PIXELFORMAT_YVYU =
            SDL_DEFINE_PIXELFOURCC(
                (byte) 'Y', (byte) 'V', (byte) 'Y', (byte) 'U'
            );

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Color
        {
            public byte r;
            public byte g;
            public byte b;
            public byte a;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Palette
        {
            public int ncolors;
            public IntPtr colors;
            public int version;
            public int refcount;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_PixelFormat
        {
            public uint format;
            public IntPtr palette; // SDL_Palette*
            public byte BitsPerPixel;
            public byte BytesPerPixel;
            public uint Rmask;
            public uint Gmask;
            public uint Bmask;
            public uint Amask;
            public byte Rloss;
            public byte Gloss;
            public byte Bloss;
            public byte Aloss;
            public byte Rshift;
            public byte Gshift;
            public byte Bshift;
            public byte Ashift;
            public int refcount;
            public IntPtr next; // SDL_PixelFormat*
        }

        /* IntPtr refers to an SDL_PixelFormat* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_AllocFormat(uint pixel_format);

        /* IntPtr refers to an SDL_Palette* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_AllocPalette(int ncolors);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_CalculateGammaRamp(
            float gamma,
            [Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
                ushort[] ramp
        );

        /* format refers to an SDL_PixelFormat* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeFormat(IntPtr format);

        /* palette refers to an SDL_Palette* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreePalette(IntPtr palette);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDL_GetPixelFormatName(
            uint format
        );

        /* format refers to an SDL_PixelFormat* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetRGB(
            uint pixel,
            IntPtr format,
            out byte r,
            out byte g,
            out byte b
        );

        /* format refers to an SDL_PixelFormat* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetRGBA(
            uint pixel,
            IntPtr format,
            out byte r,
            out byte g,
            out byte b,
            out byte a
        );

        /* format refers to an SDL_PixelFormat* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_MapRGB(
            IntPtr format,
            byte r,
            byte g,
            byte b
        );

        /* format refers to an SDL_PixelFormat* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_MapRGBA(
            IntPtr format,
            byte r,
            byte g,
            byte b,
            byte a
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_MasksToPixelFormatEnum(
            int bpp,
            uint Rmask,
            uint Gmask,
            uint Bmask,
            uint Amask
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_PixelFormatEnumToMasks(
            uint format,
            out int bpp,
            out uint Rmask,
            out uint Gmask,
            out uint Bmask,
            out uint Amask
        );

        /* palette refers to an SDL_Palette* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetPaletteColors(
            IntPtr palette,
            [In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct)]
                SDL_Color[] colors,
            int firstcolor,
            int ncolors
        );

        /* format and palette refer to an SDL_PixelFormat* and SDL_Palette* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetPixelFormatPalette(
            IntPtr format,
            IntPtr palette
        );

        #endregion
    }
}
