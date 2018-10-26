using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace THClimbTower
{
    public class EnemyTeamConfig :Model.BaseConfig
    {        
        public int[] Team;
        public Vector2[] Pos;

        public virtual void Init()
        {

        }
    }
}
