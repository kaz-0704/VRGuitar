using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRGuitar
{
    /// <summary>
    /// メインメニューを開くボタン
    /// </summary>
    public class MenuButton : ButtonManager
    {
        Setting setting = new Setting();
        public MenuManager menuManager;

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.gameObject.name == setting.panelCollisionObject)
        //    {
        //        menuManager.MainMenu();
        //    }
        //}

        public override void OnTriggerExit(Collider other)
        {
            base.OnTriggerExit(other);
            if (other.gameObject.name == setting.panelCollisionObject)
            {
                menuManager.MainMenu();
            }
        }

        public override void OnTriggerStay(Collider other)
        {
            base.OnTriggerStay(other);
        }
    }
}

