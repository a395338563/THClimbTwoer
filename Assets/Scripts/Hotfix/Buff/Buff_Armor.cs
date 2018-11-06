using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THClimbTower;

namespace Hotfix.Buff
{
    //[EventWatcher(new EventType[] { EventType.BeforeDamageTake, EventType.PlayerTurnStart, EventType.PlayerTurnEnd})]
    [EventDispatcher(EventType.BeforeDamageTake, EventType.PlayerTurnStart, EventType.PlayerTurnEnd)]
    public class Buff_Armor : AbstractBuff, iEventDispatcher
    {
        public override string Icon { get; } = "Armor";

        public int SortIndex => 0;

        //public BaseEvent[] baseEvents { get; } = new BaseEvent[] { EventType.Event_BeforeDamageTake, EventType.Event_PlayerTurnStart, EventType.Event_PlayerTurnEnd };
        public void Handle(EventType eventType, params object[] param)
        {
            DamageInfo damage = param[0] as DamageInfo;
            if (eventType == EventType.BeforeDamageTake)
            {
                if (Amount > damage.Damage)
                {
                    Model.Log.Debug($"all {damage.Damage} point Damage have been avoid by armor");
                    Amount -= damage.Damage;
                    damage.Damage = 0;
                }
                else
                {
                    damage.Damage -= Amount;
                    Amount = 0;
                    Model.Log.Debug($"{Amount} point Damage have been avoid by armor,remain {damage.Damage}Point");
                }
            }
            else if (eventType == EventType.PlayerTurnStart)
            {
                Model.Log.Debug($"{(Parent as AbstractCharactor).Name} lose all armor at turn start");
                Amount = 0;
            }
        }
    }
}
