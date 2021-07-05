using System;
using Xunit;
using AutoFixture;
using FluentAssertions;
using Program.Models;
using Program.Helpers;

namespace Models.UnitTests
{
    public class ModelTests

    {
        private readonly IFixture _fixture;
        public ModelTests()
        {
            _fixture = new Fixture();
        }
        [Fact]
        public void GivenInvalidChar_Should_ReturnUnkown()
        {
            int latitude = 5;
            int longitude = 5;

            RoverState roverState = new(latitude, longitude, CompassEnum.North);

            Plateau plateau = new(5, 5);

            Coordinate coordinate = new(6, 6);

            bool isTrue = roverState.IsOutsiteOfPlateau(plateau);

            isTrue.Should().BeTrue();
        }

    }
}
