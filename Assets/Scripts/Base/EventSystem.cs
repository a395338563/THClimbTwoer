using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EventSystem : Component
    {
        //UnOrderMultiMap<Type, IAwake> awakeSystems = new UnOrderMultiMap<Type, IAwake>();

        //UnOrderMultiMap<Type, IUpdate> updateSystems = new UnOrderMultiMap<Type, IUpdate>();

        //List<IUpdate> UpdateComponent = new List<IUpdate>();

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

        public void Update()
        {
            foreach (var iupdate in UpdateComponent)
            {
                iupdate.Value.Update();
            }
        }
    }
}
