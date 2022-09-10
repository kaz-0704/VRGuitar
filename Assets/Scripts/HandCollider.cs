using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRGuitar
{
    public class HandCollider : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            //if (other.gameObject.name == "StringCollider" | other.gameObject.name == "Cube")
            //{
            //    Debug.Log("RightHand: " + other.gameObject.name);
            //}
            //Debug.Log("RightHand: " + other.gameObject.name);
        }
    }
}
