using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyGUI;
using THClimbTower;
using THClimbTower.Buff;

namespace Model
{
    public class UICharactor
    {
        GList buffList;
        GProgressBar GBar;
        AbstractCharactor charactor;
        Controller ArmorController;

        const int MinHpWidth = 150, MaxHpWidth = 500, MaxHpValue = 150;
        public UICharactor(GComponent gCharactor,AbstractCharactor charactor)
        {
            GBar = gCharactor.GetChild("bar").asProgress;
            buffList = GBar.GetChild("BuffList").asList;
            ArmorController = GBar.GetController("BlockVisable");
            this.charactor = charactor;
            Fresh();
        }

        public void Fresh()
        {
            SetMaxHp(charactor.MaxHp);
            SetHp(charactor.NowHp);

            ArmorController.selectedIndex = charactor.GetBuff<Buff_Armor>().Amount > 0 ? 0 : 1;
            GBar.text = $"{charactor.NowHp}/{charactor.MaxHp}";
            GBar.GetChild("Block").text = charactor.Armor.ToString();

            buffList.RemoveChildrenToPool();
            foreach (var buff in charactor.GetBuffs())
            {
                GComponent g = buffList.AddItemFromPool().asCom;
                g.icon = buff.Icon;
                g.text = buff.Amount == 0 ? "" : buff.Amount.ToString();
            }
        }

        /// <summary>
        /// 最大血量会影响血条长度
        /// </summary>
        /// <param name="maxHp"></param>
        public void SetMaxHp(int maxHp)
        {
            GBar.width = ((float)maxHp / MaxHpValue) * (MaxHpWidth - MinHpWidth) + MinHpWidth;
            GBar.max = maxHp;
        }
        public void SetHp(int hp)
        {
            GBar.value = hp;
        }
    }
}
