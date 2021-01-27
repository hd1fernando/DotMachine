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

        [Theory(DisplayName = "Sub two numbers")]
        [InlineData("5", "6", 1)]
        [InlineData("5", "-6", -11)]
        [InlineData("-5", "6", 11)]
        [InlineData("-5", "-6", -1)]
        public void Add_ShouldSubTwoValues(string valuea, string valueb, int result)
        {
            string program = $@"
            PUSH {valuea}
            PUSH {valueb}
            SUB
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

        [Theory(DisplayName = "Compare two numbers")]
        [InlineData("5", "6", 0)]
        [InlineData("5", "5", 1)]
        public void ShoulCompareTwoValues(string valuea, string valueb, int result)
        {
            string program = $@"
            PUSH {valuea}
            PUSH {valueb}
            CMP
            HLT";
            DotVM vm = new(program);
            vm.Load();

            vm.Exec();

            var zf = vm.ZF.Get();

            zf.Should().Be(result);
        }

        [Fact(DisplayName = "Jump for position at code")]
        public void ShoudJump()
        {
            string program = $@"
            PUSH 4
            JMP
            CMP
            PUSH 5
            PUSH 5
            ADD
            HLT";
            DotVM vm = new(program);
            vm.Load();

            vm.Exec();

            var eax = vm.EAX.Get();

            eax.Should().Be(10);
        }

        [Fact(DisplayName = "XOR two numbers")]
        public void ShoudXor()
        {
            string program = $@"
            PUSH 5
            PUSH 5
            XOR
            HLT";
            DotVM vm = new(program);
            vm.Load();

            vm.Exec();

            var eax = vm.EAX.Get();

            eax.Should().Be(0);
        }
    }
}
