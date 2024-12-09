using System;

internal class Run_MatrixTask
{
    public void RunMatrixTask()
    {
        try
        {
            Console.WriteLine("Введіть кількість рядків для матриці:");
            int rows = GetValidIntegerInput();

            Console.WriteLine("Введіть кількість стовпців для матриці:");
            int cols = GetValidIntegerInput();

            Console.WriteLine("\nВведення першої матриці:");
            MatrixOperations matrix1 = InputMatrix(rows, cols);

            Console.WriteLine("\nВведення другої матриці (розміри повинні збігатися):");
            MatrixOperations matrix2 = InputMatrix(rows, cols);

            Console.WriteLine("\nПерша матриця:");
            Console.WriteLine(matrix1);

            Console.WriteLine("\nДруга матриця:");
            Console.WriteLine(matrix2);

            Console.WriteLine("\nРезультат додавання матриць:");
            MatrixOperations sumMatrix = matrix1 + matrix2;
            Console.WriteLine(sumMatrix);

            if (matrix1.Width == matrix2.Height)
            {
                Console.WriteLine("\nРезультат множення матриць:");
                MatrixOperations productMatrix = matrix1 * matrix2;
                Console.WriteLine(productMatrix);
            }
            else
            {
                Console.WriteLine("\nМноження неможливе: кількість стовпців першої матриці не дорівнює кількості рядків другої матриці.");
            }

            Console.WriteLine("\nТранспонована перша матриця:");
            MatrixOperations transposedMatrix = matrix1.GetTransposedCopy();
            Console.WriteLine(transposedMatrix);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    static MatrixOperations InputMatrix(int rows, int cols)
    {
        double[,] matrix = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            while (true)
            {
                Console.WriteLine($"Введіть елементи для {i + 1}-го рядка (через пробіл):");
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
                            continue;
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

        return new MatrixOperations(matrix);
    }

    static int GetValidIntegerInput()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
                return value;

            Console.WriteLine("Будь ласка, введіть позитивне ціле число.");
        }
    }
}

