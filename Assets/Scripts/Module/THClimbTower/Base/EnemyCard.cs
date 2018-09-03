using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    /// <summary>
    /// 怪物使用的技能，需要实现预测
    /// </summary>
    public abstract class EnemyCard : Card
    {
        public abstract Task<EnemyPredict> GetPredict();

        public async Task<EnemyPredict> BasePredict()
        {
            Card card= await Game.EventSystem.RunEvent(EventType.GetCardDesc, this);
            return new EnemyPredict()
            {
                Power = card.Damage,
                Hits = card.Hits,
                Armor = card.Armor,
            };
        }
    }
    public class EnemyPredict : Model.Entity
    {
        public int Power;
        public int Hits;
        public int Armor;
        public bool Buff;
        public bool Debuff;
        public bool SpDebuff;
    }
}
