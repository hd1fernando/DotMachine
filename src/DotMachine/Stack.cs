using System;

namespace VirtualMachine
{
    public class Stack
    {
        dynamic[] _stack;
        const int CAPACITY = 256;
        public Stack()
        {
            _stack = new dynamic[CAPACITY];
        }
        public int Size() => CAPACITY;

        public int this[int index]
        {
            get
            {
                if (index >= CAPACITY || index < 0)
                    throw new InsufficientExecutionStackException("Invalid stack position");
                return _stack[index];
            }
            set
            {
                if (index >= CAPACITY || index < 0)
                    throw new InsufficientExecutionStackException("Invalid stack position");
                _stack[index] = value;
            }
        }

    }
}
