using System;
using Xunit;
using AutoFixture;
using FluentAssertions;
using Program.Models;
using Program;

namespace Models.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            RoverState roverState = new(1, 1, CompassEnum.North);
            int result = roverState.Sum(2, 3);
            result.Should().Be(5);
        }

        [Fact]
        public void Test2()
        {
            // string[] args = new();
            // args[0] = "111";
            var result = Program.Program.Sum(1, 2);
            result.Should().Be(5);
        }
    }
}
