using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace VRGuitar
{
    public class C_Collider : MonoBehaviour
    {
        public StringCollider stringCollider;
        Setting setting = new Setting();
        private LeftHandRecorder leftRecorder;
        public float distance;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Transform transform = this.transform;
            Vector3 position = transform.position;
            //distance = Vector3.Distance(position, leftRecorder.LeftHandPosition);
        }

        void OnTriggerEnter(Collider other)    //弦とオブジェクトが重なったときに
        {
            if (other.gameObject.name == setting.chordCollisionObject)
            {
                Debug.Log("Chord: C#");
                stringCollider.chord = Chords.C_;
            }
        }
    }
}
