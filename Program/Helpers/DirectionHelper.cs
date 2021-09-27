using Program.Models;

namespace Program.Helpers
{
    public class DirectionHelper
    {
        public static CompassEnum ResolveDirection(char direction) =>
            direction switch
            {
                'N' => CompassEnum.North,
                'S' => CompassEnum.South,
                'E' => CompassEnum.East,
                'W' => CompassEnum.West,
                _ => CompassEnum.Unknown
            };

        public static CompassEnum TurnLeft(CompassEnum direction) =>
            direction switch
            {
                CompassEnum.North => CompassEnum.West,
                CompassEnum.South => CompassEnum.East,
                CompassEnum.East => CompassEnum.North,
                CompassEnum.West => CompassEnum.South,
                _ => CompassEnum.Unknown
            };
        public static CompassEnum TurnRight(CompassEnum direction) =>
            direction switch
            {
                CompassEnum.North => CompassEnum.East,
                CompassEnum.South => CompassEnum.West,
                CompassEnum.East => CompassEnum.South,
                CompassEnum.West => CompassEnum.North,
                _ => CompassEnum.Unknown
            };
    }
}