using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VRGuitar
{
    public class ButtonD_m : MonoBehaviour
    {

        Setting setting = new Setting();
        public ChordButtonManager buttonManager;

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.name == setting.panelCollisionObject)
            {
                buttonManager.SetChord(Chords.D_m);
            }
        }
    }
}
