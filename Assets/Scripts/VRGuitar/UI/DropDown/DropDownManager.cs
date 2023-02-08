using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace VRGuitar
{
    /// <summary>
    /// ドロップダウンメニューを制御する
    /// </summary>
    public class DropDownManager : MonoBehaviour
    {
        private TMP_Dropdown dropdown;

        /// <summary>
        /// ドロップダウンメニューが開かれているかどうか
        /// </summary>
        private bool opened;

        void Start()
        {
            dropdown = gameObject.GetComponent<TMP_Dropdown>();
        }


        private void OnTriggerExit(Collider other)
        {
            if (opened)
            {
                dropdown.Hide();
            }
            else
            {
                dropdown.Show();
            }
        }

        public void SetDropDownValue(int value)
        {
            dropdown.value = value;
        }
    }
}


