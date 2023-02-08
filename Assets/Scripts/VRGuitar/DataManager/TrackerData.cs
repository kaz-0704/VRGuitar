using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace VRGuitar
{
    [Serializable]
    public class TrackerData 
    {
        public string Time;
        public float Position_x;
        public float Position_y;
        public float Position_z;
        public float Rotation_x;
        public float Rotation_y;
        public float Rotation_z;
        public float Velocity_x;
        public float Velocity_y;
        public float Velocity_z;
        public float AngularVelocity_x;
        public float AngularVelocity_y;
        public float AngularVelocity_z;
    }
}

