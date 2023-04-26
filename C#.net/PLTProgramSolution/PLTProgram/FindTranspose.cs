using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    //Write a pseudocode to store elements into a M * N matrix of integer. Display the matrix and its transpose
    internal class FindTranspose
    {
        static int[,] matrix;
        static int matrixRowSize, matrixColumnSize;
        static void DisplayMatrix()
        {
            Console.WriteLine("Displaying the matrix");
            for (int i = 0; i < matrixRowSize; i++)
            {
                for (int j = 0; j < matrixColumnSize; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void DisplayTransposeMatrix()
        {
            Console.WriteLine("Displaying the matrix transpose");
            for(int i=0;i<matrixColumnSize;i++)
            {
                for(int j = 0; j < matrixRowSize; j++)
                {
                    Console.Write(matrix[j,i] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main()
        {
            //Accept the matrix from the user
            Console.Write("Enter the number of rows: ");
            matrixRowSize = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of columns: ");
            matrixColumnSize = int.Parse(Console.ReadLine());
            matrix = new int[matrixRowSize,matrixColumnSize];
            for (int i = 0; i < matrixRowSize; i++)
            {
                for(int j=0;j<matrixColumnSize; j++)
                {
                    Console.Write($"Enter the element at [{i},{j}] position: ");
                    matrix[i,j] = int.Parse(Console.ReadLine());
                }
            }
            //display matrix
            DisplayMatrix();
            //display matrix transpose
            DisplayTransposeMatrix();
            Console.ReadKey();
        }
    }
}
