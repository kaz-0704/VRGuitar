using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace VRGuitar
{
    public class RightHandRecorder : MonoBehaviour
    {
        public Vector3 RightHandPosition;      //位置
        public Quaternion RightHandRotationQ;  //クォータニオン回転座標
        public Vector3 RightHandRotation;      //オイラー角
        public Vector3 RightHandVelocity;      //速度
        public Vector3 RightHandAngularVelocity;    //角速度
        public float RightHandAngularVelocityMagnitude;

        private SteamVR_Action_Pose right_tracker = SteamVR_Actions.default_Pose;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            RightHandPosition = right_tracker.GetLocalPosition(SteamVR_Input_Sources.RightHand);
            RightHandRotationQ = right_tracker.GetLocalRotation(SteamVR_Input_Sources.RightHand);
            RightHandRotation = RightHandRotationQ.eulerAngles;
            RightHandVelocity = right_tracker.GetLastVelocity(SteamVR_Input_Sources.RightHand);
            RightHandAngularVelocity = right_tracker.GetAngularVelocity(SteamVR_Input_Sources.RightHand);
            RightHandAngularVelocityMagnitude = CalcMagnitude(RightHandAngularVelocity);
            //right_tracker.GetAngularVelocity(SteamVR_Input_Sources.RightHand);

            //Debug.Log(RightHandAngularVelocity);
        }

        float CalcMagnitude(Vector3 vector)
        {
            float temp = Mathf.Pow(vector[0], 2) + Mathf.Pow(vector[1], 2) + Mathf.Pow(vector[2], 2);
            return Mathf.Sqrt(temp);
        }
    }
}

