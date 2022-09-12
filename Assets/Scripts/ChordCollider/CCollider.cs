using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace VRGuitar
{
    public class CCollider : MonoBehaviour
    {
        public StringCollider stringCollider;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider other)    //弦とオブジェクトが重なったときに
        {
            if (other.gameObject.name == "LeftHandCollider")
            {
                Debug.Log("Chord: C");
                stringCollider.chord = Chords.C;
            }
            Debug.Log("Left: " + other.gameObject.name);
        }
    }
}
