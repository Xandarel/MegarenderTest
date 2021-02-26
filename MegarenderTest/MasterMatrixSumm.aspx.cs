using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegarenderTest
{
    public partial class MasterMatrixSumm : System.Web.UI.Page
    {
        MasterCalculator m;
        protected void Page_Load(object sender, EventArgs e)
        {
            m = (MasterCalculator)Page.Master;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var matrixA = new Matrix(3);
            matrixA.Create(m.GetMatrixData("Matrix1"));
            var matrixB = new Matrix(3);
            matrixB.Create(m.GetMatrixData("Matrix2"));
            m.SetMatrixData("Result",m.matrixSign["+"](matrixA,matrixB));
        }
    }
}