using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class Game
    {
        private static Scene scene;

        public static Scene Scene
        {
            get
            {
                if (scene != null)
                    return scene;
                scene = new Scene();
                return scene;
            }
        }
        private static EventSystem eventSystem;

        public static EventSystem EventSystem
        {
            get
            {
                return eventSystem ?? (eventSystem = new EventSystem());
            }
        }
    }
}
