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
    public abstract class AbstractEnemyCard : AbstractCard
    {
        public abstract EnemyPredict GetPredict();

        public EnemyPredict BasePredict()
        {
            Game.EventSystem.RunEvent(EventType.GetCardFinalInfo);
            return new EnemyPredict()
            {
                Power = Damage,
                Hits = Hits,
                Armor = Armor,
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
