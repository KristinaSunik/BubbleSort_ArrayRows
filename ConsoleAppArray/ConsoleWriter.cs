using System;

namespace ConsoleAppArray
{
    class ConsoleWriter
    {
        /// <summary>
        /// prints to console the main menu of program
        /// </summary>
        public static void PrintTheMenuOne()
        {
            Console.WriteLine("How do you want to sort array(choose the number):" + Environment.NewLine +
                            "1. in order of sums of matrix row elements;" + Environment.NewLine +
                            "2. in order of maximum element in a matrix row;" + Environment.NewLine +
                            "3. in order of minimum element in a matrix row;");
        }

        /// <summary>
        ///  prints to console the additional menu of program
        /// </summary>
        public static void PrintTheMenuTwo()
        {
            Console.WriteLine("In wich way should we sort array:" + Environment.NewLine +
                "1. Ascending" + Environment.NewLine +
                "2. Descending");
        }
    }
}
