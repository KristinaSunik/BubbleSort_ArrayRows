using System;

namespace ConsoleAppArray
{
    class CheckData
    {
        /// <summary>
        /// checks user data for valid data. Repeats while data isn't valid
        /// </summary>
        /// <returns>the point in menu user have chosen</returns>
        public static int CheckUserAnswerForValid(int pointsInMenu)
        {
            int checkedUserAnswer;
            while (true)
            {
                Console.WriteLine("Your answer is: ");
                string userAnswer = Console.ReadLine();
                if (!int.TryParse(userAnswer, out checkedUserAnswer))   //checking for integer
                {
                    Console.WriteLine("Input only integers");
                    continue;
                }

                if (checkedUserAnswer <= 0 || checkedUserAnswer > pointsInMenu)     //checking for valid data
                {
                    Console.WriteLine("You can choose only between points in the menu:");
                    Console.WriteLine($"The numbers should be from 0 to {pointsInMenu}");
                    continue;
                }
                else
                {
                    break;
                }
            }

            return checkedUserAnswer;
        }
    }
}
