namespace VirtualMachine
{
    public class Register : IRegister
    {
        int _value;

        public void Set(int value)
            => _value = value;

        public int Get() => _value;
    }
}
