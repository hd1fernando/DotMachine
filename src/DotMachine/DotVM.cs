using System;
using System.Collections.Generic;

namespace VirtualMachine
{
    public class DotVM
    {
        Stack stack = new();

        Register SP = new(); // Stack  Pointer
        Register IP = new(); // Instruction Pointer

        Register EAX = new();
        Register EBX = new();
        Register ECX = new();

        static bool _running;
        string _strProgram;
        string[] _program;
        public DotVM(string program)
        {
            _strProgram = program;
        }

        public void Load()
        {
            _program = _strProgram.Split(' ');
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
            var value = IP.Get();
            IP.Set(value++);
        }

        int IncrementSP()
        {
            var sp = SP.Get();
            SP.Set(sp++);
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

        Dictionary<string, Action> InstructionsSet = new()
        {
            { "HLT", () => { _running = false; } }, // Stop the program
            { "PSH", PushRule },
            { "POP", PopRule },
            { "ADD", AddRule }
        };

        void PushRule()
        {
            IncrementSP();
            var ip = IP.Get();
            stack[SP.Get()] = int.Parse(_program[++ip]);
        }

        int PopFromStack()
        {
            var sp = SP.Get();
            return stack[sp--];
        }

        /// <summary>
        /// Get a value from Stack and set in the EAX register
        /// </summary>
        void PopRule()
        {
            int poppedValue = PopFromStack();

            EAX.Set(poppedValue);
        }

        void AddRule()
        {
            EBX.Set(PopFromStack());
            ECX.Set(PopFromStack());
            EAX.Set(EBX.Get() + ECX.Get());

            IncrementSP();

            stack[SP.Get()] = EAX.Get();
        }

    }
}
