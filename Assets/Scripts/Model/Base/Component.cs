using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class Component
    {

        public long Id;

        public Entity Parent { get; set; }

        public virtual void Dispose()
        {

        }

        protected Component()
        {
            Id = IdGenerater.GenerateId();
        }
    }
}