using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace THClimbTower
{
    public static class BezierHelper
    {
        public static Vector2 Quadratic(float t, Vector2 p0, Vector2 p1, Vector2 p2)
        {
            float dt = 1 - t;
            return p0 * dt * dt + p2 * 2 * dt * t + p1 * t * t;
        }
    }
}
