using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model
{
    public class Entity
    {
        //private HashSet<Component> components;

        public long Id;

        private Dictionary<Type, Component> componentDict = new Dictionary<Type, Component>();

        protected Entity()
        {
            Id = IdGenerater.GenerateId();
        }

        public T AddComponent<T>()where T : Component, new()
        {
            Type type = typeof(T);
            if (this.componentDict.ContainsKey(type))
            {
                throw new Exception($"AddComponent, component already exist, component: {typeof(T).Name}");
            }
            T component = new T();
            component.Parent = this;
            componentDict.Add(type, component);
            Game.EventSystem.Add(component);
            return component;
        }
        public void RemoveComponent<T>() where T : Component
        {
            Type type = typeof(T);
            Component component;
            if (!componentDict.TryGetValue(type,out component))
            {
                return;
            }
            componentDict.Remove(type);

            component.Dispose();
        }
        public T GetComponent<T>()where T : Component
        {
            Component component;
            if (!this.componentDict.TryGetValue(typeof(T), out component))
            {
                return default(T);
            }
            return (T)component;
        }
        public Component[] GetComponents()
        {
            return this.componentDict.Values.ToArray();
        }
        public virtual void Dispose()
        {

        }
    }
}