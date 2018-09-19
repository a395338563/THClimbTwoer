using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public class MaoyuHit : EnemyCard
    {
        public override EnemyPredict GetPredict()
        {
            EnemyPredict basePredict = this.BasePredict();
            return basePredict;
        }

        public override void Use(BattleCharactor user, BattleCharactor reciver)
        {
            Model.Log.Debug($"{user.Name} hit the {reciver.Name}");
            //模拟等待技能动画
            //await Task.Delay(1000);
            reciver.ReciveDamage(new DamageInfo() { Damage = 15 });
        }
    }
}
