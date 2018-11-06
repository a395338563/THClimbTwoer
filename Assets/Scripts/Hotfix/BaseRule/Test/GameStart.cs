using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using THClimbTower;

namespace Hotfix.BaseRule
{
    [BaseEvent(1000)]
    [EventDispatcher(EventType.GameStart)]
    public class GameStart : iEventDispatcher
    {
        public int SortIndex => -100;

        public void Handle(EventType eventType, params object[] param)
        {
            AbstractCharactorConfig mainCharactor = param[0] as AbstractCharactorConfig;
            AbstractCharactorConfig helpCharactor = param[1] as AbstractCharactorConfig;
            THClimbTower.Game.Instance.player.Init(mainCharactor, helpCharactor);
            THClimbTower.Game.Instance.NowMap.ReBuild(5, 7, 16, 0);
        }
    }
}
