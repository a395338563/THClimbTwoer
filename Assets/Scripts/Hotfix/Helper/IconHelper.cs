using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotfix
{
    public static class IconHelper
    {
        public static string GetHeadIcon(string name)
        {
            return "ui://Image_HeadIcon/" + name;
        }
    }
}
