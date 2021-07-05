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
        public void Move()
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
        public bool IsWrongMove(Plateau plateau)
        {
            Coordinate coordinate;
            switch (this.Direction)
            {
                case CompassEnum.North:
                    coordinate = new(this.Coordinate.Latitude, this.Coordinate.Longitude + 1);
                    return this.CheckPossibleCrash(plateau, coordinate);
                case CompassEnum.East:
                    coordinate = new(this.Coordinate.Latitude + 1, this.Coordinate.Longitude);
                    return this.CheckPossibleCrash(plateau, coordinate);
                case CompassEnum.South:
                    coordinate = new(this.Coordinate.Latitude, this.Coordinate.Longitude - 1);
                    return this.CheckPossibleCrash(plateau, coordinate);
                case CompassEnum.West:
                    coordinate = new(this.Coordinate.Latitude - 1, this.Coordinate.Longitude);
                    return this.CheckPossibleCrash(plateau, coordinate);
                default:
                    return false;
            }
        }
        public bool IsOutsideOfPlateau(Plateau plateau)
        {
            Coordinate coordinate;
            switch (this.Direction)
            {
                case CompassEnum.North:
                    coordinate = new(this.Coordinate.Latitude, this.Coordinate.Longitude + 1);
                    return this.CheckPossibleOutsite(plateau, coordinate);
                case CompassEnum.East:
                    coordinate = new(this.Coordinate.Latitude + 1, this.Coordinate.Longitude);
                    return this.CheckPossibleOutsite(plateau, coordinate);
                case CompassEnum.South:
                    coordinate = new(this.Coordinate.Latitude, this.Coordinate.Longitude - 1);
                    return this.CheckPossibleOutsite(plateau, coordinate);
                case CompassEnum.West:
                    coordinate = new(this.Coordinate.Latitude - 1, this.Coordinate.Longitude);
                    return this.CheckPossibleOutsite(plateau, coordinate);
                default:
                    return false;
            }
        }
        public int Sum(int a, int b)
        {
            return a + b;
        }
        public bool CheckPossibleOutsite(Plateau plateau, Coordinate nextCoordinate)
        {
            Console.WriteLine($"nextCoordinate: {nextCoordinate.Longitude}");
            Console.WriteLine($"plateau: {plateau.UpperRight.Longitude}");
            if (nextCoordinate.Latitude > plateau.UpperRight.Latitude
            || nextCoordinate.Longitude > plateau.UpperRight.Longitude)
            {
                Console.WriteLine("outside1");
                return true;
            }
            if (nextCoordinate.Latitude < plateau.LowerLeft.Latitude
            || nextCoordinate.Longitude < plateau.LowerLeft.Longitude)
            {
                Console.WriteLine("outside2");
                return true;
            }
            return false;
        }
        public bool CheckPossibleCrash(Plateau plateau, Coordinate nextCoordinate)
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