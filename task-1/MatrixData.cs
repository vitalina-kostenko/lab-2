using System;
using System.Linq;

public class MyMatrix
{
    private double[,] _matrix;


    public MyMatrix(MyMatrix other)
    {
        _matrix = (double[,])other._matrix.Clone();
    }

    public MyMatrix(double[,] array)
    {
        _matrix = (double[,])array.Clone();
    }

    public MyMatrix(double[][] jaggedArray)
    {
        if (!IsRectangular(jaggedArray))
            throw new Exception("Jagged array is not rectangular.");

        int rows = jaggedArray.Length;
        int cols = jaggedArray[0].Length;
        _matrix = new double[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                _matrix[i, j] = jaggedArray[i][j];
    }

    public MyMatrix(string[] rows)
    {
        int cols = rows[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;

        if (rows.Any(row => row.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length != cols))
            throw new Exception("Rows do not have the same number of elements.");

        _matrix = new double[rows.Length, cols];
        for (int i = 0; i < rows.Length; i++)
        {
            var values = rows[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(double.Parse).ToArray();

            for (int j = 0; j < cols; j++)
                _matrix[i, j] = values[j];
        }
    }

    public MyMatrix(string input)
    {
        var rows = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(r => r.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
                        .ToArray();

        int cols = rows[0].Length;

        for (int i = 1; i < rows.Length; i++)
        {
            if (rows[i].Length != cols)
                throw new Exception("Input does not represent a rectangular matrix.");
        }

        _matrix = new double[rows.Length, cols];
        for (int i = 0; i < rows.Length; i++)
            for (int j = 0; j < cols; j++)
                _matrix[i, j] = double.Parse(rows[i][j]);
    }


    public int Height
    {
        get { return _matrix.GetLength(0); }
    }

    public int Width
    {
        get { return _matrix.GetLength(1); }
    }


    public int getHeight() => Height;
    public int getWidth() => Width;

    //public int getHeight()
    //{
    //    return Height;
    //}

    //public int getWidth()
    //{
    //    return Width;
    //}


    public double this[int row, int col]
    {
        get { return _matrix[row, col]; }
        set { _matrix[row, col] = value; }
    }

    public double getElement(int row, int col)
    {
        return _matrix[row, col];
    }

    public void setElement(int row, int col, double value)
    {
        _matrix[row, col] = value;
    }


    public override string ToString()
    {
        var rows = new string[Height];
        for (int i = 0; i < Height; i++)
        {
            var row = new string[Width];
            for (int j = 0; j < Width; j++)
                row[j] = _matrix[i, j].ToString();

            rows[i] = string.Join("\t", row);
        }
        return string.Join(Environment.NewLine, rows);
    }

    // перевірка чи зубчастий масив прямокутний
    public static bool IsRectangular(double[][] jaggedArray)
    {
        int cols = jaggedArray[0].Length;

        foreach (var row in jaggedArray)
        {
            if (row.Length != cols) return false;

        }

        return true;
    }

}
