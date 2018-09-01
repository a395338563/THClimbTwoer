using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [GameUIView(UIViewType.Map)]
    public class MapView : GameUIView
    {
        public override string PackageName { get; set; } = "THClimbTower";

        public override string ViewName { get; set; } = "Map";

        public override void Creat()
        {
            
        }

        public override void OnEnter()
        {

        }
    }
}
