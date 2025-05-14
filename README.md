# AV-evasion
AV evasion technique practice. I've set up separate Evasion Class with file name "SherryChristmas" where the techniques are present. You can each one individually in your main class. Good for doing false pos and false neg testing in antiscan.me while creating payloads. Test on your own!
Right now I am testing on an XOR encoded payload, but that will change in the future.

## To-Do

- [x] Look into using `NtSetInformationThread`
- [ ] `GetLocalTime()`
- [ ] `GetSystemTime()`
- [ ] `ZwGetTickCount()` / `KiGetTickCount()`
- [ ] Separate payload encoding project added
- [ ] Decoding classes added in the main project
