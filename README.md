# DotMachine
A toy virtual machine based on the blog post  https://felixangell.com/blogs/virtual-machine-in-c

## operations:
- [x] PUSH
- [x] POP
- [ ] MOV
- [x] ADD
- [x] MUL
- [ ] DIV
- [x] SUB
- [x] XOR 
- [x] CMP  (Compare)
- [ ] JMP  (Jump)
- [ ] GT   (Greater Than)
- [ ] LT   (Less Than)
- [ ] HTL  (End of program)
- [ ] CALL (Call a O.S. function)

# registers:
- [x] EAX (General)
- [X] EBX (General)
- [X] ECX (General)
- [X] SP  (Stack Pointer)
- [X] IP  (Instruction Pointer)
- [X] ZF  (Zero Flag)

# stack:
- [x] 256  positions
- [ ] 512  positions
- [ ] 1024 positions

# TODO:
- [ ] Implements CLI
- [ ] Read from a file (.asm or .dotm)
- [ ] Ignore comments
- [ ] Labels

# Use example:
```
  ; Add two numbers
  PUSH 5
  PUSH 5
  ADD
  POP
  HLT ; End of program
```
