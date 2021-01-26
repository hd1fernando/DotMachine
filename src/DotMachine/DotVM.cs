using System;
using System.Collections.Generic;

namespace VirtualMachine
{
    public class DotVM
    {
        Stack stack = new();

        Register SP = new(); // Stack  Pointer
        Register IP = new(); // Instruction Pointer

        public Register EAX = new();
        public Register EBX = new();
        public Register ECX = new();

        Register ZF = new();

        bool _running;
        string _strProgram;
        string[] _program;
        public DotVM(string program)
        {
            _strProgram = program;
        }

        public void Load()
        {
            _program = _strProgram
                  .Trim()
                  .Replace("\r", string.Empty)
                  .Replace("\n", string.Empty)
                  .Replace("\r\r", string.Empty)
                  .Replace(Environment.NewLine, string.Empty)
                  .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            _running = true;
            AddInstructions();
            StartDefaultsRegisters();
        }

        public void Exec()
        {
            while (_running)
            {
                Eval(Fetch());
                IncrementIp();
            }
        }

        void IncrementIp()
        {
            var ip = IP.Get();
            IP.Set(ip + 1);
        }

        int IncrementSP()
        {
            var sp = SP.Get() + 1;
            SP.Set(sp);
            return SP.Get();
        }

        void StartDefaultsRegisters()
        {
            SP.Set(-1);
            IP.Set(0);
        }

        string Fetch()
            => _program[IP.Get()];

        void Eval(string instruction)
        {
            InstructionsSet[instruction].Invoke();
        }


        Dictionary<string, Action> InstructionsSet = new();
        void AddInstructions()
        {
            InstructionsSet.Add("HLT", () => { _running = false; });
            InstructionsSet.Add("PUSH", PUSH);
            InstructionsSet.Add("POP", POP);
            InstructionsSet.Add("ADD", ADD);
        }

        void PUSH()
        {
            IncrementSP();
            var ip = IP.Get() + 1;
            stack[SP.Get()] = int.Parse(_program[ip]);
            IP.Set(ip);
        }

        int PopFromStack()
        {
            var sp = SP.Get();
            SP.Set(sp - 1);
            return stack[sp];
        }

        void POP()
        {
            int poppedValue = PopFromStack();

            EAX.Set(poppedValue);
        }

        void ADD()
        {
            EBX.Set(PopFromStack());
            ECX.Set(PopFromStack());
            EAX.Set(EBX.Get() + ECX.Get());

            IncrementSP();

            stack[SP.Get()] = EAX.Get();
        }

        void CPM()
        {

        }

        void MUL()
        {

        }

        void DIV()
        {

        }

        void XOR()
        {

        }

        void JMP()
        {

        }
    }
}
