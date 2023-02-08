using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace VRGuitar
{
    /// <summary>
    /// Chord Cylinder のコライダーを管理する
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
        /// 触れられていないChord Cylinder のコライダーを無効化する
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
        /// すべてのChord Cylinder のコライダーを有効化する
        /// </summary>
        public void EnableAllColliders()
        {
            foreach (var cylinder in cylinders)
            {
                cylinder.GetComponent<BoxCollider>().enabled = true;
            }
        }

        /// <summary>
        /// 選択された Cylinder を光らせる
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

