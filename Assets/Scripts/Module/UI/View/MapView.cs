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
        public override string PackageName { get; set; } = "UI";

        public override string ViewName { get; set; } = "Map";

        public override void Creat()
        {
            
        }

        public override void OnEnter()
        {
            THClimbTower.Game.Instance.StartGame(THClimbTower.CharactorTypeEnum.Reimu, THClimbTower.CharactorTypeEnum.Alice);
            THClimbTower.Map map = THClimbTower.Game.Instance.NowMap;
            foreach (var a in map.tiles)
            {
                Log.Debug($"{a.Level},{a.TileType}");
            }
        }
    }
}
