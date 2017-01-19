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

namespace TS.SDL2.SDL2_net
{
    public static class SDL_net
    {
        #region SDL2# Variables

        /* Used by DllImport to load the native library. */
        private const string nativeLibName = "SDL2_net.dll";

        #endregion
        
        #region SDL_net.h

        /* Similar to the headers, this is the version we're expecting to be
         * running with. You will likely want to check this somewhere in your
         * program!
         */
        public const int SDL_NET_MAJOR_VERSION =    2;
        public const int SDL_NET_MINOR_VERSION =    0;
        public const int SDL_NET_PATCHLEVEL =       1;

        public static void SDL_NET_VERSION(out SDL.SDL_version X)
        {
            X.major = SDL_NET_MAJOR_VERSION;
            X.minor = SDL_NET_MINOR_VERSION;
            X.patch = SDL_NET_PATCHLEVEL;
        }
        
        [DllImport(nativeLibName, EntryPoint = "SDLNet_Linked_Version", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDLNet_Linked_Version();
        public static SDL.SDL_version SDLNet_Linked_Version()
        {
            SDL.SDL_version result;
            IntPtr result_ptr = INTERNAL_SDLNet_Linked_Version();
            result = (SDL.SDL_version) Marshal.PtrToStructure(
                result_ptr,
                typeof(SDL.SDL_version)
            );
            return result;
        }
        
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDLNet_Init();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDLNet_Quit();

        [StructLayout(LayoutKind.Sequential)]
        public struct IPaddress
        {
            public uint host;
            public ushort port;
        }
        
        public const uint INADDR_ANY       = 0x00000000;
        public const uint INADDR_NONE      = 0xFFFFFFFF;
        public const uint INADDR_LOOPBACK  = 0x7f000001;
        public const uint INADDR_BROADCAST = 0xFFFFFFFF;

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDLNet_ResolveHost(
            out IPaddress address,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
            string host, 
            ushort port);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDLNet_ResolveIP(ref IPaddress ip);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDLNet_ResolveIP(IntPtr ip);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDLNet_GetLocalAddresses(
            [Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct)]
                IPaddress[] addresses,
            int maxcount
           );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDLNet_TCP_Open(ref IPaddress ip);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDLNet_TCP_Open(IntPtr ip);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDLNet_TCP_Accept(IntPtr server);

        /* return is IPaddress */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDLNet_TCP_GetPeerAddress(IntPtr sock);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDLNet_TCP_Send(IntPtr sock, IntPtr data, int len);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDLNet_TCP_Recv(IntPtr sock, IntPtr data, int maxlen);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDLNet_TCP_Close(IntPtr sock);

        public const int SDLNET_MAX_UDPCHANNELS = 32;
        
        public const int SDLNET_MAX_UDPADDRESSES = 4;
        
        [StructLayout(LayoutKind.Sequential)]
        public struct UDPpacket
        {
            public int channel;
            public IntPtr data; //Uint8*
            public int len;
            public int maxlen;
            public int status;
            public IntPtr address; //IPaddress
        }
        
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDLNet_AllocPacket(int size);
        
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDLNet_ResizePacket(IntPtr packet, int newsize);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDLNet_FreePacket(IntPtr packet);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDLNet_AllocPacketV(int howmany, int size);
        
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDLNet_FreePacketV(IntPtr packetV);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDLNet_UDP_Open(ushort port);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDLNet_UDP_SetPacketLoss(IntPtr sock, int percent);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int  SDLNet_UDP_Bind(IntPtr sock, int channel, ref IPaddress address);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int  SDLNet_UDP_Bind(IntPtr sock, int channel, IntPtr address);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDLNet_UDP_Unbind(IntPtr sock, int channel);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDLNet_UDP_GetPeerAddress(IntPtr sock, int channel);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDLNet_UDP_SendV(IntPtr sock, IntPtr packets, int npackets);
        
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDLNet_UDP_Send(IntPtr sock, int channel, IntPtr packet);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDLNet_UDP_RecvV(IntPtr sock, int channel, IntPtr packets);
        
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDLNet_UDP_Recv(IntPtr sock, int channel, IntPtr packet);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDLNet_UDP_Close(IntPtr sock);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDLNet_AllocSocketSet(IntPtr sock);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDLNet_AddSocket(IntPtr @set, IntPtr sock);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDLNet_TCP_AddSocket(IntPtr @set, IntPtr sock);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDLNet_UDP_AddSocket(IntPtr @set, IntPtr sock);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDLNet_DelSocket(IntPtr @set, IntPtr sock);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDLNet_TCP_DelSocket(IntPtr @set, IntPtr sock);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDLNet_UDP_DelSocket(IntPtr @set, IntPtr sock);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDLNet_CheckSockets(IntPtr @set, uint timeout);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDLNet_SocketReady(IntPtr sock);
        
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDLNet_FreeSocketSet(IntPtr @set);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDLNet_SetError(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string fmt,
            __arglist
        );
        
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string SDLNet_GetError();
        
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDLNet_Write16(ushort value, IntPtr areap);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDLNet_Write32(uint value, IntPtr areap);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDLNet_Read16(IntPtr areap);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDLNet_Read32(IntPtr areap);
        
        #endregion
    }
}
