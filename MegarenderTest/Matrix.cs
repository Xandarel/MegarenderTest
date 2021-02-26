using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MegarenderTest
{
    public class Matrix: IMatrixCreator
    {
        public decimal[,] data;
        public int squareSize { get; private set; }
        public Matrix(int size)
        {
            squareSize = size;
            data = new decimal[size, size];
        }
        public Matrix(int size, decimal[,] data)
        {
            squareSize = size;
            this.data = data;
        }

        public decimal[] getRow(int row)
        {
            var result = new decimal[squareSize];
            for (var y = 0; y < squareSize; y++)
                result[y] = data[row, y];
            return result;
        }
        public decimal[] getColumn(int column)
        {
            var result = new decimal[squareSize];
            for (var x = 0; x < squareSize; x++)
                result[x] = data[x, column];
            return result;
        }

        private static decimal RowXColumn(decimal[] row, decimal[] column)
        {
            if (row.Length != column.Length)
                throw new Exception("Строка и столбец не равны по длинне");
            decimal res = 0;
            for (var index=0;index<row.Length;index++)
                res += row[index] * column[index];
            return res;
        }

        public bool Create(IEnumerable<string> data)
        {
            var x = 0;
            var y = 0;
            try
            {
                foreach (var element in data)
                {
                    this.data[y % squareSize, x % squareSize] = decimal.Parse(element.Replace(',', '.'), CultureInfo.InvariantCulture);
                    x++;
                    if (x % squareSize == 0)
                        y++;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.squareSize != b.squareSize)
                throw new Exception("Размеры матрицы не равны друг другу");
            var result = new decimal[a.squareSize, a.squareSize];
            for(var x=0;x<a.squareSize;x++)
                for(var y=0;y<a.squareSize;y++)
                    result[x, y] = a.data[x, y] + b.data[x, y];
            return new Matrix(a.squareSize, result);
        }

        public static Matrix operator *(Matrix a, decimal b)
        {
            var result = new decimal[a.squareSize, a.squareSize];
            for (var x = 0; x < a.squareSize; x++)
                for (var y = 0; y < a.squareSize; y++)
                    result[y, x] = a.data[y, x] * b;
            return new Matrix(a.squareSize, result);
        }
        public static Matrix operator *(decimal b, Matrix a) => new Matrix(a.squareSize, (a * b).data);

        public static Matrix operator -(Matrix a, Matrix b) => new Matrix(a.squareSize, (a + ((-1) * b)).data);

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.data.GetLength(0) != b.data.GetLength(1))
                throw new Exception("Матрицы невозможно умножить. Количество строк и столбцов отличается");
            var result = new decimal[a.squareSize, a.squareSize];
            for (var x = 0; x < a.data.GetLength(0); x++)
                for (var y = 0; y < b.data.GetLength(1); y++)
                    result[y, x] = RowXColumn(a.getRow(y), b.getColumn(x));
            return new Matrix(a.squareSize, result);
        }
    }
}