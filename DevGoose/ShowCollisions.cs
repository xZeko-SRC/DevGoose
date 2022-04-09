using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.IO;

namespace DevGoose
{
    class ShowCollisions : MonoBehaviour
    {

        private String _collision;
        private String _collisionTag;
       public bool _coll;

        void OnCollisionEnter(Collision collider)
        {
            _collision = collider.gameObject.name;
            _collisionTag = collider.gameObject.tag;
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                _coll = !_coll;
            }
        }
        void OnGUI()
        {
            if (!_coll)
            {
                GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 2000, 20), _collision);
                GUI.Label(new Rect(Screen.width / 2, (Screen.height / 2) - 100, 2000, 20), _collisionTag);
            }
        }

    }
}
