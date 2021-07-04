using Program.Helpers;

namespace Program.Models
{
    public class Rover
    {
        public string Name { get; set; }
        public RoverState State { get; set; }

        public Rover(
            string name,
            int Latitude,
            int Longitude,
            char direction
        )
        {
            this.Name = name;
            State = new(Latitude, Longitude, DirectionHelper.ResolveDirection(direction));
        }
    }
}