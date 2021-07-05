using Program.Models;

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
        public static GetPlateauInformation(char[] plateauArr)
        {

        }
    }
}