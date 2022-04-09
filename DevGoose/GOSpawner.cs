using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace DevGoose
{
    class GOSpawner : MonoBehaviour
    {
        private static int selectedItem;

        public static GameObject spawnItem, _goose;
        public static Rect dropDownRect2 = new Rect(820f, 0f, 200f, 300f);
        public static Vector2 scrollPosition;

        public static void GOSpawners()
        {
            string[] allitems = Constants.allitems;
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, new GUILayoutOption[0]);
            for (int l = 0; l < allitems.Length; l++)
            {
                if (GUILayout.Button(allitems[l], new GUILayoutOption[0]))
                {
                    selectedItem = l;
                    _goose = GameObject.Find("Goose");
                    spawnItem = GameObject.Find(allitems[selectedItem]);
                    spawnItem.gameObject.transform.position = _goose.transform.position;
                    GameObject.Instantiate(spawnItem, _goose.transform.position, _goose.transform.rotation);
                    spawnItem.name = "Clone";
                    spawnItem.transform.position = _goose.transform.position + _goose.gameObject.transform.forward * 1f;
                }
            }
            GUILayout.EndScrollView();
        }
    }
}
