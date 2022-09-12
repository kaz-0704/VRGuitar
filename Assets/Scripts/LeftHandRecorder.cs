using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LeftHandRecorder : MonoBehaviour
{
    public Vector3 LeftHandPosition;      //位置
    public Quaternion LeftHandRotationQ;  //クォータニオン回転座標
    public Vector3 LeftHandRotation;      //オイラー角
    public Vector3 LeftHandVelocity;      //速度
    public Vector3 LeftHandAngularVelocity;    //角速度
    public float LeftHandAngularVelocityMagnitude;

    private SteamVR_Action_Pose left_tracker = SteamVR_Actions.default_Pose;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LeftHandPosition = left_tracker.GetLocalPosition(SteamVR_Input_Sources.LeftHand);
        LeftHandRotationQ = left_tracker.GetLocalRotation(SteamVR_Input_Sources.LeftHand);
        LeftHandRotation = LeftHandRotationQ.eulerAngles;
        LeftHandVelocity = left_tracker.GetLastVelocity(SteamVR_Input_Sources.LeftHand);
        LeftHandAngularVelocity = left_tracker.GetAngularVelocity(SteamVR_Input_Sources.LeftHand);
        LeftHandAngularVelocityMagnitude = CalcMagnitude(LeftHandAngularVelocity);

        //Debug.Log(LeftHandAngularVelocityMagnitude);
    }

    float CalcMagnitude(Vector3 vector)
    {
        float temp = Mathf.Pow(vector[0], 2) + Mathf.Pow(vector[1], 2) + Mathf.Pow(vector[2], 2);
        return Mathf.Sqrt(temp);
    }
}
