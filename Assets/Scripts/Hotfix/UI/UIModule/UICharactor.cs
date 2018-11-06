using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyGUI;
using THClimbTower;
using Hotfix.Buff;

namespace Hotfix.UIModule
{
    public class UICharactor
    {
        GList buffList;
        GProgressBar GHpBar;
        AbstractCharactor charactor;
        Controller ArmorController;

        const int MinHpWidth = 150, MaxHpWidth = 500, MaxHpValue = 150;
        public UICharactor(GComponent gCharactor,AbstractCharactor charactor)
        {
            GHpBar = gCharactor.GetChild("HpBar").asProgress;
            buffList = gCharactor.GetChild("BuffList").asList;
            //ArmorController = GHpBar.GetController("BlockVisable");
            this.charactor = charactor;
            Fresh();
        }

        public void Fresh()
        {
            SetMaxHp(charactor.MaxHp);
            SetHp(charactor.NowHp);

            ArmorController.selectedIndex = charactor.GetBuff<Buff_Armor>().Amount > 0 ? 0 : 1;
            //GHpBar.text = $"{charactor.NowHp}/{charactor.MaxHp}";
            //GHpBar.GetChild("Block").text = charactor.GetBuff<Buff_Armor>().Amount.ToString();

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
            GHpBar.width = ((float)maxHp / MaxHpValue) * (MaxHpWidth - MinHpWidth) + MinHpWidth;
            GHpBar.max = maxHp;
        }
        public void SetHp(int hp)
        {
            GHpBar.value = hp;
        }
    }
}
