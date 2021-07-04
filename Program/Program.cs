using System;
using Program.Models;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    class Program
    {
        //dotnet run "5 5" "1 2 N" "LMLMLMLMM"
        //dotnet run "5 5" "1 2 N" "LMLMLMLMM" "3 3 E" "MMRMMRMRRM"
        static void Main(string[] args)
        {
            if (args == null || args.Length < 3 || args.Length % 2 == 0)
            {
                Console.WriteLine("Lutfen uygun girdiler giriniz");
            }
            else
            {
                List<Rover> roverList = new();

                char[] plateauArr = args[0].ToCharArray();
                Plateau plateau = new((int)plateauArr[0], (int)plateauArr[2]);

                for (int i = 1; i < args.Length; i += 2)
                {

                    char[] roverStateArr = args[i].ToCharArray();
                    string name = $"Rover{i}";

                    Rover rover = new(name,
                    (int)Char.GetNumericValue(roverStateArr[0]),
                    (int)Char.GetNumericValue(roverStateArr[2]),
                    roverStateArr[4]);

                    roverList.Add(rover);

                }
                for (int i = 2; i < args.Length; i += 2)
                {

                    char[] directions = args[i].ToCharArray();
                    for (int j = 0; j < directions.Length; j++)
                    {
                        if (directions[j].Equals('L'))
                            roverList.ElementAt((i / 2) - 1).State.TurnLeft();
                        else if (directions[j].Equals('R'))
                            roverList.ElementAt((i / 2) - 1).State.TurnRight();
                        else if (directions[j].Equals('M'))
                            roverList.ElementAt((i / 2) - 1).State.Move();

                    }
                }
                foreach (var rover in roverList)
                {
                    Console.WriteLine($"{rover.State.Coordinate.Latitude} {rover.State.Coordinate.Longitude} {rover.State.Direction}");
                }
            }

        }
    }
}
