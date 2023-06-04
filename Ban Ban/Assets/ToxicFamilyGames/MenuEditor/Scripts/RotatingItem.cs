using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToxicFamilyGames
{
    namespace MenuEditor
    {
        public class RotatingItem : MonoBehaviour
        {
            // Update is called once per frame
            void Update()
            {
                transform.localRotation *= Quaternion.Euler(0, 30*Time.deltaTime, 0);
            }
        }
    }
}
