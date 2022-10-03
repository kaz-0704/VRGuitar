using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRGuitar
{
    public class Setting
    {
        // The name of object intaract with string.
        public string playCollisionObject = "finger_ring_2_r";

        // The name of object specifying chord with guitar neck.
        public string chordCollisionObject = "finger_middle_0_r";

        // The name of object specifying chord with panel.
        public string panelCollisionObject = "finger_index_2_r";

        // Number of chords
        public int numberOfChords = 12;
    }
}
