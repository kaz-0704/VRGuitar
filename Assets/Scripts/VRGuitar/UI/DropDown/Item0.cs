using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace VRGuitar
{
    public class DropItemManager : MonoBehaviour
    {
        public DropDownManager dropManager;

        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnTriggerExit(Collider other)
        {
            dropManager.SetDropDownValue(0);
        }
    }
}


