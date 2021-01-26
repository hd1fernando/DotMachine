using FluentAssertions;
using VirtualMachine;
using Xunit;

namespace DotMachineTests
{
    public class DotVMTest
    {
        [Theory(DisplayName = "Add two numbers")]
        [InlineData("5", "6", 11)]
        [InlineData("5", "-6", -1)]
        [InlineData("-5", "6", 1)]
        [InlineData("-5", "-6", -11)]
        public void Add_ShouldAddTwoValues(string valuea, string valueb, int result)
        {
            string program = $@"
            PUSH {valuea}
            PUSH {valueb}
            ADD
            POP
            HLT";
            DotVM vm = new(program);
            vm.Load();

            vm.Exec();

            var eax = vm.EAX.Get();

            eax.Should().Be(result);
        }

        [Theory(DisplayName = "Mul two numbers")]
        [InlineData("5", "6", 30)]
        [InlineData("5", "-6", -30)]
        [InlineData("-5", "6", -30)]
        [InlineData("-5", "-6", 30)]
        public void ShouldMulTwoValues(string valuea, string valueb, int result)
        {
            string program = $@"
            PUSH {valuea}
            PUSH {valueb}
            MUL
            POP
            HLT";
            DotVM vm = new(program);
            vm.Load();

            vm.Exec();

            var eax = vm.EAX.Get();

            eax.Should().Be(result);
        }
    }
}
