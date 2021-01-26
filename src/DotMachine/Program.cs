using System;
using System.Collections.Generic;
using System.Text;

using static System.Console;

namespace VirtualMachine
{
    class Program
    {

        static string[] program;

        static void LoadProgram()
        {
            StringBuilder sb = new();
            sb.Append("PSH 6 ");
            sb.Append("PSH 6 ");
            sb.Append("ADD ");
            sb.Append("POP ");
            sb.Append("HLT ");
            program = sb.ToString().Split(' ');
        }

        static int ip = 0; // Instruction pointer
        static int sp = -1; // stack pointer
        static int[] stack = new int[256];

        static bool running = true;

        static void Main(string[] args)
        {
            LoadProgram();
            while (running)
            {
                Eval(Fetch());
                ip++;
            }

            ReadLine();
        }

        static void Eval(string instruction)
        {
            InstructionsSet[instruction].Invoke();
        }

        static Dictionary<string, Action> InstructionsSet = new()
        {
            { "HLT", () => { running = false; } },// Stop the program
            { "PSH", PushRule },
            { "POP", PopRule },
            { "ADD", AddRule }
        };


        static void PushRule()
        {
            IncrementSP();
            stack[sp] = int.Parse(program[++ip]);
        }

        static int PopFromStack() => stack[sp--];
        static int IncrementSP() => sp++;
        static void PopRule()
        {
            int valPoped = PopFromStack();

            WriteLine($"POPED: {valPoped}");
        }

        static void AddRule()
        {
            int a = PopFromStack();
            int b = PopFromStack();
            int result = a + b;
            IncrementSP();
            stack[sp] = result;
        }

        static string Fetch()
            => program[ip];
    }
}
