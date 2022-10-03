using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRGuitar
{
    public class ChordHandManager : MonoBehaviour
    {
        // ������M�^�[�̃l�b�N�ɉ����ē����悤�ɂ���
        public LeftHandRecorder leftRecorder;
        private GameObject Guitar;
        private GameObject leftHand;

        // Start is called before the first frame update
        void Start()
        {
            Guitar = GameObject.Find("GuitarA");
            leftHand = GameObject.Find("LeftHand");
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 HandPosition = leftRecorder.LeftHandPosition;
            Vector3 GuitarPosition = Guitar.transform.position;
            Vector3 GuitarUpDirection = Guitar.transform.up;

            leftHand.transform.position = GuitarPosition + Vector3.Dot(HandPosition - GuitarPosition, GuitarUpDirection) * GuitarUpDirection;
        }
    }
}
