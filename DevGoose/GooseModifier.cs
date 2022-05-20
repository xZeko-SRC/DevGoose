using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DevGoose
{
    class GooseModifier : MonoBehaviour
    {

        public static GameObject _goose, _gooseB;

        public static Vector2 scrollPosition, scrollPosition1;
        private static int selectedItem;
        public static GameObject spawnItem;
        public static void ResizingBig()
        {
            GUILayout.Label("Bigger Size", new GUILayoutOption[0]);
            string[] clonepeeps = new string[] { "Goose", "gardener", "wimp", "tvshop", "shopkeeper", "neighbourClean", "neighbourMessyFixed", "cook", "pub man", "pub woman", "oldMan", "gossip2", "gossip1" };
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, new GUILayoutOption[0]);
            for (int l = 0; l < clonepeeps.Length; l++)
            {
                if (GUILayout.Button(clonepeeps[l], new GUILayoutOption[0]))
                {
                    selectedItem = l;
                    _goose = GameObject.Find("Goose");
                    spawnItem = GameObject.Find(clonepeeps[selectedItem]);
                    spawnItem.gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
                }
            }
            GUILayout.EndScrollView();
        }
        public static void ResizingSmall()
        {
            GUILayout.Label("Smaller Size", new GUILayoutOption[0]);
            string[] clonepeeps = new string[] { "Goose", "gardener", "wimp", "tvshop", "shopkeeper", "neighbourClean", "neighbourMessyFixed", "cook", "pub man", "pub woman", "oldMan", "gossip2", "gossip1" };
            scrollPosition1 = GUILayout.BeginScrollView(scrollPosition1, new GUILayoutOption[0]);
            for (int l = 0; l < clonepeeps.Length; l++)
            {
                if (GUILayout.Button(clonepeeps[l], new GUILayoutOption[0]))
                {
                    selectedItem = l;
                    _goose = GameObject.Find("Goose");
                    spawnItem = GameObject.Find(clonepeeps[selectedItem]);
                    spawnItem.gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
                }
            }
            GUILayout.EndScrollView();
        }
        public static void GoosetoGeese()
        {
            _goose = GameObject.Find("Goose");
            _gooseB = GameObject.Find("GooseB");
            _goose.transform.position = _gooseB.transform.position;

        }
        public static void GeesetoGoose()
        {
            _goose = GameObject.Find("Goose");
            _gooseB = GameObject.Find("GooseB");
            _gooseB.transform.position = _goose.transform.position;
        }

        

    }
}
