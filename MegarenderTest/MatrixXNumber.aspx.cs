using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MegarenderTest
{
    public partial class MatrixXNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void calculate_Click(object sender, EventArgs e)
        {
            var matrixCalculator = new MatrixCalculator();
            var matrixA = new List<string>();
            var matrixRes = new List<TextBox>();
            var textboxes = Controls.FindAll().OfType<TextBox>();
            foreach (var tb in textboxes)
            {
                if (tb.ID.StartsWith("Matrix1"))
                    matrixA.Add(tb.Text);
                else if (tb.ID.StartsWith("Result"))
                    matrixRes.Add(tb);
            }
            var matrixCreatorA = new MatrixCreator(3);
            matrixCreatorA.Create(matrixA);
            var result = matrixCalculator.Compute(matrixCreatorA.matrix.Transpose(), double.Parse(Number.Text.Replace(',', '.'), CultureInfo.InvariantCulture), (a, b) => a * b);
            var matrix_size = 3;
            var x = 0;
            var y = 0;
            foreach (var element in matrixRes)
            {
                element.Text = result[y % matrix_size, x % matrix_size].ToString();
                x++;
                if (x % matrix_size == 0)
                    y++;
            }


        }
    }
}