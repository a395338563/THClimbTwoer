using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public class MaoyuHit : EnemyCard
    {
        public override async Task<EnemyPredict> GetPredict()
        {
            EnemyPredict basePredict = await this.BasePredict();
            return basePredict;
        }

        public override async Task Use(BattleCharactor user, BattleCharactor reciver)
        {
            Model.Log.Debug($"{user.Name} hit the {reciver.Name}");
            //模拟等待技能动画
            await Task.Delay(1000);
            await reciver.ReciveDamage(new DamageInfo() { Damage = 15 });
        }
    }
}
