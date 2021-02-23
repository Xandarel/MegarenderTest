using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MegarenderTest
{
    interface IMatrixCreator
    {
        int squareSize { get; }
        bool Create(IEnumerable<string> data);
    }
    public class MatrixCreator : IMatrixCreator
    {
        public Matrix<double> matrix { get; private set; }
        public int squareSize { get; private set; }
        public MatrixCreator(int size)
        {
            squareSize = size;
        }
        public bool Create(IEnumerable<string> data)
        {
            var arrayMatrix = new double[squareSize, squareSize];
            var x = 0;
            var y = 0;
            foreach (var element in data)
            {
                arrayMatrix[x % squareSize, y % squareSize] = double.Parse(element.Replace(',', '.'), CultureInfo.InvariantCulture);
                x++;
                if (x % squareSize == 0)
                    y++;
            }
            try
            {
                matrix = Matrix<double>.Build.DenseOfArray(arrayMatrix);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}