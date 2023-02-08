using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VRGuitar
{
    public class ButtonBm : MonoBehaviour
    {
        
        Setting setting = new Setting();
        public  ChordButtonManager buttonManager;

        //void OnTriggerEnter(Collider other)    //弦とオブジェクトが重なったときに
        //{
        //    if (other.gameObject.name == setting.panelCollisionObject)
        //    {
        //        buttonManager.SetChord(Chords.Bm);
        //    }
        //}

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.name == setting.panelCollisionObject)
            {
                buttonManager.SetChord(Chords.Bm);
            }
        }
    }
}
