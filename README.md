# AV-evasion
AV evasion technique practice with a regular csharp shellcode. 

Project 1: ShellYaLater I've set up separate Evasion Class with file name "SherryChristmas" where the techniques are present. You can reference each one individually in your main class. You will need to obfuscate the names in your project.
Right now I am testing on an XOR encoded payload (not encoded through msfvenom), but that will change in the future when I add a separate encoding and decoding project.

Project 2: Encoding & decoding function

Project 3: MerryHollows with D/Invoke.

## To-Do

- [x] Look into using `NtSetInformationThread`
- [ ] `GetLocalTime()`
- [ ] `GetSystemTime()`
- [ ] `ZwGetTickCount()` / `KiGetTickCount()`
- [ ] Manual Unhooking for EDR bypassing (NtOpenProcess, NtReadVirtualMemory)
- [ ] Combine anti-debugger functions into NtSetInformationThread
- [ ] Separate payload encoding project added (XOR,Caesar,AES256)
- [ ] Decoding classes added in ShellYaLater for easier calling in main
- [ ] Separate shell code runner project with D/Invoke (currently using P/Invoke which will get loaded into the IAT)
- [ ] Steps for variable obfuscation (TBD on this, may just use babel for ease of use?)
- [ ] AMSI Bypass techniques
- [ ] Add in Process Hollowing Technique called MerryHollows with d/invoke
- [ ] MerryHollows with d/invoke
- [x] Delegate Function obfuscation in ShellYaLater
