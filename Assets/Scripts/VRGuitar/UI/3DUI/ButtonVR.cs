using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace VRGuitar
{
    public class ButtonVR : MonoBehaviour
    {
        public GameObject button;
        public UnityEvent onPress;
        public UnityEvent onRelease;
        public float pushDepth = 0.003f;
        [SerializeField] private Image buttonImage;
        [SerializeField] Color32 buttonColor = Color.white;
        [SerializeField] Color32 pressedColor = Color.blue;
        private Vector3 originPosition;
        Setting setting = new Setting();
        GameObject presser;
        AudioSource sound;
        bool isPressed;

        void Start()
        {
            sound = GetComponent<AudioSource>();
            isPressed = false;
            originPosition = gameObject.transform.localPosition;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!isPressed && other.name == setting.panelCollisionObject)
            {
                button.transform.localPosition = new Vector3(0, pushDepth, 0);
                presser = other.gameObject;
                onPress.Invoke();
                ChangeButtonColor();
                sound.Play();
                isPressed = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == presser)
            {
                button.transform.localPosition = originPosition;
                onRelease.Invoke();
                ResetButtonColor();
                isPressed = false;
            }
        }

        private void ChangeButtonColor()
        {
            buttonImage.color = pressedColor;
        }

        private void ResetButtonColor()
        {
            buttonImage.color = buttonColor;
        }
    }
}

