using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRGuitar
{
    public class AdviseForearm : MonoBehaviour
    {
        public AdviceManager adviceManager;


        private void OnTriggerStay(Collider other)
        {

        }

        private void OnTriggerExit(Collider other)
        {
            adviceManager.OpenAdvice(3);
        }
    }
}
