using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VRGuitar
{
    public class ButtonAm : MonoBehaviour
    {
        
        Setting setting = new Setting();
        public  ChordButtonManager buttonManager;

        //void OnTriggerEnter(Collider other)    //弦とオブジェクトが重なったときに
        //{
        //    if (other.gameObject.name == setting.panelCollisionObject)
        //    {
        //        buttonManager.SetChord(Chords.Am);
        //    }
        //}

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.name == setting.panelCollisionObject)
            {
                buttonManager.SetChord(Chords.Am);
            }
        }
    }
}
