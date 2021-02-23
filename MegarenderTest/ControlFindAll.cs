using System.Collections.Generic;
using System.Web.UI;

namespace MegarenderTest
{
    public static class ControlFindAll
    {
        public static IEnumerable<Control> FindAll(this ControlCollection collection)
        {
            foreach (Control item in collection)
            {
                yield return item;

                if (item.HasControls())
                {
                    foreach (var subItem in item.Controls.FindAll())
                    {
                        yield return subItem;
                    }
                }
            }
        }
    }
}