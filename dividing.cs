using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIVIDING_MATRICIES_V2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
                //reading sizes such that if array1 m*n then array2 must be n*n, else reread input.
                int rows1 = 0, rows2 = 1, cols1 = 0, cols2 = 0;
                bool valid = true;
                Console.WriteLine("This Program Divides Array(1) By Array(2).\n");
                while (cols2 != rows2 || cols1 != rows2)
                {
                    if (!valid) Console.WriteLine("INVALID INPUT TRY AGAIN.\n");
                    Console.WriteLine("Enter Array(1) Size:-");
                    Console.Write("Enter The Rows: ");
                    rows1 = int.Parse(Console.ReadLine());
                    Console.Write("Enter The Columns: ");
                    cols1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nEnter Array(2) Size:-");
                    Console.Write("Enter The Rows: ");
                    rows2 = int.Parse(Console.ReadLine());
                    Console.Write("Enter The Columns: ");
                    cols2 = int.Parse(Console.ReadLine());
                    valid = false;
                }

                //reading array1
                Console.WriteLine();
                Console.WriteLine("---------------( Enter array(1) )---------------");
                int[,] arr1 = new int[rows1, cols1];
                for (int i = 0; i < rows1; i++)
                {
                    for (int j = 0; j < cols1; j++)
                    {
                        Console.Write("Enter the element [{0},{1}]: ", i + 1, j + 1);
                        arr1[i, j] = int.Parse(Console.ReadLine());
                    }
                }
                Console.WriteLine();
                //reading array2
                Console.WriteLine("---------------( Enter array(2) )---------------");
                double[,] arr2 = new double[rows2, cols2];
                for (int i = 0; i < rows2; i++)
                {
                    for (int j = 0; j < cols2; j++)
                    {
                        Console.Write("Enter the element [{0},{1}]: ", i + 1, j + 1);
                        arr2[i, j] = int.Parse(Console.ReadLine());
                    }
                }

                //getting inverse of array2:
                double[,] inverseofarr2 = new double[rows2, cols2];
                for (int i = 0; i < rows2; i++)
                {
                    for (int j = 0; j < cols2; j++)
                    {
                        inverseofarr2[i, j] = ((i == j) ? 1 : 0);
                    }
                }
                int n = rows2;
                for (int i = 0; i < n; i++)
                {
                    //checking if the element = 0
                    double val = arr2[i, i];
                    if (val == 0)
                    {
                        bool swapped = false;
                        for (int j = i; j < n; j++)
                        {
                            if (arr2[j, i] != 0)
                            {
                                val = arr2[j, i];
                                //swap(rows arr[i,k] by row arr[j,k] )
                                for (int k = 0; k < n; k++)
                                {
                                    double temp = arr2[i, k];
                                    arr2[i, k] = arr2[j, k];
                                    arr2[j, k] = temp;

                                    temp = inverseofarr2[i, k];
                                    inverseofarr2[i, k] = inverseofarr2[j, k];
                                    inverseofarr2[j, k] = temp;
                                }
                                swapped = true;
                            }
                            if (swapped) break;
                        }
                        if (!swapped)
                        {
                            Console.WriteLine();
                            Console.WriteLine("ERROR: ARRAY B DOESNT HAVE AN INVERSE!");
                            Console.ReadKey();
                        }
                    }

                    //making it 1
                    for (int u = 0; u < n; u++)
                    {
                        inverseofarr2[i, u] /= val;
                        arr2[i, u] /= val;
                    }
                    //making zeros above and below
                    for (int k = 0; k < n; k++)
                    {
                        if (k == i) continue;
                        double coff = arr2[k, i];

                        for (int l = 0; l < n; l++)
                        {
                            inverseofarr2[k, l] -= coff * inverseofarr2[i, l];
                            arr2[k, l] -= coff * arr2[i, l];
                        }
                    }
                }

                //multupling array 1 by the inverse of array 2:
                double[,] arr3 = new double[rows1, cols2];
                for (int i = 0; i < rows1; i++)
                {
                    for (int j = 0; j < cols2; j++)
                    {
                        for (int k = 0; k < cols1; k++)
                        {
                            arr3[i, j] += arr1[i, k] * inverseofarr2[k, j];
                        }
                    }
                }

                //displaying res:
                Console.WriteLine();
                Console.WriteLine("----------------( array(1) / array(2) )----------------");
                for (int i = 0; i < rows1; i++)
                {
                    for (int j = 0; j < cols2; j++)
                    {
                        Console.Write(arr3[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
        }
    }
}
