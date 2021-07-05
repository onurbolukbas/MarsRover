using System;
using Program.Models;
using System.Collections.Generic;
using System.Linq;
using Program.Helpers;

namespace Program
{
    class Program
    {
        //dotnet run "5 5" "1 2 N" "LMLMLMLMM"
        //dotnet run "5 5" "1 2 N" "LMLMLMLMM" "3 3 E" "MMRMMRMRRM"
        static int Main(string[] args)
        {
            bool isValidInput = ProgramHelper.CheckInput(args);
            if (!isValidInput)
            {
                Console.WriteLine("Lutfen uygun girdiler giriniz");
                return (int)ExitCodeEnum.WrongInput;
            }

            List<Rover> roverList = new();

            char[] plateauArr = args[0].ToCharArray();
            Plateau plateau = new((int)Char.GetNumericValue(plateauArr[0]), (int)Char.GetNumericValue(plateauArr[2]));

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

            for (int i = 2; i < args.Length; i += 2)
            {
                char[] directions = args[i].ToCharArray();
                int index = 0;
                for (int j = 0; j < directions.Length; j++)
                {
                    index = (i / 2) - 1;
                    if (directions[j].Equals('L'))
                        roverList.ElementAt(index).State.TurnLeft();
                    else if (directions[j].Equals('R'))
                        roverList.ElementAt(index).State.TurnRight();
                    else if (directions[j].Equals('M'))
                    {
                        if (roverList.ElementAt(index).State.IsWrongMove(plateau))
                        {
                            Console.WriteLine("PossibleCrash");
                            return (int)ExitCodeEnum.PossibleCrash;
                        }
                        else
                        {
                            if (roverList.ElementAt(index).State.IsOutsideOfPlateau(plateau))
                            {
                                Console.WriteLine("PossibleFillOut");
                                return (int)ExitCodeEnum.PossibleFillOut;
                            }
                        }
                        roverList.ElementAt(index).State.Move();
                    }
                }
                Coordinate takenPoint = new(roverList.ElementAt(index).State.Coordinate.Latitude,
                roverList.ElementAt(index).State.Coordinate.Longitude);

                plateau.TakenPoints.Add(takenPoint);
            }
            foreach (var rover in roverList)
            {
                Console.WriteLine($"{rover.State.Coordinate.Latitude} {rover.State.Coordinate.Longitude} {rover.State.Direction}");
            }
            return (int)ExitCodeEnum.Success;


        }
        static int Sum(int a, int b) { return a + b; }
    }
}