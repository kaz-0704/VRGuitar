using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace VRGuitar
{
    public class CCollider : MonoBehaviour
    {
        public StringCollider stringCollider;
        public SteamVR_Input_Sources lefthand;

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
            if (other.gameObject.name == "finger_ring_2_l")
            {
                Debug.Log("Chord: D");
                stringCollider.chord = Chords.D;
            }
        }
    }
}
