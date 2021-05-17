using System;

public class Array
{
    /// <summary>
    /// creates an array with random size and random integers
    /// </summary>
    /// <returns>created array</returns>
    public static int [,] CreateArray()
    {
        Random random = new Random();
        int arraySize = random.Next(5, 10);
        int[,] array = new int[arraySize, arraySize];
        int rows = arraySize;
        int columns = arraySize;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                array[i, j] = random.Next(0, 15);
            }
        }
        return array;
    }

    /// <summary>
    /// prints the array to console
    /// </summary>
    /// <param name="array">an array to print</param>
    public static void Print(int [,] array)
    {
        int rows = array.GetUpperBound(0) + 1;
        int columns = array.Length / rows;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
               Console.Write("{0, -3}", array[i, j]);
            }

            Console.WriteLine();
        }
    }

    /// <summary>
    /// finds the min element in a row
    /// </summary>
    /// <param name="array">array to check</param>
    /// <param name="i">number of a row from array</param>
    public static int FindMinElement(int[,] array, int i)
    {
        int min = array[i, 0];
        int rows = array.GetUpperBound(0) + 1;
        int columns = array.Length / rows;

        for (int j = 0; j < columns; j++)
        {
            if (min > array[i, j])
            {
                min = array[i, j];
            }
        }

        return min;
    }

    /// <summary>
    /// finds the sum of all elements in a row
    /// </summary>
    /// <param name="array">array to check</param>
    /// <param name="i">number of a row from array</param>
    public static int FindSumOfElement(int[,] array, int i)
    {
        int sum =  0;
        int rows = array.GetUpperBound(0) + 1;
        int columns = array.Length / rows;

        for (int j = 0; j < columns; j++)
        {
            sum += array[i, j];
        }

        return sum;
    }

    /// <summary>
    /// finds the max element in a row
    /// </summary>
    /// <param name="array">array to check</param>
    /// <param name="i">number of a row from array</param>
    public static int FindMaxElement(int[,] array, int i)
    {
        int max = array[i, 0];
        int rows = array.GetUpperBound(0) + 1;
        int columns = array.Length / rows;

        for (int j = 0; j < columns; j++)
        {
            if (max < array[i, j])
            {
                max = array[i, j];
            }
        }

        return max;
    }


}
