using System;
namespace Program.Models
{
    public class Plateau
    {
        public Coordinate LowerLeft { get; set; }
        public Coordinate UpperRight { get; set; }

        public Plateau(
            int Latitude,
            int Longitude
        )
        {
            LowerLeft = new();
            UpperRight = new();
            this.UpperRight.Latitude = Latitude;
            this.UpperRight.Longitude = Longitude;
            this.LowerLeft.Latitude = 0;
            this.LowerLeft.Longitude = 0;
        }
    }
}