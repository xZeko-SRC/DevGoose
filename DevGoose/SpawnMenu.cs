using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace GooseTools
{
    class SpawnMenu
    {
        public static bool ShowHide = false, Spawn = false;
        public GameObject _bell;
        public GameObject _goose;
        public static int TSpeed = 1;
        public bool menu1;
        public string string1;
        public void Start()
        {
            this._bell = GameObject.Find("goldenBell");
            this._goose = GameObject.Find("Goose");
        }
        public void Calling()
        {

            //
            if (GUI.Button(new Rect(20, 300, 160, 20), "GooseTools Menu"))
            {
                //ShowHide = !ShowHide;
                showItemList = !showItemList;
            }
            if (ShowHide)
            {
                if (GUI.Button(new Rect(0, 0, Screen.width, Screen.height), "Spawn Menu"))
                {
                    Spawn = !Spawn;
                }
                if (Spawn)
                {

                    GUI.Box(new Rect(30, 300, 170, 150), "Spawn Menu");
                    // if (GUI.Toggle(new Rect(1120f, 325f, 200f, 20f), showItemList, "Show Item Spawner") != showItemList)
                    // {
                    //     showItemList = !showItemList;
                    // }
                }
                GUI.Box(new Rect(20, 300, 170, 150), "GooseTools Menu");

                //if (GUI.Button(new Rect(25, 80, 160f, 30f), "Bell"))
                //{
                //    _bell.gameObject.transform.position = _goose.transform.position;
                //    Time.timeScale++;
                //}
                if (GUI.Button(new Rect(25, 330, 160f, 30f), string1))
                {
                    menu1 = !menu1;
                }
                if (menu1)
                {
                    string1 = "No Clip <color=green>ON</color>";
                    menu1 = true;
                    // _noclip = true;
                }
                else
                {
                    string1 = "No Clip <color=red>OFF</color>";
                    menu1 = false;
                    // _noclip = false;
                }
                if (GUI.Button(new Rect(25, 360, 160f, 30f), "Speed Up"))
                {
                    Time.timeScale++;
                }
                if (GUI.Button(new Rect(25, 390, 160f, 30f), "Speed Down"))
                {
                    //Time.timeScale--;
                    showItemList = !showItemList;
                }


            }
        }


        public static Rect dropDownRect2 = new Rect(820f, 0f, 200f, 300f);
        public static bool showItemList;
        public static int selectedItem;
        public static Vector2 scrollViewVector;
        public static GameObject spawnItem;
        public static string itemSelect;

        public void spawnItemMenu()
        {
            if (showItemList)
            {
                string[] allitems = Constants.allitems;
                GUI.Label(new Rect(520f, 225f, 200f, 20f), "Item Spawner:");
                scrollViewVector = GUI.BeginScrollView(new Rect(dropDownRect2.x - 100f, dropDownRect2.y + 25f, dropDownRect2.width, dropDownRect2.height), scrollViewVector, new Rect(0f, 0f, dropDownRect2.width, Mathf.Max(dropDownRect2.height, (float)(allitems.Length * 25))));
                GUI.Box(new Rect(0f, 0f, dropDownRect2.width, Mathf.Max(dropDownRect2.height, (float)(allitems.Length * 25))), "");
                for (int l = 0; l < allitems.Length; l++)
                {
                    if (GUI.Button(new Rect(0f, (float)(l * 25), dropDownRect2.height, 25f), ""))
                    {
                        selectedItem = l;
                        this._goose = GameObject.Find("Goose");
                        itemSelect = allitems[l].ToString();
                        spawnItem = GameObject.Find(itemSelect);
                        //cloned = GameObject.FindWithTag("Clone");
                        //spawnItem.gameObject.transform.position = this._goose.transform.position;
                        Debug.Log(allitems[l].ToString());
                        GameObject.Instantiate(spawnItem, this._goose.transform.position, _goose.transform.rotation);
                        spawnItem.name = "Clone";
                        spawnItem.transform.position = this._goose.transform.position + _goose.gameObject.transform.forward * 1f;
                    }
                    GUI.Label(new Rect(5f, (float)(l * 25), dropDownRect2.height, 25f), allitems[l]);
                }
                GUI.EndScrollView();
                GUI.DragWindow();
            }
        }
    }
}

