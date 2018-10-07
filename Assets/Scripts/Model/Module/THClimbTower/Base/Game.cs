using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace THClimbTower
{
    /// <summary>
    /// 游戏顶层入口，可以查到当前游戏所有信息
    /// </summary>
    public class Game:Entity
    {
        private static EventSystem eventSystem;
        public static EventSystem EventSystem
        {
            get
            {
                if (eventSystem == null)
                {
                    eventSystem = new EventSystem();
                    //eventSystem.Awake();
                    instance.AddBaseEvent();    
                }
                return eventSystem;
            }
        }

        public static Game Instance
        {
            get
            {
                return instance ?? (instance = new Game());
            }
        }
        private static Game instance;

        public Player player;
        public Battle NowBattle;

        public Map NowMap;
        
        public async void StartGame(CharactorTypeEnum mainCharactor, CharactorTypeEnum helpCharactor)
        {
            /*Model.Game.Scene.AddComponent<CardFactory>();
            Instance.player = new Player()
            {
                MainCharactorType = mainCharactor,
                HelpCharactorType = helpCharactor,
            };
            player.Init();
            player.AddBuff<Buff_Str>().Amount = 1;

            RandomUtil.SetSeed(1);

            instance.NowMap = new Map();
            //NowMap.Creat(5, 0);
            NowBattle = new Battle();
            NowBattle.StartBattle(new List<AbstractEnemy>() { new Maoyu() });
            Log.Debug("战斗结束！");*/
        }

        void AddBaseEvent()
        {

            //EventSystem.AddDispatcher(new BaseCardDescFinal());
            //EventSystem.AddDispatcher(new BaseCardDescFirst());
            //EventSystem.AddDispatcher(new CheckBattleEnd());
        }
    }
}
