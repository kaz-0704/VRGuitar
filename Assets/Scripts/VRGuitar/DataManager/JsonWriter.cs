using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Valve.VR.InteractionSystem;

namespace VRGuitar
{
    public class JsonWriter : MonoBehaviour
    {
        StreamWriter sw;
        TrackerData data;
        public RightHandRecorder rightTracker;
        public VelocityEstimator VE;
        public bool isRecording = false;

        public void GetReadyWriting()
        {
            string jsonfilepath = $"C:/Users/xr/Documents/Oiwa/VRGuitar/Assets/Scripts/VRGuitar/PythonScripts/tracker_data.json";
            if (File.Exists(jsonfilepath))
            {
                File.Delete(jsonfilepath);
            }
            FileStream fs = File.OpenWrite(jsonfilepath);
            sw = new StreamWriter(fs);

            sw.Write("[");
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
                TrackerData data = new TrackerData()
                {
                    Time = DateTime.Now.ToString("yyyyMMdd-HHmmssfff"),
                    Position_x = rightTracker.RightHandPosition.x,
                    Position_y = rightTracker.RightHandPosition.y,
                    Position_z = rightTracker.RightHandPosition.z,
                    Rotation_x = rightTracker.RightHandRotation.x,
                    Rotation_y = rightTracker.RightHandRotation.y,
                    Rotation_z = rightTracker.RightHandRotation.z,
                    Velocity_x = VE.GetVelocityEstimate().x,
                    Velocity_y = VE.GetVelocityEstimate().y,
                    Velocity_z = VE.GetVelocityEstimate().z,
                    AngularVelocity_x = VE.GetAngularVelocityEstimate().x,
                    AngularVelocity_y = VE.GetAngularVelocityEstimate().y,
                    AngularVelocity_z = VE.GetAngularVelocityEstimate().z,
                };
                sw.Write(JsonUtility.ToJson(data));
                sw.Write(",");
            }
        }

        public void EndWriting()
        {
            sw.Flush();
            sw.BaseStream.Position -= 1;
            sw.Write("]");

            Debug.Log("Closing json File");
            sw.Close();
            isRecording = false;
        }
    }
}

