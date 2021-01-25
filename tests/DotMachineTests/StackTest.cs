using FluentAssertions;
using System;
using VirtualMachine;
using Xunit;

namespace DotMachineTests
{
    public class StackTest
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(256)]
        [InlineData(257)]
        public void ShouldThrowExceptioWhePostionIsInvalid(int postion)
        {
            Stack stack = new();

            Action result = () => stack[postion] = 42;

            result.Should().Throw<InsufficientExecutionStackException>().WithMessage("Invalid stack position");
        }
    }
}
