using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public abstract class Enemy : BattleCharactor
    {
        public int X, Y;
        public EnemyCard SelectedSkill;
        protected abstract EnemyCard AIThink();

        public abstract void EnenmyInit();

        EnemyPredict predict;
        /// <summary>
        /// 每个回合开始时用此方法刷新怪物使用的技能
        /// </summary>
        public void TakeThink()
        {
            SelectedSkill = AIThink();
            Predict();            
        }
        /// <summary>
        /// 以玩家为目标使用预测的技能
        /// </summary>
        /// <returns></returns>
        public void UseSkill()
        {
            UseCard(SelectedSkill, Game.Instance.NowBattle.player);
        }
        public EnemyPredict GetPredict()
        {
            return predict;
        }
        public void Predict()
        {
            predict = SelectedSkill.GetPredict();
        }
    }
}
