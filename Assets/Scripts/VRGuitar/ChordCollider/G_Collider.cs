using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace VRGuitar
{
    public class G_Collider : MonoBehaviour
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

        void OnTriggerEnter(Collider other)    //���ƃI�u�W�F�N�g���d�Ȃ����Ƃ���
        {
            if (other.gameObject.name == setting.chordCollisionObject)
            {
                Debug.Log("Chord: G#");
                stringCollider.chord = Chords.G_;
            }
        }
    }
}
