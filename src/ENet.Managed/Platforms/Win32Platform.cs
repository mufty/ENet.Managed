using System;
using System.Runtime.InteropServices;

using ENet.Managed.Internal;

namespace ENet.Managed.Platforms
{
    public sealed class Win32Platform : Platform
    {
        public override byte[] GetENetBinaryBytes()
        {
            switch (RuntimeInformation.OSArchitecture)
            {
                case Architecture.X86:
                    return ENetBinariesResource.enet_win32_x86;

                case Architecture.X64:
                    return ENetBinariesResource.enet_win32_x86_64;

                case Architecture.Arm:
                    return ENetBinariesResource.enet_win32_arm;

                default:
                    ThrowHelper.ThrowCurrentArchitectureNotSupportedYet();
                    return null!;
            }
        }

        public override string GetENetBinaryName()
        {
            switch (RuntimeInformation.OSArchitecture)
            {
                case Architecture.X86:
                    return "enet-win32-x86.dll";

                case Architecture.X64:
                    return "enet-win32-x86-64.dll";

                case Architecture.Arm:
                    return "enet-win32-arm.dll";

                default:
                    ThrowHelper.ThrowCurrentArchitectureNotSupportedYet();
                    return null!;
            }
        }

        public override void FreeDynamicLibrary(IntPtr hModule) => Win32Api.FreeLibrary(hModule);
        public override IntPtr LoadDynamicLibrary(string dllPath) => Win32Api.LoadLibrary(dllPath);
        public override IntPtr GetDynamicLibraryProcedureAddress(IntPtr handle, string procName) => Win32Api.GetProcAddress(handle, procName);
    }
}
