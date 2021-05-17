

namespace ConsoleAppArray
{
    class Sorting
    {
        internal delegate bool BubbleSortOrderMethod(int[,] array, int j);   //decides sorting by wich element 
        internal delegate void SortByElement(int[,] array, BubbleSortOrderMethod bubbleSortOrderMethod);

        public interface IStrategy
        {
            void BubbleSort(int[,] array, BubbleSortOrderMethod bubbleSortOrderMethod);
        }

        /// <summary>
        /// bubble sorts the array in the chosen way
        /// </summary>
        /// <param name="array">array to sort</param>
        /// <param name="bubbleSortOrderMethod">if it desc or asc</param>
        private static void BubbleSortInGeneral(int[,] array, BubbleSortOrderMethod bubbleSortOrderMethod)
        {
            int rows = array.GetUpperBound(0) + 1;

            for (int i = rows - 1; i > 0; i--)
            {
                bool flag = false;
                for (int j = 0; j < i; j++)
                {
                    if (bubbleSortOrderMethod(array, j))
                    {
                        int[] temp = new int[rows];
                        for (int k = 0; k < rows; k++)     // remember the first row
                        {
                            temp[k] = array[j, k];
                        }

                        for (int k = 0; k < rows; k++)     // rewrite the first row with the second one
                        {
                            array[j, k] = array[j + 1, k];
                        }

                        for (int k = 0; k < rows; k++)     // writes first(remembered) row to the second
                        {
                            array[j + 1, k] = temp[k];
                        }

                        flag = true;
                    }
                }

                if (flag == false)
                    return;
            }
        }

        /// <summary>
        /// bubble-sort a matrix of integers in order to arrange matrix rows
        ///in ascending (descending) order of sums of matrix row elements
        /// </summary>
        /// <param name="array">an array to bubble-sort</param>
        private class ConcreteStrategySumOfRows : IStrategy
        {
            public void BubbleSort(int[,] array, BubbleSortOrderMethod bubbleSortOrderMethod)
            {
                SortByElement sort = BubbleSortInGeneral;
                sort?.Invoke(array, bubbleSortOrderMethod);
            }
        }

        /// <summary>
        /// bubble-sort a matrix of integers in order to arrange matrix rows
        /// in ascending (descending) order of maximum element in a matrix row;
        /// </summary>
        /// <param name="array">an array to bubble-sort</param>
        private class ConcreteStrategyMaxElement : IStrategy
        {
            public void BubbleSort(int[,] array, BubbleSortOrderMethod bubbleSortOrderMethod)
            {
                SortByElement sort = BubbleSortInGeneral;
                sort?.Invoke(array, bubbleSortOrderMethod);
            }
        }

        /// <summary>
        /// bubble-sort a matrix of integers in order to arrange matrix rows
        /// in ascending (descending) order of minimum element in a matrix row;
        /// </summary>
        /// <param name="array">an array to bubble-sort</param>
        private class ConcreteStrategyMinElement : IStrategy
        {
            public void BubbleSort(int[,] array, BubbleSortOrderMethod bubbleSortOrderMethod)
            {
                SortByElement sort = BubbleSortInGeneral;
                sort?.Invoke(array, bubbleSortOrderMethod);
            }
        }

        /// <summary>
        /// Describes the way to sort
        /// </summary>
        public class Context
        {
            public IStrategy ContextStrategy { get; set; }

            public Context(IStrategy _strategy)
            {
                ContextStrategy = _strategy;
            }

            public void ExecuteAlgorithm(int[,] array, BubbleSortOrderMethod bubbleSortOrderMethod)
            {
                ContextStrategy.BubbleSort(array, bubbleSortOrderMethod);
            }
        }

        /// <summary>
        /// choses the way to sort with all users parametrs
        /// </summary>
        /// <param name="userAnswer">user chosed sorting by the parametr</param>
        /// <param name="secondUserAnswer">user chosed Asc or Desc sorting</param>
        /// <returns>the exact way of sorting</returns>
        public static BubbleSortOrderMethod ChooseBubbleSortOrderMetod(int userAnswer, int secondUserAnswer)
        {
            BubbleSortOrderMethod bubbleSortOrderMethod = BubbleSortDescMin;

            if (userAnswer == 1 && secondUserAnswer == 1)
                bubbleSortOrderMethod = BubbleSortAscSum;
            if (userAnswer == 1 && secondUserAnswer == 2)
                bubbleSortOrderMethod = BubbleSortDescSum;
            if (userAnswer == 2 && secondUserAnswer == 1)
                bubbleSortOrderMethod = BubbleSortAscMax;
            if (userAnswer == 2 && secondUserAnswer == 2)
                bubbleSortOrderMethod = BubbleSortDescMax;
            if (userAnswer == 3 && secondUserAnswer == 1)
                bubbleSortOrderMethod = BubbleSortAscMin;
            return bubbleSortOrderMethod;
        }

        /// <summary>
        /// checks meaning of elements due to Asc way for min elements
        /// </summary>
        /// <param name="array">array to sort</param>
        /// <param name="j">rows</param>
        private static bool BubbleSortAscSum(int[,] array, int j)
        {
            bool flag = false;
            if (Array.FindSumOfElement(array, j) > Array.FindSumOfElement(array, j + 1))
            {
                flag = true;
            }

            return flag;

        }

        /// <summary>
        /// checks meaning of elements due to desc way for min elements
        /// </summary>
        /// <param name="array">array to sort</param>
        /// <param name="j">rows</param>
        private static bool BubbleSortDescSum(int[,] array, int j)
        {
            bool flag = false;
            if (Array.FindSumOfElement(array, j) < Array.FindSumOfElement(array, j + 1))
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// checks meaning of elements due to Asc way for min elements
        /// </summary>
        /// <param name="array">array to sort</param>
        /// <param name="j">rows</param>
        private static bool BubbleSortAscMin(int[,] array, int j)
        {
            bool flag = false;
            if (Array.FindMinElement(array, j) > Array.FindMinElement(array, j + 1))
            {
                flag = true;
            }

            return flag;

        }

        /// <summary>
        /// checks meaning of elements due to Asc way for max elements
        /// </summary>
        /// <param name="array">array to sort</param>
        /// <param name="j">rows</param>
        private static bool BubbleSortAscMax(int[,] array, int j)
        {
            bool flag = false;
            if (Array.FindMaxElement(array, j) > Array.FindMaxElement(array, j + 1))
            {
                flag = true;
            }

            return flag;

        }

        /// <summary>
        /// checks meaning of elements due to desc way for max elements
        /// </summary>
        /// <param name="array">array to sort</param>
        /// <param name="j">rows</param>
        private static bool BubbleSortDescMax(int[,] array, int j)
        {
            bool flag = false;
            if (Array.FindMaxElement(array, j) < Array.FindMaxElement(array, j + 1))
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// checks meaning of elements due to desc way for min elements
        /// </summary>
        /// <param name="array">array to sort</param>
        /// <param name="j">rows</param>
        private static bool BubbleSortDescMin(int[,] array, int j)
        {
            bool flag = false;
            if (Array.FindMinElement(array, j) < Array.FindMinElement(array, j + 1))
            {
                flag = true;
            }

            return flag;
        }


        /// <summary>
        /// choose strategy of bubleSorting due to user answer
        /// </summary>
        /// <param name="userAnswer">user chose point with strategy of bubble sort</param>
        /// <returns>exact strategy that user chose </returns>
        public static IStrategy ChooseStrategy(int userAnswer)
        {
            IStrategy strategy = new ConcreteStrategySumOfRows();
            switch (userAnswer)
            {
                case 2:
                    strategy = new ConcreteStrategyMaxElement();
                    break;
                case 3:
                    strategy = new ConcreteStrategyMinElement();
                    break;
            }
            return strategy;
        }


    }
}
