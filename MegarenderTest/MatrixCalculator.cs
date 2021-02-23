using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MegarenderTest
{
    interface ICalculate
    {

        Matrix<double> Compute(Matrix<double> a, Matrix<double> b, Func<Matrix<double>, Matrix<double>, Matrix<double>> sign);
        Matrix<double> Compute(Matrix<double> a, double b, Func<Matrix<double>, double, Matrix<double>> sign);
    }
    public class MatrixCalculator : ICalculate
    {
        public Matrix<double> Compute(Matrix<double> a, Matrix<double> b, Func<Matrix<double>, Matrix<double>, Matrix<double>> sign) => sign(a, b);

        public Matrix<double> Compute(Matrix<double> a, double b, Func<Matrix<double>, double, Matrix<double>> sign) => sign(a, b);
    }
}