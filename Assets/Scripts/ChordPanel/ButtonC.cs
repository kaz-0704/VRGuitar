using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRGuitar
{
    public class ButtonC : MonoBehaviour
    {
        public StringCollider stringCollider;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnClick()
        {
            Debug.Log("Pushing" + this.name);  // ÉçÉOÇèoóÕ
            stringCollider.chord = Chords.C;
        }
    }
}
