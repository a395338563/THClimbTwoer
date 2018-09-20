using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower.EnemyCard
{
    public class MaoyuHit : AbstractEnemyCard
    {
        public override EnemyPredict GetPredict()
        {
            EnemyPredict basePredict = this.BasePredict();
            return basePredict;
        }

        public override void CardLogic(AbstractCharactor reciver)
        {
            Model.Log.Debug($"{Owner.Name} hit the {reciver.Name}");
            //模拟等待技能动画
            //await Task.Delay(1000);
            reciver.ReciveDamage(new DamageInfo() { Damage = 15 });
        }
    }
}
