using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VRGuitar
{
    public class ButtonC : MonoBehaviour
    {
        public StringCollider stringCollider;
        Setting setting = new Setting();
        private Button button;

        // Start is called before the first frame update
        void Start()
        {
            button = GetComponent<Button>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void OnTriggerEnter(Collider other)    //弦とオブジェクトが重なったときに
        {
            if (other.gameObject.name == setting.panelCollisionObject)
            {
                Debug.Log("Pushing button by " + other.gameObject.name);
                button.image.color = Color.green;
                stringCollider.chord = Chords.C;
                //OnClick();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.name == setting.panelCollisionObject)
            {
                button.image.color = Color.white;
                stringCollider.chord = Chords.C;
            }
        }
    }
}
