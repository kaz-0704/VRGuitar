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

        void OnTriggerEnter(Collider other)    //弦とオブジェクトが重なったときに
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
        //    Debug.Log("Pushing" + this.name);  // ログを出力
        //    stringCollider.chord = Chords.C;
        //}
    }
}
