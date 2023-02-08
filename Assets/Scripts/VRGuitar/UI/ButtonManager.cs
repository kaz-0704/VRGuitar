using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace VRGuitar
{
    /// <summary>
    /// UIボタンの基底クラス
    /// </summary>
    public class ButtonManager : MonoBehaviour
    {
        private Button button;
        private TextMeshProUGUI buttonText;

        public virtual void Start()
        {
            button = gameObject.GetComponent<Button>();
            buttonText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        }

        public virtual void OnTriggerStay(Collider other)
        {
            Debug.Log("stay");
            button.image.color = new Color(0, 1, 1, 1f);
            //buttonText.color = Color.white;
        }

        public virtual void OnTriggerExit(Collider other)
        {
            Debug.Log("exit");
            button.image.color = Color.white;
            buttonText.color = Color.black;
        }
    }
}

