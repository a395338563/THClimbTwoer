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
        public static Game Instance
        {
            get
            {
                return instance ?? (instance = new Game());
            }
        }
        private static Game instance;

        public EventSystem EventSystem = new EventSystem();

        public Player player = new Player();
        public Battle NowBattle = new Battle();

        public Map NowMap = new Map();
        
        public void StartGame(AbstractCharactorConfig mainCharactor, AbstractCharactorConfig helpCharactor,int Seed=0)
        {
            RandomUtil.SetSeed(Seed);
            EventSystem.Call(EventType.GameStart, mainCharactor, helpCharactor);
            /*player = new Player()
            {
                MainCharactorType = mainCharactor,
                HelpCharactorType = helpCharactor,
            };
            player.Init();*/
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
    }
}
