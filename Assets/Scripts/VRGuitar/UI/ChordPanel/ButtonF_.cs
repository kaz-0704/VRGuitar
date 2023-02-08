using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VRGuitar
{
    public class ButtonF_ : MonoBehaviour
    {
        
        Setting setting = new Setting();
        public ChordButtonManager buttonManager;

        void OnTriggerEnter(Collider other)    //���ƃI�u�W�F�N�g���d�Ȃ����Ƃ���
        {
            if (other.gameObject.name == setting.panelCollisionObject)
            {
                buttonManager.SetChord(Chords.F_);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.name == setting.panelCollisionObject)
            {
                buttonManager.SetChord(Chords.F_);
            }
        }
    }
}
