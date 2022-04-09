using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace DevGoose
{
    class ItemTask : MonoBehaviour
    {
        private static int selectedItem;

        public static Rect dropDownRect2 = new Rect(820f, 0f, 200f, 300f);
        public static Vector2 scrollPosition;

        public static void CompleteTasks()
        {
            string[] taskstr = GooseTask.itemTasks;
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, new GUILayoutOption[0]);
            for (int l = 0; l < taskstr.Length; l++)
            {
                if (GUILayout.Button(taskstr[l], new GUILayoutOption[0]))
                {
                    selectedItem = l;
                    SwitchEventManager.TriggerEvent("award-" + taskstr[selectedItem]);
                }
            }
            GUILayout.EndScrollView();
        }
    }
}
