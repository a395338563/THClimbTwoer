using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyGUI;
using THClimbTower;
using UnityEngine;

namespace Hotfix.UIModule
{
    public class UICurve
    {
        GComponent main;
        public UICurve(GComponent component)
        {
            main = component;
        }
        public void ChangeShape(Vector2 start,Vector2 end,Vector2 control)
        {
            Vector2 Last = start;
            for (int i = 1; i < 20; i++)
            {
                Vector2 pos = BezierHelper.Quadratic(i / 20f, start, end, control);
                Vector2 delta = pos - Last;
                delta.y *= -1;
                if (i > 0)
                {
                    main.GetChild($"n{i - 1}").rotation = 360 - Vector2.SignedAngle(Vector2.up, delta);
                }
                if (i == 19)
                {
                    main.GetChild($"n{i-1}").rotation = 360 - Vector2.SignedAngle(Vector2.up, delta);
                    main.GetChild("Head").rotation = 360 - Vector2.SignedAngle(Vector2.up, delta);
                }
                main.GetChild($"n{i-1}").xy = pos;
                Last = pos;
            }
            main.GetChild("Head").xy = end;
        }
    }
}
