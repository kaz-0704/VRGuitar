using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace VRGuitar
{
    public class ChordText : MonoBehaviour
    {
        public TextMeshProUGUI chordText;
        public StringCollider stringCollider;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            switch (stringCollider.chord)
            {
                case Chords.A:
                    chordText.text = "A";
                    break;
                case Chords.A_:
                    chordText.text = "A#";
                    break;
                case Chords.B:
                    chordText.text = "B";
                    break;
                case Chords.C:
                    chordText.text = "C";
                    break;
                case Chords.C_:
                    chordText.text = "C#";
                    break;
                case Chords.D:
                    chordText.text = "D";
                    break;
                case Chords.D_:
                    chordText.text = "D#";
                    break;
                case Chords.E:
                    chordText.text = "E";
                    break;
                case Chords.F:
                    chordText.text = "F";
                    break;
                case Chords.F_:
                    chordText.text = "F#";
                    break;
                case Chords.G:
                    chordText.text = "G";
                    break;
                case Chords.G_:
                    chordText.text = "G#";
                    break;
            }
        }
    }
}

