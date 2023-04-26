using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    //Write a pseudocode to store elements into a N * N matrix of integer. Display whether it is a symmetric matrix or not
    internal class CheckSymmetrixMatrix
    {
        static int[,] matrix;
        static int[,] transposeMatrix;
        static int matrixSize;
        static bool isSymmetricMatrix=true;
        static void FindMatrixTranspose()
        {
            transposeMatrix = new int[matrixSize, matrixSize];
            for(int i=0; i<matrixSize; i++)
            {
                for(int j = 0; j < matrixSize; j++)
                {
                    transposeMatrix[i,j] = matrix[j,i];
                }
            }
        }
        static void CheckIfSymmetric()
        {
            for(int i=0;i<matrixSize; i++)
            {
                for(int j=0; j<matrixSize; j++)
                {
                    if (matrix[i,j] != transposeMatrix[i,j]) {
                    isSymmetricMatrix= false;
                    }
                }
            }
        }
        static void DisplayResult()
        {
            if (isSymmetricMatrix)
            {
                Console.WriteLine("The matrix is an symmetric matrix");
            }
            else
            {
                Console.WriteLine("The matrix is not a symmetric matrix");
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
            //Find transpose
            FindMatrixTranspose();
            //Check if symmetric
            CheckIfSymmetric();
            //Display result
            DisplayResult();
            Console.ReadKey();
        }
    }
}
