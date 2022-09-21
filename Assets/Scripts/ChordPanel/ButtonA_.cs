using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VRGuitar
{
    public class ButtonA_ : MonoBehaviour
    {
        
        Setting setting = new Setting();
        public ButtonManager buttonManager;

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
                buttonManager.SetChord(Chords.A_);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.name == setting.panelCollisionObject)
            {
                buttonManager.SetChord(Chords.A_);
            }
        }
    }
}
