using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public class Battle : Model.Entity
    {
        public Player player => Game.Instance.player;
        public List<AbstractEnemy> Enemys = new List<AbstractEnemy>();
        public List<AbstractPlayerCard> Deck = new List<AbstractPlayerCard>(), Hand = new List<AbstractPlayerCard>(), Cemetery = new List<AbstractPlayerCard>(), Gap = new List<AbstractPlayerCard>();
        public int Turn;

        /// <summary>
        /// 玩家使用一张牌
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="reciver">目标，可为空</param>
        /*public void PlayerUseCard(int Index, AbstractCharactor reciver)
        {
            AbstractCard card = Hand[Index];
            player.UseCard(card, reciver);
        }*/
        /// <summary>
        /// 开始一场新的战斗
        /// </summary>
        /// <param name="enemyTeam"></param>
        /// <param name="enemies"></param>
        /// <returns></returns>
        /*public void StartBattle(EnemyTeamConfig enemyTeam)
        {
            Deck = new List<AbstractPlayerCard>();
            Hand = new List<AbstractPlayerCard>();
            Cemetery = new List<AbstractPlayerCard>();
            Gap = new List<AbstractPlayerCard>();
            player = Game.Instance.player;
            Enemys = new List<AbstractEnemy>();
            for (int i = 0; i < enemyTeam.Team.Length; i++)
            {
                int Id = enemyTeam.Team[i];
                AbstractEnemy e = Game.Instance.GetComponent<EnemyFatory>().Get(Id);
                e.X = enemyTeam.Pos[i].x;
                e.Y = enemyTeam.Pos[i].x;
                Enemys.Add(e);
            }
            Turn = 0;
            GameEnd = false;

            foreach (AbstractPlayerCard p in player.Deck)
            {
                Deck.Add(p);
            }
            Game.EventSystem.RunEvent(EventType.BattleStart);
            PlayerTurnStart();
        }*/

        /// <summary>
        /// 预测敌人行动
        /// </summary>
        /// <returns></returns>
        /*public async Task<List<EnemyPredict>> GetPredict()
        {
            List<EnemyPredict> list = new List<EnemyPredict>();
            foreach (Enemy e in Enemys)
            {
                e.Predict();
                list.Add(p);
            }
            return list;
        }*/
        /// <summary>
        /// 结束当前回合
        /// </summary>
        /*public void EndTurn()
        {
            PlayerEndTurn();
            Model.Log.Debug("GoNextTurn");
            Turn++;
            //PlayerTurnTcs.SetResult(true);
        }

        public void CheckWin()
        {
            if (player.NowHp <= 0)
            {
                Fail();
            }
            bool Win = true;
            for (int i = Enemys.Count - 1; i >= 0; i--)
            {
                AbstractEnemy e = Enemys[i];
                if (e.NowHp > 0)
                    Win = false;
                else
                {
                    Enemys.Remove(e);
                }
            }
            if(Win) this.Win();
        }

        void Win()
        {
            Model.Log.Debug("Win a battle");
        }
        void Fail()
        {
            Model.Log.Debug("U die");
        }

        void PlayerTurnStart()
        {
            Game.Instance.EventSystem.Call(EventType.PlayerTurnStart);
            DrawCard();
            foreach (AbstractEnemy e in Enemys)
            {
                e.TakeThink();
            }
            foreach (AbstractPlayerCard c in Hand)
            {
                Game.Instance.EventSystem.Call(EventType.GetCardFinalInfo, c, player, null);
            }
        }

        void PlayerEndTurn()
        {
            ThrowAllCard();
            foreach (AbstractEnemy e in Enemys)
            {
                e.UseSkill();
            }
            //await Game.EventSystem.RunEvent(EventType.PlayerTurnEnd, 0);
            //EnemyWorks
        }

        void ThrowAllCard()
        {
            foreach (AbstractPlayerCard c in Hand)
            {
                Cemetery.Add(c);
            }
            Hand.Clear();
        }*/

        /*void DrawCard()
        {
            int DrawNum = 5; //await Game.EventSystem.RunEvent(EventType.BeforeDrawCard, 5);
            for (int i = 0; i < DrawNum; i++)
            {
                //卡组为0，切洗牌组
                if (Deck.Count == 0)
                {
                    if (Cemetery.Count == 0)
                    {
                        //墓地也没卡的话就不抽了
                        break;
                    }
                    foreach (AbstractPlayerCard c in Cemetery)
                    {
                        Deck.Add(c);
                    }
                    Cemetery.Clear();
                    Flush();
                    i--;
                }
                else
                {
                    Hand.Add(Deck[0]);
                    //ETModel.Log.Debug($"Drwa:{Deck[0].Desc}");
                    Deck.RemoveAt(0);                
                }
            }
        }
        void Flush()
        {
            Model.Log.Warning("洗牌！但是尚未实现该功能");
        }*/
    }
}
