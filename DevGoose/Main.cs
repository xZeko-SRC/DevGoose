using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace DevGoose
{
    class Main : MonoBehaviour
    {
        public bool ShowHide = false;
        private GameObject _goose, _bell, _boot, _timmy;
        public static ArrayList _UDO = new ArrayList();
        public bool _advancedOutput, _noclip, _menuEnabled, _pause;
        public float _gooseMass;
        float _deltaTime = 0.0f;
        public GUIStyle _guiStyle = null;
        //public bool _shoo;
        public Vector3 head = new Vector3(0, 7, 0);
        public static Vector3 _goosePos;

        //public ShowCollisions _wireframeCollisions;
        public void Start()
        {
            GameSettings.currentSettings.allowCheats = true;
            GameSettings.currentSettings.teleportMustBePrimed = true;
            this._goose = GameObject.Find("Goose");
            this._bell = GameObject.Find("goldenBell");
            this._boot = GameObject.Find("boot");
            this._timmy = GameObject.Find("MiniPerson Variant - child");
            _goose.AddComponent<ShowCollisions>();
            Camera.main.gameObject.AddComponent<CreateItems>();
            Camera.main.gameObject.AddComponent<MagicCamPlugin>();
            Camera.main.gameObject.AddComponent<FPSMod>();
            _gooseMass = _goose.GetComponent<Rigidbody>().mass;
            _guiStyle = new GUIStyle();
            _guiStyle.fontSize = Screen.height * 2 / 100;
            _guiStyle.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }

        void Update()
        {
            _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.1f;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _pause = !_pause;
            }
            if (_pause)
            {
                Time.timeScale = 0f;
            }
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Y))
            {
                _advancedOutput = !_advancedOutput;
            }

            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                _menuEnabled = !_menuEnabled;
            }
            //if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha9))
            //{
            //    if (!_cloneGoose)
             //   {
              //      _cloneGoose = GameObject.Instantiate(_goose.gameObject,
              //          _goose.gameObject.transform.position + (_goose.gameObject.transform.forward * 1f),
              //          _goose.gameObject.transform.rotation, _goose.gameObject.transform.parent);
              //  }
               // else
              //  {
               //     GameObject.Destroy(_cloneGoose);
               // }
            //}
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha2))
            {
                GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();

                print("Finding all game objects.....");
                for (var index = 0; index < gameObjects.Length; index++)
                {
                    print(gameObjects[index].name);
                    gameObjects[index].transform.position = this._goose.transform.position + _goose.gameObject.transform.forward * 1f;
                    //gameObjects[index].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    //gameObjects[index].transform.transform.position = new Vector3(100000, 100000, 10000);
                }
                print("...Done finding all game objects");
            }

            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha6))
            {
               // SwitchEventManager.TriggerEvent("award-goal100");
            }
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha8))
            {
                //this._shoo = (false);
                // SwitchEventManager.TriggerEvent("award-" + "GOAL_PICNIC");
            }
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.T))
            {
                this._bell.transform.position = this._goose.transform.position;
            }
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.H))
            {
                this._boot.transform.position = this._goose.transform.position;
            }
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.B))
            {
                this._timmy.transform.position = this._goose.transform.position;
            }
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.L))
            {
                _goose.transform.position = _goosePos;
            }
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.S))
            {
                _goosePos = _goose.transform.position;
            }
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.E) || (Input.GetKey(KeyCode.JoystickButton4) && Input.GetKey(KeyCode.JoystickButton5) && Input.GetKeyDown(KeyCode.JoystickButton2)))
            {
                _goose.transform.position += _goose.transform.forward * 3f;
            }
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.N) || (Input.GetKey(KeyCode.JoystickButton4) && Input.GetKey(KeyCode.JoystickButton5) && Input.GetKeyDown(KeyCode.JoystickButton3)))
            {
                _noclip = !_noclip;
            }

            if (_noclip)
            {
                this._goose.GetComponent<Rigidbody>().isKinematic = true;
                this._goose.GetComponent<Rigidbody>().useGravity = false;
                this._goose.GetComponent<Rigidbody>().mass = 0f;
                Collider[] components = this._goose.GetComponents<Collider>();
                foreach (Collider collider in components)
                {
                    collider.enabled = false;
                }
                if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton0))
				{
                    this._goose.transform.position += new Vector3(0f, 0.05f, 0f);
                }
                if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.JoystickButton3))
				{
                    this._goose.transform.position += new Vector3(0f, -0.05f, 0f);
                }
                if (Input.GetKey(KeyCode.W) || Input.GetAxis("Vertical") > 0f)
				{
                    this._goose.transform.position += this._goose.transform.forward * 0.05f;
                }
                if (Input.GetKey(KeyCode.S) || Input.GetAxis("Vertical") < 0f)
				{
                    this._goose.transform.position += -(this._goose.transform.forward * 0.05f);
                }
                if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0f)
				{
                    this._goose.transform.position += this._goose.transform.right * 0.05f;
                }
                if (Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < 0f)
				{
                    this._goose.transform.position += -(this._goose.transform.right * 0.05f);
                }
            }
            if (!_noclip)
            {
                this._goose.GetComponent<Rigidbody>().isKinematic = false;
                this._goose.GetComponent<Rigidbody>().useGravity = true;
                this._goose.GetComponent<Rigidbody>().mass = this._gooseMass;
                Collider[] components2 = this._goose.GetComponents<Collider>();
                foreach (Collider collider2 in components2)
                {
                    collider2.enabled = true;
                }
            }
        }

        public void OnGUI()
        {
            if (Menu.Watermark)
            {
                //GUI.Label(new Rect(20, 20, 200, 60), "Dev Goose Injected - Press INSERT to open Menu");
            }
            //SpawnMenu p = new SpawnMenu();
            //p.Calling();
            //p.spawnItemMenu();
            int w = Screen.width, h = Screen.height;

            GUIStyle style = new GUIStyle();

            Rect rect = new Rect(0, 0, w, h * 2 / 100);
            style.alignment = TextAnchor.UpperRight;
            style.fontSize = h * 2 / 100;
            style.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            float msec = _deltaTime * 1000.0f;
            float fps = 1.0f / _deltaTime;
            string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
            GUI.Label(rect, text, style);

            if (!_menuEnabled)
            {
                if (!_advancedOutput)
                {
                    GUI.Label(new Rect(20, 20, 2000, 200), "Position: (" + _goose.gameObject.transform.position + ")");
                    GUI.Label(new Rect(20, 40, 2000, 200), "Rotation: (" + _goose.gameObject.transform.rotation + ")");
                    GUI.Label(new Rect(20, 60, 2000, 200), "Velocity: " + _goose.GetComponent<Rigidbody>().velocity);
                    GUI.Label(new Rect(20, 80, 2000, 200), "Noclip: " + _noclip);
                    //GUI.Label(new Rect(20, 100, 2000, 200), "Dev Goose v3");
                    //GUI.Label(new Rect(20, 120, 2000, 200), "PUSH INSERT TO OPEN MENU");

                }
                else
                {
                    Vector3 _gs_position = _goose.gameObject.transform.position;
                    Quaternion _gs_rotation = _goose.gameObject.transform.rotation;
                    Vector3 _gs_velocity = _goose.GetComponent<Rigidbody>().velocity;

                    string _position_string = string.Format("Position: ({0}, {1}, {2})", _gs_position.x.ToString("F4"), _gs_position.y.ToString("F4"), _gs_position.z.ToString("F4"));
                    string _rotation_string = string.Format("Rotation: ({0}, {1}, {2}, {3})", _gs_rotation.x.ToString("F4"), _gs_rotation.y.ToString("F4"), _gs_rotation.z.ToString("F4"), _gs_rotation.w.ToString("F4"));
                    string _velocity_string = string.Format("Velocity: ({0}, {1}, {2})", _gs_velocity.x.ToString("F4"), _gs_velocity.y.ToString("F4"), _gs_velocity.z.ToString("F4"));

                    GUI.Label(new Rect(20, 30, 2000, 200), _position_string, _guiStyle);
                    GUI.Label(new Rect(20, 60, 2000, 200), _rotation_string, _guiStyle);
                    GUI.Label(new Rect(20, 90, 2000, 200), _velocity_string, _guiStyle);
                    //GUI.Label(new Rect(20, 120, 2000, 200), "Noclip: " + _noclip);
                    //GUI.Label(new Rect(20, 140, 2000, 200), "Dev Goose v3");
                }
            }
        }
    }
}
