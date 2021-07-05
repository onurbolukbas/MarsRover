namespace Program.Models
{
    public class Coordinate
    {
        public int Latitude { get; set; }
        public int Longitude { get; set; }

        public Coordinate(
            int Latitude,
            int Longitude
        )
        {
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }
    }
}