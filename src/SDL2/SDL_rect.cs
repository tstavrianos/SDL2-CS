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
        #region SDL_rect.h

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Point: IEquatable<SDL_Point>
        {
            public int x;
            public int y;
            
            #region EXTRAS
            public bool Equals(SDL_Point other)
            {
                return x == other.x && y == other.y;
            }
            
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }

                return obj is SDL_Point && this.Equals((SDL_Point)obj);
            }
            
            public static bool operator ==(SDL_Point a, SDL_Point b)
            {
                return a.Equals(b);
            }
            
            public static bool operator !=(SDL_Point a, SDL_Point b)
            {
                return !a.Equals(b);
            }
            
            public SDL_Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            
            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = 17; 
                    hashCode = (this.x == 0 ? 0 : this.x.GetHashCode()) + hashCode * 31;
                    hashCode = (this.y == 0 ? 0 : this.y.GetHashCode()) + hashCode * 31;
                    return hashCode;
                }
            }
            #endregion
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Rect: IEquatable<SDL_Rect>
        {
            public int x;
            public int y;
            public int w;
            public int h;
            
            #region EXTRAS
            public SDL_Rect(int x, int y, int w, int h)
            {
                this.x = x;
                this.y = y;
                this.w = w;
                this.h = h;
            }

            public bool PointInRect(SDL_Point p)
            {
                return (p.x >= this.x) && (p.x < (this.x + this.w)) && (p.y >= this.y) && (p.y < (this.y + this.h));
            }
            
            public bool IsEmpty()
            {
                return (this.w <= 0) || (this.h <= 0);
            }
            
            public bool Equals(SDL_Rect other)
            {
                return (this.x == other.x) && (this.y == other.y) && (this.w == other.w) && (this.h == other.h);
            }
            
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }

                return obj is SDL_Rect && this.Equals((SDL_Rect)obj);
            }
            
            public static bool operator ==(SDL_Rect a, SDL_Rect b)
            {
                return a.Equals(b);
            }
            
            public static bool operator !=(SDL_Rect a, SDL_Rect b)
            {
                return !a.Equals(b);
            }
            
            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = 17; 
                    hashCode = (this.x == 0 ? 0 : this.x.GetHashCode()) + hashCode * 31;
                    hashCode = (this.y == 0 ? 0 : this.y.GetHashCode()) + hashCode * 31;
                    hashCode = (this.w == 0 ? 0 : this.w.GetHashCode()) + hashCode * 31;
                    hashCode = (this.h == 0 ? 0 : this.h.GetHashCode()) + hashCode * 31;
                    return hashCode;
                }
            }

            #if false
            public static bool HasIntersection(SDL_Rect a, SDL_Rect b)
            {
                return SDL_HasIntersection(ref a, ref b) == SDL_bool.SDL_TRUE;
            }

            public bool HasIntersection(SDL_Rect b)
            {
                return HasIntersection(this, b);
            }

            public SDL_Rect IntersectRect(SDL_Rect b)
            {
                SDL_Rect c;                
                if (IntersectRect(this, b, out c))
                {
                    return c;
                }
                return new SDL_Rect();
            }
            
            public bool IntersectRect(SDL_Rect a, SDL_Rect b, out SDL_Rect c)
            {
                return SDL_IntersectRect(ref a, ref b, out c) == SDL_bool.SDL_TRUE;
            }

            public SDL_Rect UnionRect(SDL_Rect b)
            {
                SDL_Rect c;                
                UnionRect(this, b, out c);
                return c;
            }
            
            public void UnionRect(SDL_Rect a, SDL_Rect b, out SDL_Rect c)
            {
                SDL_UnionRect(ref a, ref b, out c);
            }
            #endif
            #endregion EXTRAS
        }

        /* Only available in 2.0.4 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_PointInRect(ref SDL_Point p, ref SDL_Rect r);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_EnclosePoints(
            [In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 1)]
                SDL_Point[] points,
            int count,
            ref SDL_Rect clip,
            out SDL_Rect result
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_HasIntersection(
            ref SDL_Rect A,
            ref SDL_Rect B
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_IntersectRect(
            ref SDL_Rect A,
            ref SDL_Rect B,
            out SDL_Rect result
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_IntersectRectAndLine(
            ref SDL_Rect rect,
            ref int X1,
            ref int Y1,
            ref int X2,
            ref int Y2
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_RectEmpty(ref SDL_Rect rect);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_RectEquals(
            ref SDL_Rect A,
            ref SDL_Rect B
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnionRect(
            ref SDL_Rect A,
            ref SDL_Rect B,
            out SDL_Rect result
        );

        #endregion
    }
}
