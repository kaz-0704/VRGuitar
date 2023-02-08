using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Valve.VR;

namespace VRGuitar
{
    public class ChordCylinder : MonoBehaviour
    {
        public GameObject cylinder;
        public Material[] materials;
        public UnityEvent onPress;
        public UnityEvent onRelease;
        public UnityEvent onStay;
        public CylinderColliderManager cylinderManager;
        public TextMeshProUGUI text;
        public SteamVR_Action_Skeleton skeletonAction;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        private float upHeight = 18f;
        private Vector3 originPosition;
        private bool selected = false;
        Setting setting = new Setting();
        GameObject presser;
        AudioSource sound;

        void Start()
        {
            originPosition = text.transform.localPosition;
            gameObject.GetComponent<Renderer>().material = materials[0];
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == setting.chordCollisionObject)
            {
                presser = other.gameObject;
                text.fontSize = 36;
                text.transform.localPosition = new Vector3(0, upHeight, 0);
                onPress.Invoke();
                cylinderManager.DisableOtherColliders(gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == presser)
            {
                if (!selected)
                {
                    text.transform.localPosition = originPosition;
                    text.fontSize = 20;
                }
                onRelease.Invoke();
                cylinderManager.EnableAllColliders();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject == presser && skeletonAction.thumbCurl > 0.5)
            {
                cylinderManager.SelectCylinder(gameObject, materials);
                onStay.Invoke();
            }
        }
    }
}

