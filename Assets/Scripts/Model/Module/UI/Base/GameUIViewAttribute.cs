using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GameUIViewAttribute : Attribute
    {
        public UIViewType Type;
        public GameUIViewAttribute(UIViewType Type)
        {
            this.Type = Type;
        }
    }
}
