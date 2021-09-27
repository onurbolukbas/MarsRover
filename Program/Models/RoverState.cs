using Program.Helpers;
using System;

namespace Program.Models
{
    public class RoverState
    {
        public Coordinate Coordinate { get; set; }
        public CompassEnum Direction { get; set; }

        public RoverState(
            int Latitude,
            int Longitude,
            CompassEnum direction
        )
        {
            Coordinate = new(Latitude, Longitude);
            this.Direction = direction;
        }
        public void SendDirective(char directive, Plateau plateau)
        {
            switch (directive)
            {
                case 'L':
                    this.TurnLeft();
                    break;
                case 'R':
                    this.TurnRight();
                    break;
                case 'M':
                    this.Move(plateau);
                    break;
            }
        }
        public void Move(Plateau plateau)
        {
            var nextCoordinate = GetNextCoordinate(plateau);
            if (!(this.IsGonnaCrash(plateau, nextCoordinate) || this.IsOutsiteOfPlateau(plateau, nextCoordinate)))
            {
                switch (this.Direction)
                {
                    case CompassEnum.North:
                        this.Coordinate.Longitude += 1;
                        break;
                    case CompassEnum.East:
                        this.Coordinate.Latitude += 1;
                        break;
                    case CompassEnum.South:
                        this.Coordinate.Longitude -= 1;
                        break;
                    case CompassEnum.West:
                        this.Coordinate.Latitude -= 1;
                        break;
                }

            }
        }

        public Coordinate GetNextCoordinate(Plateau plateau) =>
            this.Direction switch
            {
                CompassEnum.North => new(this.Coordinate.Latitude, this.Coordinate.Longitude + 1),
                CompassEnum.East => new(this.Coordinate.Latitude + 1, this.Coordinate.Longitude),
                CompassEnum.South => new(this.Coordinate.Latitude, this.Coordinate.Longitude - 1),
                CompassEnum.West => new(this.Coordinate.Latitude - 1, this.Coordinate.Longitude),
                _ => null
            };
        public bool IsOutsiteOfPlateau(Plateau plateau, Coordinate nextCoordinate)
        {
            if (nextCoordinate.Latitude > plateau.UpperRight.Latitude
            || nextCoordinate.Longitude > plateau.UpperRight.Longitude
            || nextCoordinate.Latitude < plateau.LowerLeft.Latitude
            || nextCoordinate.Longitude < plateau.LowerLeft.Longitude)
                return true;

            return false;
        }
        public bool IsGonnaCrash(Plateau plateau, Coordinate nextCoordinate)
        {
            foreach (var takenPoint in plateau.TakenPoints)
            {
                if (takenPoint.Latitude == nextCoordinate.Latitude
                && takenPoint.Longitude == nextCoordinate.Longitude)
                    return true;
            }
            return false;
        }
        public void TurnLeft()
        {
            this.Direction = DirectionHelper.TurnLeft(this.Direction);
        }
        public void TurnRight()
        {
            this.Direction = DirectionHelper.TurnRight(this.Direction);
        }


    }
}