using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DevGoose
{
    public class Goose
    {
        public static GameObject _loadObject;
        public static void Inject()
        {
            bool flag = GameObject.Find("Main");
            if (flag)
            {
                foreach (object obj in Main._UDO)
                {
                    UnityEngine.Object @object = (UnityEngine.Object)obj;
                    UnityEngine.Object.Destroy(@object);
                }
                UnityEngine.Object.Destroy(GameObject.Find("Main").gameObject);
            }
            GameObject gameObject = new GameObject("Main");
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            gameObject.AddComponent<Main>();
            _loadObject = new GameObject();
            _loadObject.AddComponent<Menu>();
            _loadObject.AddComponent<SpeedrunItems>();
        }

        public static void Unhook()
        {
            foreach (object obj in Main._UDO)
            {
                UnityEngine.Object @object = (UnityEngine.Object)obj;
                UnityEngine.Object.Destroy(@object);
            }
            UnityEngine.Object.Destroy(GameObject.Find("Main").gameObject);
        }
    }
}
