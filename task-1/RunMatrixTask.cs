using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Run_MatrixTask
{
    public void RunMatrixTask()
    {
        Console.WriteLine("Введіть кількість рядків для матриці:");
        int rows = GetValidIntegerInput();

        Console.WriteLine("Введіть кількість стовпців для матриці:");
        int cols = GetValidIntegerInput();

        double[,] matrix = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            while (true)
            {
                Console.WriteLine($"Введіть значення {i + 1}-го рядка матриці (відокремлюючи пробілами):");
                string input = Console.ReadLine();

                string[] rowValues = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (rowValues.Length == cols)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (double.TryParse(rowValues[j], out double value))
                        {
                            matrix[i, j] = value;
                        }
                        else
                        {
                            Console.WriteLine("Введено некоректне число. Спробуйте ще раз.");
                            return; 
                        }
                    }
                    break; 
                }
                else
                {
                    Console.WriteLine($"Кількість значень у рядку не відповідає кількості стовпців ({cols}). Спробуйте ще раз.");
                }
            }
        }

        Console.WriteLine("\nВведена матриця:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static int GetValidIntegerInput()
    {
        int value;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out value) && value > 0)
                return value;
            else
                Console.WriteLine("Будь ласка, введіть позитивне ціле число.");
        }
    }
}

