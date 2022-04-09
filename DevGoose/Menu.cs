using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace DevGoose
{
    public class Menu : MonoBehaviour
    {
        private Rect _main, _speedrun, _goose, _spawn, _create, _fun, _stele, _mtele, _atele, _ftele, _keys, _expe, _gospawn, _task, _clone;
        public bool Visible = true;
        public bool VisualVisible = false;
        public bool GooseVisible = false;
        public bool SpawnVisible = false;
        public bool RenderVisible = false;
        public bool WorldVisible = false;
        public bool SpeedVisible = false;
        public bool AreasVisible = false;
        public bool FunVisible = false;
        public bool TeleMainVisible = false;
        public bool KeysVisible = false;
        public bool ExVisible = false;
        public bool GOVisible = false;
        public bool TaskVisible = false;
        public bool CloneVisible = false;

        public void Start()
        {
            // Main
            _main = new Rect(10f, 120f, 250f, 150f);

            // Speedrun
            _speedrun = new Rect(10f, 10f, 250f, 350f);

            // Goose Options
            _goose = new Rect(10f, 10f, 250f, 350f);

            // Spawn Options
            _spawn = new Rect(10f, 10f, 350f, 450f);

            // Create Render
            _create = new Rect(10f, 10f, 350f, 350f);

            // Fun Options
            _fun = new Rect(10f, 10f, 250f, 250f);

            // Speedrun Teleports
            _stele = new Rect(10f, 10f, 250f, 250f);

            // Main Teleport Options
            _mtele = new Rect(10f, 10f, 250f, 250f);

            //Area Teleports
            _atele = new Rect(10f, 10f, 250f, 250f);

            //Fun/OOB Teleports
            _ftele = new Rect(10f, 10f, 250f, 250f);

            // Shortcut Keys
            _keys = new Rect(10f, 10f, 250f, 250f);
           
            // Experimental 
            _expe = new Rect(10f, 10f, 250f, 250f);
            
            // Spawn Items instead of teleport
            _gospawn = new Rect(10f, 10f, 250f, 250f);

            //Tasks
            _task = new Rect(10f, 10f, 250f, 250f);

            //Clone array
            _clone = new Rect(10f, 20f, 350f, 350f);
        }

        private void ToggleMenu()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                Visible = !Visible;
            }
        }

        private void Update()
        {
            ToggleMenu();
        }

        public void OnGUI()
        {
            if (!Visible)
            {
                return;
            }

            _main = GUILayout.Window(0, _main, new GUI.WindowFunction(Draw), "Dev Goose", new GUILayoutOption[0]);
            if (VisualVisible)
            {
                _speedrun = GUILayout.Window(1, _speedrun, new GUI.WindowFunction(DrawSpeedrun), "Speedrun", new GUILayoutOption[0]);
            }
            if (GooseVisible)
            {
                _goose = GUILayout.Window(2, _goose, new GUI.WindowFunction(DrawGoose), "Goose", new GUILayoutOption[0]);
            }
            if (SpawnVisible)
            {
                _spawn = GUILayout.Window(3, _spawn, new GUI.WindowFunction(DrawSpawn), "Spawn Items", new GUILayoutOption[0]);
            }
            if (RenderVisible)
            {
                _create = GUILayout.Window(4, _create, new GUI.WindowFunction(DrawCreate), "Render + Create Primatives", new GUILayoutOption[0]);
            }
            if (WorldVisible)
            {
                _fun = GUILayout.Window(5, _fun, new GUI.WindowFunction(DrawFun), "World/Fun", new GUILayoutOption[0]);
            }
            if (SpeedVisible)
            {
                _stele = GUILayout.Window(6, _stele, new GUI.WindowFunction(DrawSpeedTele), "Speedrun Teleports", new GUILayoutOption[0]);
            }
            if (TeleMainVisible)
            {
                _mtele = GUILayout.Window(7, _mtele, new GUI.WindowFunction(DrawMainTele), "Teleports", new GUILayoutOption[0]);
            }
            if (AreasVisible)
            {
                _atele = GUILayout.Window(8, _atele, new GUI.WindowFunction(DrawAreaTele), "Area Teleports", new GUILayoutOption[0]);
            }
            if (FunVisible)
            {
                _ftele = GUILayout.Window(9, _ftele, new GUI.WindowFunction(DrawFunTele), "Fun/OOB Teleports", new GUILayoutOption[0]);
            }
            if (KeysVisible)
            {
                _keys = GUILayout.Window(10, _keys, new GUI.WindowFunction(DrawKeys), "Shortcut Keys", new GUILayoutOption[0]);
            }
            if (ExVisible)
            {
                _expe = GUILayout.Window(11, _expe, new GUI.WindowFunction(Experiment), "Experimental", new GUILayoutOption[0]);
            }
            if (GOVisible)
            {
                _gospawn = GUILayout.Window(12, _gospawn, new GUI.WindowFunction(GoSpawn), "Game Object Spawner", new GUILayoutOption[0]);
            }
            if (TaskVisible)
            {
                _task = GUILayout.Window(13, _task, new GUI.WindowFunction(TaskItem), "Complete Tasks", new GUILayoutOption[0]);
            }
            if (CloneVisible)
            {
                _clone = GUILayout.Window(14, _clone, new GUI.WindowFunction(Cloning), "Clone Human/Goose Spawner", new GUILayoutOption[0]);
            }
        }
        public void Draw(int id)
        {
            GUILayout.Label("   Open and Close Mod Menu: INSERT", new GUILayoutOption[0]);
            GUILayout.Space(+10f);

            if (GUILayout.Button("Info + Shortcut Keys", new GUILayoutOption[0]))
            {
                _keys.x = _main.width + 20f;
                //_keys.y = _create.width + 80f;
                KeysVisible = !KeysVisible;
            }
            GUILayout.Label("--------------------------------------------------------", new GUILayoutOption[0]);
            if (GUILayout.Button("Speedrun", new GUILayoutOption[0]))
            {
                _speedrun.x = _keys.width + 280f;
                VisualVisible = !VisualVisible;
            }

            if (GUILayout.Button("Goose", new GUILayoutOption[0]))
            {
                _goose.x = _speedrun.width + 530f;
                GooseVisible = !GooseVisible;
            }
            if (GUILayout.Button("Complete Tasks", new GUILayoutOption[0]))
            {
                _task.x = _create.width + 680f;
                //_expe.y = _spawn.width + 80f;
                TaskVisible = !TaskVisible;
            }
            if (GUILayout.Button("Spawn Items", new GUILayoutOption[0]))
            {
                _spawn.x = _goose.width + 270f;
                _spawn.y = _goose.width + 110f;
                SpawnVisible = !SpawnVisible;
            }
            if (GUILayout.Button("Clone People/Goose", new GUILayoutOption[0]))
            {
                _clone.x = _main.width + 120f;
                CloneVisible = !CloneVisible;
            }
            if (GUILayout.Button("Teleport", new GUILayoutOption[0]))
            {
                _mtele.x = _keys.width - 240f;
                _mtele.y = _main.width + 200f;
                TeleMainVisible = !TeleMainVisible;
            }
            if (GUILayout.Button("Render/Create", new GUILayoutOption[0]))
            {
                _create.x = _mtele.width + 620f;
                _create.y = _goose.width + 110f;
                RenderVisible = !RenderVisible;
            }
            GUILayout.Label("--------------------------------------------------------", new GUILayoutOption[0]);
            if (GUILayout.Button("Experimental", new GUILayoutOption[0]))
            {
                _expe.x = _create.width + 680f;
                //_expe.y = _spawn.width + 80f;
                ExVisible = !ExVisible;
            }


            //GUILayout.Space(10f);
            GUILayout.Label("--------------------------------------------------------", new GUILayoutOption[0]);

            //if (GUILayout.Button("UGG Speedrun Page", new GUILayoutOption[0]))
            //{
            //    Application.OpenURL("https://www.speedrun.com/goose");
            //}
            GUILayout.Label("                     Created by", new GUILayoutOption[0]);
            GUILayout.Label("   xZeKo, BradCubed and DevChagrins", new GUILayoutOption[0]);
            GUI.DragWindow();
        }

        public void DrawSpawn(int id)
        {
            SpawnItems.ItemSpawner();

            GUI.DragWindow();
        }

        public void DrawFun(int id)
        {
            GUILayout.Label("Render/ Create:", new GUILayoutOption[0]);
            GUILayout.Space(+5f);

            GUI.DragWindow();
        }

        public void DrawSpeedrun(int id)
        {
            GUILayout.Label("Speedrunning Tools", new GUILayoutOption[0]);
            GUILayout.Space(+5f);
            GUILayout.Label("You now can remove and restore AI ", new GUILayoutOption[0]);
            GUILayout.Label("To Remove/Restore All AI: K", new GUILayoutOption[0]);
            GUILayout.Space(+5f);
            if (GUILayout.Button("Save Location", new GUILayoutOption[0]))
            {
                SpeedrunItems.SaveLocation();
            }
            GUILayout.Space(+5f);
            if (GUILayout.Button("Load Location", new GUILayoutOption[0]))
            {
                SpeedrunItems.LoadLocation();
            }
            GUILayout.Space(+5f);
            if (GUILayout.Button("Spawn Bell", new GUILayoutOption[0]))
            {
                SpeedrunItems.SpawnBell();
            }
            GUILayout.Space(+5f);
            if (GUILayout.Button("Spawn Boot", new GUILayoutOption[0]))
            {
                SpeedrunItems.SpawnBoot();
            }
            GUILayout.Space(+5f);
            if (GUILayout.Button("Spawn Timmy", new GUILayoutOption[0]))
            {
                SpeedrunItems.SpawnChild();
            }

            GUI.DragWindow();
        }
        public void DrawGoose(int id)
        {
            GUILayout.Label("Goose Modifiers:", new GUILayoutOption[0]);
            GUILayout.Space(+5f);
            GUILayout.Label("Speed Up: Plus Button (+)", new GUILayoutOption[0]);
            GUILayout.Label("Speed Down: Minus Button (-)", new GUILayoutOption[0]);
            GUILayout.Space(+10f);
            GUILayout.Label("Goose Sizes", new GUILayoutOption[0]);
            if (GUILayout.Button("Small Goose", new GUILayoutOption[0]))
            {
                GooseModifier.SmallGoose();
            }
            if (GUILayout.Button("Normal Goose", new GUILayoutOption[0]))
            {
                GooseModifier.NormalGoose();
            }
            if (GUILayout.Button("Big Goose", new GUILayoutOption[0]))
            {
                GooseModifier.BigGoose();
            }
            if (GUILayout.Button("Giant Goose", new GUILayoutOption[0]))
            {
                GooseModifier.GiantGoose();
            }

            GUILayout.Space(+10f);
            GUILayout.Label("Teleport Geese Together", new GUILayoutOption[0]);
            if (GUILayout.Button("Teleport Goose to 2oose", new GUILayoutOption[0]))
            {
                GooseModifier.GoosetoGeese();
            }
            if (GUILayout.Button("Teleport 2oose to Goose", new GUILayoutOption[0]))
            {
                GooseModifier.GeesetoGoose();
            }

            GUI.DragWindow();
        }
        public static bool gooseclip = false;
        public void DrawSpeedTele(int id)
        {
            GUILayout.Label("Speedrun Clip/Trick Teleports:", new GUILayoutOption[0]);
            GUILayout.Space(+5f);

            if (GUILayout.Button("Geesus Clip", new GUILayoutOption[0]))
            {
                TeleportGoose.GeesusClip();
            }
            if (GUILayout.Button("Pub Clip", new GUILayoutOption[0]))
            {
                TeleportGoose.PubClip();
            }
            if (GUILayout.Button("Blink Clip", new GUILayoutOption[0]))
            {
                TeleportGoose.BlinkClip();
            }
            if (GUILayout.Button("Tower Climb", new GUILayoutOption[0]))
            {
                TeleportGoose.TowerClimb();
            }
            if (GUILayout.Button("Bridge Clip", new GUILayoutOption[0]))
            {
                TeleportGoose.BridgeClip();
            }
            if (GUILayout.Button("House Clip", new GUILayoutOption[0]))
            {
                TeleportGoose.HouseClip();
            }

            GUI.DragWindow();
        }

        public void DrawCreate(int id)
        {
            GUILayout.Label("World and Create Primatives", new GUILayoutOption[0]);
            GUILayout.Space(+10f);
            if (GUILayout.Button("Render Wireframe", new GUILayoutOption[0]))
            {
                CreateItems.WireFrame();
            }
            GUILayout.Space(+10f);
            if (GUILayout.Button("Create a Cube", new GUILayoutOption[0]))
            {
                CreateItems.CreateCube();
            }
            if (GUILayout.Button("Create a Capsule", new GUILayoutOption[0]))
            {
                CreateItems.CreateCapsule();
            }
            if (GUILayout.Button("Create a Sphere", new GUILayoutOption[0]))
            {
                CreateItems.CreateSphere();
            }
            if (GUILayout.Button("Create a Cylinder", new GUILayoutOption[0]))
            {
                CreateItems.CreateCylinder();
            }
            GUILayout.Space(+10f);
            GUILayout.Label("You will have to push delete a few times before it does delete.", new GUILayoutOption[0]);
            if (GUILayout.Button("Remove a Cube", new GUILayoutOption[0]))
            {
                CreateItems.DestroyCube();
            }
            if (GUILayout.Button("Remove a Capsule", new GUILayoutOption[0]))
            {
                CreateItems.DestroyCapsule();
            }
            if (GUILayout.Button("Remove a Sphere", new GUILayoutOption[0]))
            {
                CreateItems.DestroySphere();
            }
            if (GUILayout.Button("Remove a Cylinder", new GUILayoutOption[0]))
            {
                CreateItems.DestroyCylinder();
            }

            GUI.DragWindow();
        }


        public void DrawMainTele(int id)
        {
            GUILayout.Label("Teleport to certain places on the map.", new GUILayoutOption[0]);
            GUILayout.Space(+5f);
            GUILayout.Label("Blink: Ctrl + E or LB + RB + X", new GUILayoutOption[0]);
            GUILayout.Space(+10f);
            if (GUILayout.Button("Speedrun Teleports", new GUILayoutOption[0]))
            {
                _stele.x = _main.width + 20f;
                SpeedVisible = !SpeedVisible;
            }
            GUILayout.Space(+5f);
            if (GUILayout.Button("Area Teleports", new GUILayoutOption[0]))
            {
                _atele.x = _main.width + 280f;
                AreasVisible = !AreasVisible;
            }
            GUILayout.Space(+5f);
            if (GUILayout.Button("Fun/OOB Teleports", new GUILayoutOption[0]))
            {
                _ftele.x = _main.width + 540f;
                FunVisible = !FunVisible;
            }

            GUI.DragWindow();
        }
        public void DrawAreaTele(int id)
        {
            GUILayout.Label("Teleport to different Areas", new GUILayoutOption[0]);
            GUILayout.Space(+5f);

            if (GUILayout.Button("Starting Area", new GUILayoutOption[0]))
            {
                TeleportGoose.StartArea();
            }
            if (GUILayout.Button("Statue/Bench", new GUILayoutOption[0]))
            {
                TeleportGoose.Statue();
            }
            if (GUILayout.Button("Garden", new GUILayoutOption[0]))
            {
                TeleportGoose.Garden();
            }
            if (GUILayout.Button("High Street", new GUILayoutOption[0]))
            {
                TeleportGoose.HighStreet();
            }
            if (GUILayout.Button("Back Gardens", new GUILayoutOption[0]))
            {
                TeleportGoose.BackGardens();
            }
            if (GUILayout.Button("Pink House", new GUILayoutOption[0]))
            {
                TeleportGoose.PinkHouse();
            }
            if (GUILayout.Button("Pub", new GUILayoutOption[0]))
            {
                TeleportGoose.PubArea();
            }
            if (GUILayout.Button("Mini Village", new GUILayoutOption[0]))
            {
                TeleportGoose.MiniVillage();
            }

            GUI.DragWindow();
        }
        public void DrawFunTele(int id)
        {
            GUILayout.Label("Fun and Out of Bound Teleports:", new GUILayoutOption[0]);
            GUILayout.Space(+5f);

            if (GUILayout.Button("Above the back of pub", new GUILayoutOption[0]))
            {
                TeleportGoose.BackTopPub();
            }
            if (GUILayout.Button("Back Garden's Skybox", new GUILayoutOption[0]))
            {
                TeleportGoose.BGSkybox();
            }
            if (GUILayout.Button("Above the hole by well", new GUILayoutOption[0]))
            {
                TeleportGoose.AboveWell();
            }
            if (GUILayout.Button("Above Pink House", new GUILayoutOption[0]))
            {
                TeleportGoose.AbovePinkHouse();
            }
            if (GUILayout.Button("By picnic area", new GUILayoutOption[0]))
            {
                TeleportGoose.PicnicArea();
            }
            if (GUILayout.Button("Behind Bell Pit", new GUILayoutOption[0]))
            {
                TeleportGoose.BehindBellPit();
            }
            if (GUILayout.Button("Other Side of Mini Village", new GUILayoutOption[0]))
            {
                TeleportGoose.OtherMiniVillage();
            }
            if (GUILayout.Button("Middle Threshold of Map", new GUILayoutOption[0]))
            {
                TeleportGoose.MiddleMap();
            }
            if (GUILayout.Button("Above Bell Pit Shorter part", new GUILayoutOption[0]))
            {
                TeleportGoose.AboveBellPit();
            }

            GUI.DragWindow();
        }

        public void DrawKeys(int id)
        {
            GUILayout.Label("------------------------------------------------------", new GUILayoutOption[0]);
            GUILayout.Label("Welcome to DevGoose", new GUILayoutOption[0]);
            GUILayout.Label("Here you will find the shortcut keys", new GUILayoutOption[0]);
            GUILayout.Label("Some older shortcut keys have been removed for buttons.", new GUILayoutOption[0]);
            GUILayout.Space(+5f);
            GUILayout.Label("------------------------------------------------------", new GUILayoutOption[0]);
            GUILayout.Label("Advanced Output: CTRL+Y", new GUILayoutOption[0]);
            GUILayout.Label("Remove Top Left and Middle Text: RIGHT-SHIFT", new GUILayoutOption[0]);
            GUILayout.Label("Save Goose Location: CTRL+S", new GUILayoutOption[0]);
            GUILayout.Label("Load Goose Location: CTRL+L", new GUILayoutOption[0]);
            GUILayout.Label("Remove All AI: K", new GUILayoutOption[0]);
            GUILayout.Label("Speed Game Up/Down: +/-", new GUILayoutOption[0]);
            GUILayout.Label("Spawn Bell: CTRL+T", new GUILayoutOption[0]);
            GUILayout.Label("Spawn Boot: CTRL+H", new GUILayoutOption[0]);
            GUILayout.Label("Spawn Timmy: CTRL+B", new GUILayoutOption[0]);
            GUILayout.Space(+5f);
            GUILayout.Label("------------------------------------------------------", new GUILayoutOption[0]);
            GUILayout.Label("NoClip: CTRL+N / Xbox: LB + RB + Y", new GUILayoutOption[0]);
            GUILayout.Label("W, A, S, D to move. Space to ascend, left CTRL to descend.", new GUILayoutOption[0]);
            GUILayout.Label("Xbox Controller: Left stick to move, A to Ascend Y to descend.", new GUILayoutOption[0]);
            GUILayout.Space(+5f);
            GUILayout.Label("------------------------------------------------------", new GUILayoutOption[0]);
            GUILayout.Label("No Clip doesn't have a button yet but shortcut keys work.", new GUILayoutOption[0]);

            GUI.DragWindow();
        }

        public void Experiment(int id)
        {
            GUILayout.Label("------------------------------------------------------", new GUILayoutOption[0]);
            GUILayout.Label("This is Experimental", new GUILayoutOption[0]);
            GUILayout.Label("Please be aware that some functions here MAY NOT work properly or as intended.", new GUILayoutOption[0]);
            GUILayout.Label("Most parts have not been finished and will cause glitches/crashes.", new GUILayoutOption[0]);
            GUILayout.Label("You will have to close Goose and restart. You have been warned.", new GUILayoutOption[0]);
            GUILayout.Space(+5f);
            GUILayout.Label("------------------------------------------------------", new GUILayoutOption[0]);
            GUILayout.Label("Clone Goose: CTRL+P", new GUILayoutOption[0]);
            GUILayout.Label("Bring All GameObject to Goose: CTRL+2 *WILL BREAK GAME*", new GUILayoutOption[0]);
            GUILayout.Label("3rd Person Goose: J", new GUILayoutOption[0]);
            if (GUILayout.Button("GameObject item Spawner (Test)", new GUILayoutOption[0]))
            {
                _gospawn.x = _main.width + 20f;
                GOVisible = !GOVisible;
            }
            GUILayout.Space(+5f);
            GUILayout.Label("------------------------------------------------------", new GUILayoutOption[0]);
            GUILayout.Label("Magic Free Cam by 0x0ade", new GUILayoutOption[0]);
            GUILayout.Label("Free Cam: O", new GUILayoutOption[0]);
            GUILayout.Label("Speed Up: 8, Speed Down: 9", new GUILayoutOption[0]);
            GUILayout.Label("Freeze Camera: 1, Reset Camera: 0", new GUILayoutOption[0]); 
            GUILayout.Label("(You will have to hold ALT after to get the mouse to work)", new GUILayoutOption[0]);
            GUILayout.Label("Remove Top Left and Middle Text: RIGHT-SHIFT", new GUILayoutOption[0]);
            GUI.DragWindow();
        }

        public void GoSpawn(int id)
        {
            GOSpawner.GOSpawners();
            GUI.DragWindow();
        }

        public void Cloning(int id)
        {
            CloneSpawn.CloneSpawner();
            GUI.DragWindow();
        }

        public void TaskItem(int id)
        {
            GUILayout.Label("Each button will complete the task", new GUILayoutOption[0]);
            GUILayout.Label("But you will need to do the last part to get to the next area.", new GUILayoutOption[0]);
            ItemTask.CompleteTasks();
            GUI.DragWindow();
        }
        public static bool Watermark = true;
    }
}

