using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegarenderTest
{
    delegate double MathFunc(double a);
    class Parcer
    {
        private static string[] func = { "sin", "cos", "ctan", "tan" };
        private const string RegexNum = @"([0-9]*[.,])?[0-9]+";
        private const string RegexMulOp = @"[\*\/^%]";
        private const string RegexAddOp = @"[\+\-]";

        private MathFunc getFunc(int func_pos)
        {
            if (func_pos == 0)
                return Math.Sin;
            else if (func_pos == 1)
                return Math.Cos;
            else if (func_pos == 2)
                return Math.Tan;
            else
                return Math.Tan;
        }
            

        public double parse(string text)
        {
            for (int i = 0; i < func.Length; i++)
            {
                Match matchFunc = Regex.Match(text, string.Format(@"{0}\(({1})\)", func[i], @"[1234567890\.\+\-\*\/^%]*"));
                if (matchFunc.Groups.Count > 1)
                {
                    var inner = matchFunc.Groups[0].Value.Substring(1 + func[i].Length, matchFunc.Groups[0].Value.Trim().Length - 2 - func[i].Length);
                    var left = text.Substring(0, matchFunc.Index);
                    var right = text.Substring(matchFunc.Index + matchFunc.Length);
                    if (i == 2)
                        inner = (1 / getFunc(i)(parse(inner) * Math.PI / 180)).ToString();
                    else
                        inner = getFunc(i)(parse(inner) * Math.PI / 180.0).ToString();
                    return parse(left + inner + right);
                }
            }
            var matchSk = Regex.Match(text, string.Format(@"\(({0})\)", @"[1234567890\.\+\-\*\/^%]*"));
            if (matchSk.Groups.Count > 1)
            {
                string inner = matchSk.Groups[0].Value.Substring(1, matchSk.Groups[0].Value.Trim().Length - 2);
                string left = text.Substring(0, matchSk.Index);
                string right = text.Substring(matchSk.Index + matchSk.Length);
                return parse(left + parse(inner) + right);
            }

            var matchMulOp = Regex.Match(text, string.Format(@"({0})\s?({1})\s?({0})\s?", RegexNum, RegexMulOp));
            var matchAddOp = Regex.Match(text, string.Format(@"({0})\s?({1})\s?({2})\s?", RegexNum, RegexAddOp, RegexNum));
            var match = (matchMulOp.Groups.Count > 1) ? matchMulOp : (matchAddOp.Groups.Count > 1) ? matchAddOp : null;
            if (match != null)
            {
                string left = text.Substring(0, match.Index);
                string right = text.Substring(match.Index + match.Length);
                string val = ParseAct(match).ToString(CultureInfo.InvariantCulture);
                //string val = Convert.ToDouble(match, CultureInfo.InvariantCulture);
                return parse(string.Format("{0}{1}{2}", left, val, right));
            }
            try
            {
                //return Convert.ToDouble(text, CultureInfo.InvariantCulture);
                return double.Parse(text.Replace(',', '.'), CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                throw new FormatException(string.Format("Неверная входная строка '{0}'", text));
            }

        }

        private double ParseAct(Match match)
        {
            var sign_dict = new Dictionary<string, Func<double, double, double>>
            {
                { "+", (x, y) => x + y},
                {"-", (x, y) => x-y},
                {"*", (x, y) => x*y},
                {"/", (x, y) => x/y},
                {"^", (x, y) => Math.Pow(x,y)},
                {"%", (x, y) => x%y}
            };  
        
            double a = double.Parse(match.Groups[1].Value.Replace(',', '.'), CultureInfo.InvariantCulture);
            double b = double.Parse(match.Groups[4].Value.Replace(',', '.'), CultureInfo.InvariantCulture);
            var sign = match.Groups[3].Value;
            try
            {
                return sign_dict[sign](a, b);
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException(string.Format("Неверный математический символ: {0}", sign));
            }
        }

    }
    public partial class Calculator : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void calculate_Click(object sender, EventArgs e)
        {
            var parcer = new Parcer();
            var res = parcer.parse(txt1.Text);
            result.Text = res.ToString();
        }
    }
}