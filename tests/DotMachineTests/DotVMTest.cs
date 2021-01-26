using FluentAssertions;
using VirtualMachine;
using Xunit;

namespace DotMachineTests
{
    public class DotVMTest
    {
        [Fact]
        public void Add_ShouldAddTwoValues_AGraterThanB()
        {
            string program = @"
            PUSH 5
            PUSH 6
            ADD
            POP
            HLT";
            DotVM vm = new(program);
            vm.Load();

            vm.Exec();

            var eax = vm.EAX.Get();

            eax.Should().Be(11);
        }
    }
}
