using System;
using System.Collections.Generic;

namespace Program.Models
{
    public class Plateau
    {
        public Coordinate LowerLeft { get; init; }
        public Coordinate UpperRight { get; init; }
        public List<Coordinate> TakenPoints { get; set; }

        public Plateau(
            int Latitude,
            int Longitude
        )
        {
            UpperRight = new(Latitude, Longitude);
            LowerLeft = new(0, 0);
            TakenPoints = new();
        }
    }
}