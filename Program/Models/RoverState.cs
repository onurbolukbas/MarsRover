using Program.Helpers;

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
            Coordinate = new();
            this.Coordinate.Latitude = Latitude;
            this.Coordinate.Longitude = Longitude;
            this.Direction = direction;
        }
        public void Move()
        {
            if (this.Direction == CompassEnum.North)
                this.Coordinate.Longitude += 1;
            if (this.Direction == CompassEnum.East)
                this.Coordinate.Latitude += 1;
            if (this.Direction == CompassEnum.South)
                this.Coordinate.Longitude -= 1;
            if (this.Direction == CompassEnum.West)
                this.Coordinate.Latitude -= 1;
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