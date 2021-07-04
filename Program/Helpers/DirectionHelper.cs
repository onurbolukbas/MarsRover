using Program.Models;

namespace Program.Helpers
{
    public class DirectionHelper
    {
        public static CompassEnum ResolveDirection(char direction)
        {
            if (direction.Equals('N'))
                return CompassEnum.North;
            else if (direction.Equals('E'))
                return CompassEnum.East;
            else if (direction.Equals('S'))
                return CompassEnum.South;
            else if (direction.Equals('W'))
                return CompassEnum.West;
            else
                return CompassEnum.Unknown;
        }
        public static CompassEnum TurnLeft(CompassEnum direction)
        {
            if (direction.Equals(CompassEnum.North))
                return CompassEnum.West;
            else if (direction.Equals(CompassEnum.East))
                return CompassEnum.North;
            else if (direction.Equals(CompassEnum.South))
                return CompassEnum.East;
            else if (direction.Equals(CompassEnum.West))
                return CompassEnum.South;
            else
                return CompassEnum.Unknown;
        }
        public static CompassEnum TurnRight(CompassEnum direction)
        {
            if (direction.Equals(CompassEnum.North))
                return CompassEnum.East;
            else if (direction.Equals(CompassEnum.East))
                return CompassEnum.South;
            else if (direction.Equals(CompassEnum.South))
                return CompassEnum.West;
            else if (direction.Equals(CompassEnum.West))
                return CompassEnum.North;
            else
                return CompassEnum.Unknown;
        }
    }
}