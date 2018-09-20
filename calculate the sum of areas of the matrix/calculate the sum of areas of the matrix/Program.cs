using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculate_the_sum_of_areas_of_the_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            MatrixCalculateClass matrixCalculateClass = new MatrixCalculateClass();
            int[,] startArray = new int[5, 5]
              {
                         {0,1,2,3,4},
                         {1,1,2,3,4},
                         {2,2,2,3,4},
                         {3,3,3,3,4},
                         {4,4,4,4,4}
                       };

            for (int i = 0; i < 2; i++) // Matrix output to the screen
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(matrixCalculateClass.MatrixCalculate(startArray)[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
    class MatrixCalculateClass
    {
        /*
         * A square matrix is given, which is divided into diagonals (main and secondary) into triangles: upper and lower, left and right. 
         * The class contains a method that calculates the sum of the numbers of each individual triangle and writes them into a 2x2 matrix. 
         * The method counts all in ONE pass through the matrix.
         */
        public int[,] MatrixCalculate(int[,] matrix)
        {
            int sumGreen, sumYellow, sumBlue, sumOrange;        // variables will store sum data
            sumGreen = sumYellow = sumBlue = sumOrange = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)       // 2 cycles to pass through the matrix
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row < col)                                  // if the element is above the main diagonal
                    {
                        if (col + row < matrix.GetLength(1) - 1)    // if the element is above the secondary diagonal and above the main diagonal
                        {
                            sumGreen += matrix[row, col];           // sum of the upper triangle
                        }
                        if (col + row > matrix.GetLength(1) - 1)    // if the element is below the secondary diagonal and above the main diagonal
                        {
                            sumBlue += matrix[row, col];            // sum of the right triangle
                        }
                    }
                    if (row > col)                                   // if the element is below the main diagonal
                    {
                        if (col + row < matrix.GetLength(1) - 1)     // if the element is above the secondary diagonal and below the main diagonal
                        {
                            sumYellow += matrix[row, col];           // sum of the left triangle
                        }
                        if (col + row > matrix.GetLength(1) - 1)     // if the element is below the secondary diagonal and below the main diagonal
                        {
                            sumOrange += matrix[row, col];           // sum of the lower triangle
                        }
                    }
                }
            }

            int[,] resultArray = new int[2, 2]                   // create an array for the output of the finite sums
            {
                { sumGreen, sumBlue },
                { sumOrange,sumYellow }
            };

            return resultArray;
        }

    }
}
