using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Valve.VR.InteractionSystem;

namespace VRGuitar
{
    public class CSVWriter : MonoBehaviour
    {
        StreamWriter sw;
        public RightHandRecorder rightTracker;
        public VelocityEstimator VE;
        public bool isRecording = false;

        private void Start()
        {
            string csvfilepath = $"C:/Users/xr/Documents/Oiwa/VRGuitar/Assets/Scripts/VRGuitar/PythonScripts/tracker_data.csv";
            if (File.Exists(csvfilepath))
            {
                File.Delete(csvfilepath);
            }
            FileStream fs = File.OpenWrite(csvfilepath);
            sw = new StreamWriter(fs);

            sw.Write("Time"); sw.Write(",");

            sw.Write("Right Hand Tracker Postion.x"); sw.Write(",");
            sw.Write("Right Hand Tracker Postion.y"); sw.Write(",");
            sw.Write("Right Hand Tracker Postion.z"); sw.Write(",");
            sw.Write("Right Hand Tracker Rotation.x"); sw.Write(",");
            sw.Write("Right Hand Tracker Rotation.y"); sw.Write(",");
            sw.Write("Right Hand Tracker Rotation.z"); sw.Write(",");
            sw.Write("Right Hand Tracker Velocity.x"); sw.Write(",");
            sw.Write("Right Hand Tracker Velocity.y"); sw.Write(",");
            sw.Write("Right Hand Tracker Velocity.z"); sw.Write(",");
            sw.Write("Right Hand Tracker AngularVelocity.x"); sw.Write(",");
            sw.Write("Right Hand Tracker AngularVelocity.y"); sw.Write(",");
            sw.Write("Right Hand Tracker AngularVelocity.z"); sw.Write(",");

            sw.WriteLine();
        }

        public void StartWriting()
        {
            isRecording = true;
        }

        // Update is called once per frame
        public void Update()
        {
            if (isRecording)
            {
                sw.Write(DateTime.Now.ToString("yyyyMMdd-HHmmssfff")); sw.Write(",");

                sw.Write(rightTracker.RightHandPosition.x); sw.Write(",");
                sw.Write(rightTracker.RightHandPosition.y); sw.Write(",");
                sw.Write(rightTracker.RightHandPosition.z); sw.Write(",");
                sw.Write(rightTracker.RightHandRotation.x); sw.Write(",");
                sw.Write(rightTracker.RightHandRotation.y); sw.Write(",");
                sw.Write(rightTracker.RightHandRotation.z); sw.Write(",");
                sw.Write(VE.GetVelocityEstimate().x); sw.Write(",");
                sw.Write(VE.GetVelocityEstimate().y); sw.Write(",");
                sw.Write(VE.GetVelocityEstimate().z); sw.Write(",");
                sw.Write(VE.GetAngularVelocityEstimate().x); sw.Write(",");
                sw.Write(VE.GetAngularVelocityEstimate().y); sw.Write(",");
                sw.Write(VE.GetAngularVelocityEstimate().z); sw.Write(",");

                sw.WriteLine();
            }
        }

        public void EndWriting()
        {
            Debug.Log("Closing csv File");
            sw.Close();
            isRecording = false;
        }
    }
}