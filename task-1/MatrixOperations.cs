using System;

public class MatrixOperations
{
    private double[,] _matrix;

    public MatrixOperations(double[,] array)
    {
        if (array == null)
            throw new Exception("Matrix cannot be null.");
        _matrix = (double[,])array.Clone();
    }

    public double this[int row, int col]
    {
        get { return _matrix[row, col]; }
        set { _matrix[row, col] = value; }
    }

    public static MatrixOperations operator +(MatrixOperations m1, MatrixOperations m2)
    {
        if (m1.Height != m2.Height || m1.Width != m2.Width)
            throw new Exception("Matrices must have the same dimensions for addition.");

        double[,] result = new double[m1.Height, m1.Width];

        for (int i = 0; i < m1.Height; i++)
            for (int j = 0; j < m1.Width; j++)
                result[i, j] = m1._matrix[i, j] + m2._matrix[i, j];

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
                    result[i, j] += m1._matrix[i, k] * m2._matrix[k, j];

        return new MatrixOperations(result);
    }

    private double[,] GetTransposedArray()
    {
        double[,] transposed = new double[Width, Height];

        for (int i = 0; i < Height; i++)
            for (int j = 0; j < Width; j++)
                transposed[j, i] = _matrix[i, j];

        return transposed;
    }

    public MatrixOperations GetTransposedCopy()
    {
        double[,] transposedArray = GetTransposedArray();
        return new MatrixOperations(transposedArray);
    }

    public void Transpose()
    {
        _matrix = GetTransposedArray();
    }

    public int Height
    {
        get { return _matrix.GetLength(0); }
    }

    public int Width
    {
        get { return _matrix.GetLength(1); }
    }


    public static bool IsRectangular(double[][] jaggedArray)
    {
        if (jaggedArray.Length == 0) return true;

        int cols = jaggedArray[0].Length;
        foreach (var row in jaggedArray)
        {
            if (row.Length != cols) return false;
        }

        return true;
    }
}
