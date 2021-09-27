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
        public void GivenValidDirective_Should_ReturnTrue()
        {
            int latitude = 5;
            int longitude = 5;

            RoverState roverState = new(latitude, longitude, CompassEnum.North);

            Plateau plateau = new(5, 5);
            Coordinate nextCoordinate = new(5, 6);

            bool isTrue = roverState.IsOutsiteOfPlateau(plateau, nextCoordinate);

            isTrue.Should().BeTrue();
        }

    }
}
