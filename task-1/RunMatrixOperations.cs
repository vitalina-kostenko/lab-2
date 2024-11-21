using System;
using System.Text.RegularExpressions;

internal class Run_MatrixOperations
{
    public void RunMatrixOperations()
    {
        try
        {
            Console.WriteLine("Введіть кількість рядків для першої матриці:");
            int rows1 = GetValidPositiveInteger();

            Console.WriteLine("Введіть кількість стовпців для першої матриці:");
            int cols1 = GetValidPositiveInteger();

            double[,] matrix1Data = new double[rows1, cols1];

            Console.WriteLine("Введіть перші значення матриці рядок за рядком, відокремлюючи пробілами:");
            for (int i = 0; i < rows1; i++)
            {
                while (true)
                {
                    string[] rowValues = GetValidRowInput(cols1);

                    bool isValidRow = true;
                    for (int j = 0; j < cols1; j++)
                    {
                        if (!double.TryParse(rowValues[j], out matrix1Data[i, j]))
                        {
                            Console.WriteLine($"Некоректне значення у рядку {i + 1}, стовпці {j + 1}. Введіть числове значення.");
                            isValidRow = false;
                            break;
                        }
                    }

                    if (isValidRow)
                        break;
                }
            }

            Console.WriteLine("Введіть кількість рядків для другої матриці:");
            int rows2 = GetValidPositiveInteger();

            Console.WriteLine("Введіть кількість стовпців для другої матриці:");
            int cols2 = GetValidPositiveInteger();

            double[,] matrix2Data = new double[rows2, cols2];

            Console.WriteLine("Введіть значення другої матриці рядок за рядком, відокремлюючи пробілами:");
            for (int i = 0; i < rows2; i++)
            {
                while (true)
                {
                    string[] rowValues = GetValidRowInput(cols2);

                    bool isValidRow = true;
                    for (int j = 0; j < cols2; j++)
                    {
                        if (!double.TryParse(rowValues[j], out matrix2Data[i, j]))
                        {
                            Console.WriteLine($"Некоректне значення у рядку {i + 1}, стовпці {j + 1}. Введіть числове значення.");
                            isValidRow = false;
                            break;
                        }
                    }

                    if (isValidRow)
                        break;
                }
            }

            MatrixOperations matrix1 = new MatrixOperations(matrix1Data);
            MatrixOperations matrix2 = new MatrixOperations(matrix2Data);

            Console.WriteLine("Матриця 1:");
            PrintMatrix(matrix1);
            Console.WriteLine("Матриця 2:");
            PrintMatrix(matrix2);

            if (matrix1.Height != matrix2.Height || matrix1.Width != matrix2.Width)
            {
                Console.WriteLine("Неможливо додати матриці, їх розміри не співпадають.");
            }
            else
            {
                MatrixOperations resultAdd = matrix1 + matrix2;
                Console.WriteLine("\nРезультат матриці 1 + матриця 2:");
                PrintMatrix(resultAdd);
            }

            if (matrix1.Width != matrix2.Height)
            {
                Console.WriteLine("Неможливо перемножити матриці, кількість стовпців першої матриці не дорівнює кількості рядків другої матриці.");
            }
            else
            {
                MatrixOperations resultMul = matrix1 * matrix2;
                Console.WriteLine("\nРезультат матриці 1 * матриця 2:");
                PrintMatrix(resultMul);
            }

            MatrixOperations transposedMatrix = matrix1.GetTransposedCopy();
            Console.WriteLine("\nТранспонована матриця 1:");
            PrintMatrix(transposedMatrix);

            matrix1.Transpose();
            Console.WriteLine("\nМатриця 1 після транспонування на місці:");
            PrintMatrix(matrix1);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private bool IsValidNumber(string value)
    {
        return Regex.IsMatch(value, @"^[0-9]*\.?[0-9]+$");
    }

    private int GetValidPositiveInteger()
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

    private string[] GetValidRowInput(int expectedCols)
    {
        while (true)
        {
            string input = Console.ReadLine();

            string[] rowValues = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (rowValues.Length == expectedCols)
                return rowValues;
            else
            {
                Console.WriteLine($"Кількість значень у рядку не відповідає кількості стовпців ({expectedCols}). Спробуйте ще раз.");
            }
        }
    }

    private void PrintMatrix(MatrixOperations matrix)
    {
        for (int i = 0; i < matrix.Height; i++)
        {
            for (int j = 0; j < matrix.Width; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
