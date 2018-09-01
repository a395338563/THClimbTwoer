using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public abstract class Enemy : Charactor
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
        public Task UseSkill()
        {
            return UseCard(SelectedSkill, Game.Instance.NowBattle.player);
        }
        public EnemyPredict GetPredict()
        {
            return predict;
        }
        public async void Predict()
        {
            predict = await SelectedSkill.GetPredict();
        }
    }
}
