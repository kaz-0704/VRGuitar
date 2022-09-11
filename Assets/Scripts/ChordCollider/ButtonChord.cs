using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace VRGuitar
{
    public class ButtonChord : MonoBehaviour
    {
        public StringCollider stringCollider;
        public SteamVR_Input_Sources lefthand;

        // Start is called before the first frame update
        void Start()
        {
            stringCollider.chord = Chords.C;
        }

        // Update is called once per frame
        void Update()
        {
            if (SteamVR_Input.GetStateDown("X", lefthand))
            {
                Debug.Log("Pushing X");
                stringCollider.chord = Chords.D;
            }
            else if (SteamVR_Input.GetStateDown("Y", lefthand))
            {
                Debug.Log("Pushing Y");
                stringCollider.chord = Chords.E;
            }
        }
    }
}

