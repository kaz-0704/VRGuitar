using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRGuitar
{
    /// <summary>
    /// ‰‰‘t•]‰¿‰æ–Ê‚ðŠJ‚­ƒ{ƒ^ƒ“
    /// </summary>
    public class EvalButton : ButtonManager
    {
        Setting setting = new Setting();
        public MenuManager menuManager;

        //void OnTriggerEnter(Collider other)
        //{
        //    if (other.gameObject.name == setting.panelCollisionObject)
        //    {
        //        menuManager.EvalMenu();
        //    }
        //}

        public override void OnTriggerExit(Collider other)
        {
            base.OnTriggerExit(other);
            if (other.gameObject.name == setting.panelCollisionObject)
            {
                menuManager.EvalMenu();
            }
        }

        public override void OnTriggerStay(Collider other)
        {
            base.OnTriggerStay(other);
        }
    }
}

