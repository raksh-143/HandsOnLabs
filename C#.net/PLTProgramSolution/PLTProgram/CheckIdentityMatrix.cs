using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    internal class CheckIdentityMatrix
    {
        static int[,] matrix;
        static int matrixSize;
        static bool isIdentityMatrix = true;
        static void IdentityMatrix()
        {
            for(int i = 0; i < matrixSize; i++)
            {
                for(int j = 0; j < matrixSize; j++)
                {
                    if(i == j && matrix[i,j] != 1)
                    {
                        isIdentityMatrix = false;
                        return;
                    }
                    if(i!=j && matrix[i,j] != 0)
                    {
                        isIdentityMatrix = false;
                        return;
                    }
                }
            }
        }
        static void DisplayResult()
        {
            if(isIdentityMatrix)
            {
                Console.WriteLine("The matrix is an identity matrix");
            }
            else
            {
                Console.WriteLine("The matrix is not an identity matrix");
            }
        }
        static void Main()
        {
            //Accept the matrix from the user
            Console.Write("Enter the matrix size: ");
            matrixSize = int.Parse(Console.ReadLine());
            matrix = new int[matrixSize, matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    Console.Write($"Enter the element at [{i},{j}] position: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            //Check identity matrix
            IdentityMatrix();
            //display result
            DisplayResult();
            Console.ReadKey();
        }
    }
}
