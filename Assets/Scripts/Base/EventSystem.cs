using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EventSystem : Component
    {
        Dictionary<long, IUpdate> UpdateComponent = new Dictionary<long, IUpdate>();

        public void Add(Component component)
        {
            if (component is IAwake)
            {
                (component as IAwake).Awake();
            }
            if (component is IUpdate)
            {
                //updateSystems.Add(component.GetType(), component as IUpdate);
                UpdateComponent.Add(component.Id, component as IUpdate);
            }
        }

        public void Remove(Component component)
        {
            if (component is IUpdate)
            {
                UpdateComponent.Remove(component.Id);
            }
        }

        public void Update()
        {
            foreach (var iupdate in UpdateComponent)
            {
                iupdate.Value.Update();
            }
        }
    }
}
