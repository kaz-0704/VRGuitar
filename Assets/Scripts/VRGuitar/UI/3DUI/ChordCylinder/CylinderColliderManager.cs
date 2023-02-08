using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace VRGuitar
{
    /// <summary>
    /// Chord Cylinder �̃R���C�_�[���Ǘ�����
    /// </summary>
    public class CylinderColliderManager : MonoBehaviour
    {
        [SerializeField] private GameObject chordCylinder;
        private BoxCollider[] cylinders;

        // Start is called before the first frame update
        void Start()
        {
            cylinders = chordCylinder.GetComponentsInChildren<BoxCollider>();
        }

        /// <summary>
        /// �G����Ă��Ȃ�Chord Cylinder �̃R���C�_�[�𖳌�������
        /// </summary>
        /// <param name="validCylinder"></param>
        public void DisableOtherColliders(GameObject validCylinder)
        {
            foreach (var cylinder in cylinders)
            {
                if (cylinder.name != validCylinder.name)
                {
                    cylinder.GetComponent<BoxCollider>().enabled = false;
                }
            }
        }

        /// <summary>
        /// ���ׂĂ�Chord Cylinder �̃R���C�_�[��L��������
        /// </summary>
        public void EnableAllColliders()
        {
            foreach (var cylinder in cylinders)
            {
                cylinder.GetComponent<BoxCollider>().enabled = true;
            }
        }

        /// <summary>
        /// �I�����ꂽ Cylinder �����点��
        /// </summary>
        /// <param name="validCylinder"></param>
        public void SelectCylinder(GameObject validCylinder, Material[] materials)
        {
            foreach (var cylinder in cylinders)
            {
                if (cylinder.name == validCylinder.name)
                {
                    cylinder.GetComponent<ChordCylinder>().Selected = true;
                    cylinder.GetComponent<Renderer>().material = materials[1];
                    cylinder.GetComponentInChildren<TextMeshProUGUI>().fontSize = 48;
                }
                else
                {
                    cylinder.GetComponent<ChordCylinder>().Selected = false;
                    cylinder.GetComponent<Renderer>().material = materials[0];
                    TextMeshProUGUI text = cylinder.GetComponentInChildren<TextMeshProUGUI>();
                    text.fontSize = 20;
                    text.transform.localPosition = new Vector3(0, 0, 0);
                }
            }
        }
    }
}

