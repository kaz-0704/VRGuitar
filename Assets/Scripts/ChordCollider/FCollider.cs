using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace VRGuitar
{
    public class FCollider : MonoBehaviour
    {
        public StringCollider stringCollider;
        Setting setting = new Setting();

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
            if (other.gameObject.name == setting.chordCollisionObject)
            {
                Debug.Log("Chord: F");
                stringCollider.chord = Chords.F;
            }
        }
    }
}
