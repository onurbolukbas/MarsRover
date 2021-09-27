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
            roverList = ProgramHelper.GenerateRover(args);

            char[] plateauArr = args[0].ToCharArray();
            Plateau plateau = new((int)Char.GetNumericValue(plateauArr[0]), (int)Char.GetNumericValue(plateauArr[2]));

            // Direktifleri doner
            for (int i = 2; i < args.Length; i += 2)
            {
                char[] directions = args[i].ToCharArray();
                int index = (i / 2) - 1;

                //Her bir direktifi saptar
                for (int j = 0; j < directions.Length; j++)
                {
                    roverList.ElementAt(index).State.SendDirective(directions[j], plateau);
                }

                Coordinate takenPoint = new(roverList.ElementAt(index).State.Coordinate.Latitude,
                roverList.ElementAt(index).State.Coordinate.Longitude);

                plateau.TakenPoints.Add(takenPoint);
            }

            ProgramHelper.ListRoverStates(roverList);

            return (int)ExitCodeEnum.Success;
        }
    }
}