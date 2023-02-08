using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRGuitar
{
    /// <summary>
    /// �߂�{�^��
    /// </summary>
    public class BackButton : MonoBehaviour
    {
        Setting setting = new Setting();
        public MenuManager menuManager;

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == setting.panelCollisionObject)
            {
                menuManager.Back();
            }
        }
    }
}

