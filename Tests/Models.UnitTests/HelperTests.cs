using System;
using Xunit;
using AutoFixture;
using FluentAssertions;
using Program.Models;
using Program.Helpers;

namespace Models.UnitTests
{
    public class HelperTests

    {
        private readonly IFixture _fixture;
        public HelperTests()
        {
            _fixture = new Fixture();
        }
        [Fact]
        public void GivenInvalidChar_Should_ReturnUnkown()
        {
            CompassEnum compass = DirectionHelper.ResolveDirection('A');

            compass.Should().Be(CompassEnum.Unknown);
        }
        [Fact]
        public void GivenN_Should_ReturnNorth()
        {
            CompassEnum compass = DirectionHelper.ResolveDirection('N');

            compass.Should().Be(CompassEnum.North);
        }
        [Fact]
        public void GivenUnknown_Should_ReturnUnknown()
        {
            CompassEnum compass = DirectionHelper.TurnLeft(CompassEnum.Unknown);

            compass.Should().Be(CompassEnum.Unknown);
        }
        [Fact]
        public void GivenNorth_Should_ReturnWest()
        {
            CompassEnum compass = DirectionHelper.TurnLeft(CompassEnum.North);

            compass.Should().Be(CompassEnum.West);
        }
        [Fact]
        public void GivenValidData_Should_ReturnTrue()
        {
            string[] input = new string[5] {
                _fixture.Create<string>(),
                _fixture.Create<string>(),
                _fixture.Create<string>(),
                _fixture.Create<string>(),
                _fixture.Create<string>()};

            bool isValid = ProgramHelper.CheckInput(input);

            isValid.Should().BeTrue();
        }
        [Fact]
        public void GivenInvalidData_Should_ReturnFalse()
        {
            string[] input = new string[2] {
                _fixture.Create<string>(),
                _fixture.Create<string>()};

            bool isValid = ProgramHelper.CheckInput(input);

            isValid.Should().BeFalse();
        }

    }
}
