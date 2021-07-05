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
            if (!(this.IsGonnaCrash(plateau) || this.IsOutsiteOfPlateau(plateau)))
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
        public bool IsGonnaCrash(Plateau plateau)
        {
            Coordinate coordinate;
            switch (this.Direction)
            {
                case CompassEnum.North:
                    coordinate = new(this.Coordinate.Latitude, this.Coordinate.Longitude + 1);
                    return this.IsGonnaCrash(plateau, coordinate);
                case CompassEnum.East:
                    coordinate = new(this.Coordinate.Latitude + 1, this.Coordinate.Longitude);
                    return this.IsGonnaCrash(plateau, coordinate);
                case CompassEnum.South:
                    coordinate = new(this.Coordinate.Latitude, this.Coordinate.Longitude - 1);
                    return this.IsGonnaCrash(plateau, coordinate);
                case CompassEnum.West:
                    coordinate = new(this.Coordinate.Latitude - 1, this.Coordinate.Longitude);
                    return this.IsGonnaCrash(plateau, coordinate);
                default:
                    return false;
            }
        }
        public bool IsOutsiteOfPlateau(Plateau plateau)
        {
            Coordinate coordinate;
            switch (this.Direction)
            {
                case CompassEnum.North:
                    coordinate = new(this.Coordinate.Latitude, this.Coordinate.Longitude + 1);
                    return this.IsOutsiteOfPlateau(plateau, coordinate);
                case CompassEnum.East:
                    coordinate = new(this.Coordinate.Latitude + 1, this.Coordinate.Longitude);
                    return this.IsOutsiteOfPlateau(plateau, coordinate);
                case CompassEnum.South:
                    coordinate = new(this.Coordinate.Latitude, this.Coordinate.Longitude - 1);
                    return this.IsOutsiteOfPlateau(plateau, coordinate);
                case CompassEnum.West:
                    coordinate = new(this.Coordinate.Latitude - 1, this.Coordinate.Longitude);
                    return this.IsOutsiteOfPlateau(plateau, coordinate);
                default:
                    return false;
            }
        }
        public bool IsOutsiteOfPlateau(Plateau plateau, Coordinate nextCoordinate)
        {
            if (nextCoordinate.Latitude > plateau.UpperRight.Latitude
            || nextCoordinate.Longitude > plateau.UpperRight.Longitude)
                return true;
            if (nextCoordinate.Latitude < plateau.LowerLeft.Latitude
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