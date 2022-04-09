using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace DevGoose
{
    class CreateItems : MonoBehaviour
    {

        private static bool _wireframe;
        public static GameObject _goose, _capsule, _cube, _sphere, _cylinder;

        public static void WireFrame()
        {
            _wireframe = !_wireframe;

            if (_wireframe)
            {
                GL.wireframe = true;
            }

            if (!_wireframe)
            {
                GL.wireframe = false;
            }
        }
        public static void CreateCapsule()
        {
            _goose = GameObject.Find("Goose");
            GameObject.CreatePrimitive(PrimitiveType.Capsule).transform.position = _goose.transform.position;
        }
        public static void CreateCube()
        {
            _goose = GameObject.Find("Goose");
            GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = _goose.transform.position;
        }
        public static void CreateSphere()
        {
            _goose = GameObject.Find("Goose");
            GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = _goose.transform.position;
        }
        public static void CreateCylinder()
        {
            _goose = GameObject.Find("Goose");
            GameObject.CreatePrimitive(PrimitiveType.Cylinder).transform.position = _goose.transform.position;
        }

        public static void DestroyCapsule()
        {
            _capsule = GameObject.Find("Capsule");
            GameObject.Destroy(_capsule);
        }
        public static void DestroyCube()
        {
            _cube = GameObject.Find("Cube");
            GameObject.Destroy(_cube);
        }
        public static void DestroySphere()
        {
            _sphere = GameObject.Find("Sphere");
            GameObject.Destroy(_sphere);
        }
        public static void DestroyCylinder()
        {
            _cylinder = GameObject.Find("Cylinder");
            GameObject.Destroy(_cylinder);
        }
    }
}