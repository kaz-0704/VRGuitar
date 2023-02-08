using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRGuitar
{
    public class AdviseYRotation : MonoBehaviour
    {
        public AdviceManager adviceManager;


        private void OnTriggerStay(Collider other)
        {

        }

        private void OnTriggerExit(Collider other)
        {
            adviceManager.OpenAdvice(2);
        }
    }
}
