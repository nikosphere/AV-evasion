# AV-evasion
AV evasion technique practice with a regular csharp shellcode. I've set up separate Evasion Class with file name "SherryChristmas" where the techniques are present. You can each one individually in your main class. Good for doing false pos and false neg testing in antiscan.me while creating payloads. Test on your own!
Right now I am testing on an XOR encoded payload, but that will change in the future.

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
- [ ] Add in Process Hollowing Technique called MerryHollows with p/invoke
- [ ] MerryHollows with d/invoke
- [x] Delegate Function obfuscation
