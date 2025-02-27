using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
    public static class UserDataFetchUtility
    {
        public static int GetUserInput()
        {
            Console.Write("Enter a number :");
            int numericalInput = default;
            while (int.TryParse(Console.ReadLine(), out numericalInput) == false)
            {
                throw new InvalidUserInputException("Your value is Invalid");
            }
            return numericalInput;
        }
    }
}
