using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace DevGoose
{
    class TeleportGoose : MonoBehaviour
    {
        public static GameObject _goose;

        // ****************** AREA TELEPORTS ******************
        public static void StartArea()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(-45.5f, 0.4f, -29.6f); // Starting Area
        }
        public static void Statue()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(-19.8f, 0.3f, -13.4f); // Statue/Bench
        }
        public static void Garden()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(-7.6f, 0.8f, -16.4f); // Garden
        }
        public static void HighStreet()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(21.2f, 0.9f, -11.8f); // High Street
        }

        public static void BackGardens()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(16.1f, 0.9f, 6.5f); // Back Gardens
        }

        public static void PinkHouse()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(6.2f, 1.3f, 21.8f); // Pink House
        }

        public static void PubArea()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(-23.3f, 1.3f, 2.2f); // Pub
        }
        public static void MiniVillage()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(-49.2f, 0.8f, 5.9f); // Mini Village
        }

        // ************************ SPEEDRUN TELEPORTS ***************************

        public static void GeesusClip()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(-24.9f, -0.2f, -9.7f); // Geesus Clip
        }
        public static void PubClip()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(-26.8f, 0.5f, -5.1f); // PUB CLIP
        }
        public static void BlinkClip()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(-35.5f, 1.3f, 4.2f); // Blink Clip
        }
        public static void TowerClimb()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(-54.1f, 1.6f, 1.5f); // Tower Climb
        }
        public static void BridgeClip()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(-2.6f, 0.1f, 4.8f); // Bridge Clip
        }
        public static void HouseClip()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(0.4f, 1.5f, 16.7f); // House Clip
        }

        // ************************ FUN/OOB TELEPORTS ***************************

        public static void BackTopPub()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(-37.2f, 10.3f, 8.0f);
        }
        
        public static void BGSkybox()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(16.1f, 5.7f, 7.2f); // Back Gardens Skybox
        }
        public static void AboveWell()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(-5.2f, 10.7f, -5.2f); // Above The hole by well
        }
        public static void AbovePinkHouse()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(9.6f, 7.8f, 18.4f); // Above Pink House
        }
        public static void PicnicArea()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(-34.1f, 0.9f, -32.9f); // By picnic area
        }
        public static void BehindBellPit()
        {
             _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(-51.2f, -0.1f, -37.0f); // Behind Bell Pit
        }
        public static void OtherMiniVillage()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(-43.4f, 1.3f, 22.2f); // Other Side of Mini Village
        }
        public static void MiddleMap()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(-40.7f, 10.7f, -10.2f); // Middle Threshold of Map
        }
        public static void AboveBellPit()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = new Vector3(-49.6f, 3.9f, -37.0f); // Above Bell Pit Shorter part.
        }
    }
}
