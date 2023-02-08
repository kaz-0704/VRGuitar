using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRGuitar
{
    /// <summary>
    /// 評価を開始するボタン
    /// </summary>
    public class EvalStartButton : ButtonManager
    {
        Setting setting = new Setting();
        public MenuManager menuManager;
        public EvaluateModeManager evalManager;

        //void OnTriggerEnter(Collider other)
        //{
        //    if (other.gameObject.name == setting.panelCollisionObject)
        //    {
        //        menuManager.WhileEvaluating();
        //        evalManager.StartEvaluating();
        //    }
        //}

        public override void OnTriggerExit(Collider other)
        {
            base.OnTriggerExit(other);
            if (other.gameObject.name == setting.panelCollisionObject)
            {
                menuManager.WhileEvaluating();
                evalManager.StartEvaluating();
            }
        }

        public override void OnTriggerStay(Collider other)
        {
            base.OnTriggerStay(other);
        }
    }
}

