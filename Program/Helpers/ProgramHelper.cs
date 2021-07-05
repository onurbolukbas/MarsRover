using System.Collections.Generic;
using Program.Models;
using System;

namespace Program.Helpers
{
    public class ProgramHelper
    {
        public static bool CheckInput(string[] input)
        {
            if (input == null || input.Length < 3 || input.Length % 2 == 0)
            {
                return false;
            }
            return true;
        }
        public static void ListRoverStates(List<Rover> roverList)
        {
            foreach (var rover in roverList)
            {
                Console.WriteLine($"{rover.Name}: {rover.State.Coordinate.Latitude} {rover.State.Coordinate.Longitude} {rover.State.Direction}");
            }
        }
        public static List<Rover> GenerateRover(string[] args)
        {
            List<Rover> roverList = new();
            for (int i = 1; i < args.Length; i += 2)
            {
                char[] roverStateArr = args[i].ToCharArray();
                string name = $"Rover - {i}";

                Rover rover = new(name,
                (int)Char.GetNumericValue(roverStateArr[0]),
                (int)Char.GetNumericValue(roverStateArr[2]),
                roverStateArr[4]);

                roverList.Add(rover);
            }
            return roverList;
        }
    }
}