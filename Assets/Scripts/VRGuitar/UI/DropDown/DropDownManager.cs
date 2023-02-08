using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace VRGuitar
{
    /// <summary>
    /// �h���b�v�_�E�����j���[�𐧌䂷��
    /// </summary>
    public class DropDownManager : MonoBehaviour
    {
        private TMP_Dropdown dropdown;

        /// <summary>
        /// �h���b�v�_�E�����j���[���J����Ă��邩�ǂ���
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


