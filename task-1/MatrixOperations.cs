using System;
using System.Linq;

public class MatrixOperations : MyMatrix
{
    public MatrixOperations(double[,] array) : base(array) { }

    public MatrixOperations(double[][] jaggedArray) : base(jaggedArray) { }

    public MatrixOperations(string[] rows) : base(rows) { }

    public MatrixOperations(string input) : base(input) { }

    public MatrixOperations(MyMatrix other) : base(other) { }

    public static MatrixOperations operator +(MatrixOperations m1, MatrixOperations m2)
    {
        if (m1.Height != m2.Height || m1.Width != m2.Width)
            throw new Exception("Matrices must have the same dimensions for addition.");

        double[,] result = new double[m1.Height, m1.Width];

        for (int i = 0; i < m1.Height; i++)
            for (int j = 0; j < m1.Width; j++)
                result[i, j] = m1[i, j] + m2[i, j];

        return new MatrixOperations(result);
    }

    public static MatrixOperations operator *(MatrixOperations m1, MatrixOperations m2)
    {
        if (m1.Width != m2.Height)
            throw new Exception("Number of columns in the first matrix must equal number of rows in the second matrix.");

        double[,] result = new double[m1.Height, m2.Width];

        for (int i = 0; i < m1.Height; i++)
            for (int j = 0; j < m2.Width; j++)
                for (int k = 0; k < m1.Width; k++)
                    result[i, j] += m1[i, k] * m2[k, j];

        return new MatrixOperations(result);
    }

    public MatrixOperations GetTransposedCopy()
    {
        double[,] transposed = new double[Width, Height];

        for (int i = 0; i < Height; i++)
            for (int j = 0; j < Width; j++)
                transposed[j, i] = this[i, j];

        return new MatrixOperations(transposed);
    }

    public void Transpose()
    {
        double[,] transposed = new double[Width, Height];

        for (int i = 0; i < Height; i++)
            for (int j = 0; j < Width; j++)
                transposed[j, i] = this[i, j];

        _matrix = transposed;
    }
}

