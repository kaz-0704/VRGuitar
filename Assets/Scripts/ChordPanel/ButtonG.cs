using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRGuitar
{
    public class ButtonG : MonoBehaviour
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
            if (other.gameObject.name == setting.panelCollisionObject)
            {
                Debug.Log(other.gameObject.name);
                stringCollider.chord = Chords.G;
                //OnClick();
            }
        }

        //public void OnClick()
        //{
        //    Debug.Log("Pushing" + this.name);  // ���O���o��
        //    stringCollider.chord = Chords.C;
        //}
    }
}
