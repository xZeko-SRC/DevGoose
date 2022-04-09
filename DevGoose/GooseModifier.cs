using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace DevGoose
{
    class GooseModifier : MonoBehaviour
    {

        public static GameObject _goose, _gooseB;

        public static void SmallGoose()
        {
            _goose = GameObject.Find("Goose");
            _goose.gameObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        }
        public static void NormalGoose()
        {
            _goose = GameObject.Find("Goose");
            _goose.gameObject.transform.localScale = new Vector3(0.045f, 0.045f, 0.045f);
        }
        public static void BigGoose()
        {
            _goose = GameObject.Find("Goose");
            _goose.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        public static void GiantGoose()
        {
            _goose = GameObject.Find("Goose");
            _goose.gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
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
