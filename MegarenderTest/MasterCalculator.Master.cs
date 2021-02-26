using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegarenderTest
{
    public partial class MasterCalculator : MasterPage
    {
        public Dictionary<string, Func<Matrix, Matrix, Matrix>> matrixSign;
        public Dictionary<string, Func<Matrix, decimal, Matrix>> numberSign;
        protected void Page_Load(object sender, EventArgs e)
        {
            matrixSign = new Dictionary<string, Func<Matrix, Matrix, Matrix>>
            {
                {"+", (x,y) => x+y},
                {"-", (x,y) => x+y},
                {"*", (x,y) => x*y},
            };
            numberSign = new Dictionary<string, Func<Matrix, decimal, Matrix>>
            {
                {"*", (x,y) => x*y}
            };
        }

        private IEnumerable<TextBox> GetTextboxes() => Controls.FindAll().OfType<TextBox>();
        public List<string> GetMatrixData(string startID)
        {
            var matrixA = new List<string>();
            var textboxes = GetTextboxes();
            foreach (var tb in textboxes.Where(x => x.ID.StartsWith(startID)))
                matrixA.Add(tb.Text);
            return matrixA;
        }
        public void SetMatrixData(string matrixID, Matrix matrix)
        {
            var textboxes = GetTextboxes();
            var x = 0;
            var y = 0;
            foreach (var res in textboxes.Where(a => a.ID.StartsWith(matrixID)).OrderBy(a=>a.ID))
            {
                res.Text = matrix.data[y % matrix.squareSize, x % matrix.squareSize].ToString();
                x++;
                if (x % matrix.squareSize == 0)
                    y++;
            }
        }
        //protected void calculate_Click(object sender, EventArgs e)
        //{
        //    var matrixA = new Matrix(3);
        //    matrixA.Create(GetMatrixData("Matrix1"));
        //}
    }
}