using System;

namespace ConsoleAppArray
{
    class Program
    {
       
        static void Main(string[] args)
        {
            int[,] array = Array.CreateArray();
            Array.Print(array);

            ConsoleWriter.PrintTheMenuOne();
            int pointsInMenu = 3;
            int userAnswer = CheckData.CheckUserAnswerForValid(pointsInMenu);
            Sorting.Context context = new Sorting.Context(Sorting.ChooseStrategy(userAnswer));

            ConsoleWriter.PrintTheMenuTwo();
            pointsInMenu = 2;
            int secondUserAnswer = CheckData.CheckUserAnswerForValid(pointsInMenu);
            Sorting.BubbleSortOrderMethod bubbleSortOrderMethod = Sorting.ChooseBubbleSortOrderMetod(userAnswer, secondUserAnswer);
            
            context.ExecuteAlgorithm(array, bubbleSortOrderMethod);
            Array.Print(array);

            Console.ReadKey();
        }  
    }
}
