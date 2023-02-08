using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

namespace VRGuitar
{
    /// <summary>
    /// コードパネルのボタンの色を変える
    /// </summary>
    public class VRChordButtonManager : MonoBehaviour
    {
        public StringCollider stringCollider;

        
        public void SetChord_C()
        {
            stringCollider.chord = Chords.C;
        }

        public void SetChord_Dm()
        {
            stringCollider.chord = Chords.Dm;
        }

        public void SetChord_Em()
        {
            stringCollider.chord = Chords.Em;
        }

        public void SetChord_F()
        {
            stringCollider.chord = Chords.F;
        }

        public void SetChord_G()
        {
            stringCollider.chord = Chords.G;
        }

        public void SetChord_Am()
        {
            stringCollider.chord = Chords.Am;
        }

        public void SetChord_Bm()
        {
            stringCollider.chord = Chords.Bm;
        }
    }
}
