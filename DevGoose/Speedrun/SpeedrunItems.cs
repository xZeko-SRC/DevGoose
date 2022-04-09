using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace DevGoose
{
    class SpeedrunItems : MonoBehaviour
    {
        public static GameObject _boot, _goose, _bell, _child;
        public static Vector3 _goosePos;

        public static void SpawnBoot()
        {
            _goose = GameObject.Find("Goose");
            _boot = GameObject.Find("boot");
            _boot.gameObject.transform.position = _goose.transform.position;
        }
        public static void SpawnBell()
        {
            _goose = GameObject.Find("Goose");
            _bell = GameObject.Find("goldenBell");
            _bell.gameObject.transform.position = _goose.transform.position;
        }
        public static void SpawnChild()
        {
            _goose = GameObject.Find("Goose");
            _child = GameObject.Find("MiniPerson Variant - child");
            _child.gameObject.transform.position = _goose.transform.position;
        }
        public static void LoadLocation()
        {
            _goose = GameObject.Find("Goose");
            _goose.transform.position = _goosePos;
        }

        public static void SaveLocation()
        {
            _goose = GameObject.Find("Goose");
            _goosePos = _goose.transform.position;
        }
    }
}
