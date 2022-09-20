using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

namespace VRGuitar
{
    public class StringCollider : MonoBehaviour
    {
        public MidiFilePlayer midiFilePlayer;
        public MidiStreamPlayer midiStreamPlayer;
        public MidiFileLoader MidiLoader;
        Setting setting = new Setting();
        //public MidiExternalPlayer midiExternalPlayer;
        //public MidiInReader midiInReader;
        //public MidiListPlayer midiListPlayer;

        private MPTKEvent NotePlaying;
        public Chords chord;
        public RightHandRecorder rightRecorder;

        // Start is called before the first frame update
        void Start()
        {
            midiFilePlayer = FindObjectOfType<MidiFilePlayer>();
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log(rightRecorder.RightHandAngularVelocity);
        }

        void OnTriggerEnter(Collider other)    //弦とオブジェクトが重なったときに
        {
            if (other.gameObject.name == setting.playCollisionObject)
            //if (other.gameObject.name == setting.playCollisionObject | other.gameObject.name == "finger_ring_1_r")
            {
                //音を鳴らす
                PlayChord();
            }
            Debug.Log("String: " + other.gameObject.name);
        }

        //public void PlayChord()
        //{
        //    midiFilePlayer.MPTK_Stop();
        //    if (chord == Chords.A) { midiFilePlayer.MPTK_MidiName = "A"; }
        //    else if (chord == Chords.B) { midiFilePlayer.MPTK_MidiName = "B"; }
        //    else if (chord == Chords.C) { midiFilePlayer.MPTK_MidiName = "C"; }
        //    else if (chord == Chords.D) { midiFilePlayer.MPTK_MidiName = "D"; }
        //    else if (chord == Chords.E) { midiFilePlayer.MPTK_MidiName = "E"; }
        //    else if (chord == Chords.F) { midiFilePlayer.MPTK_MidiName = "F"; }
        //    else if (chord == Chords.G) { midiFilePlayer.MPTK_MidiName = "G"; }
        //    Debug.Log(midiFilePlayer.MPTK_MidiName);
        //    midiFilePlayer.MPTK_Play();
        //}

        //MIDIStreamPlayerのセット　引数：（コードの根音, ボリューム）
        private void PlayMIDI(int firstvalue, int volume)
        {
            int[] array = new int[] { firstvalue, firstvalue + 4, firstvalue + 7, firstvalue + 12, firstvalue + 16 };
            for (int i = 0; i < 5; i++)
            {
                NotePlaying = new MPTKEvent()
                {
                    Command = MPTKCommand.NoteOn,
                    Value = array[i],
                    Channel = 0,
                    Duration = 1000,
                    Velocity = volume,
                    Delay = 0,
                };
                midiStreamPlayer.MPTK_PlayEvent(NotePlaying);
            }
        }

        // コードを鳴らす関数
        public void PlayChord()
        {
            float volumef = rightRecorder.RightHandAngularVelocity.x * 10f;
            int volume = Mathf.Abs(Mathf.RoundToInt(volumef));
            //Debug.Log("Volume: " + volume);
            //chord = Chords.C;
            switch (chord)
            {
                case Chords.C:
                    PlayMIDI(48, volume);
                    break;

                case Chords.C_:
                    PlayMIDI(49, volume);
                    break;

                case Chords.D:
                    PlayMIDI(50, volume);
                    break;

                case Chords.D_:
                    PlayMIDI(51, volume);
                    break;

                case Chords.E:
                    PlayMIDI(52, volume);
                    break;

                case Chords.F:
                    PlayMIDI(53, volume);
                    break;

                case Chords.F_:
                    PlayMIDI(54, volume);
                    break;

                case Chords.G:
                    PlayMIDI(55, volume);
                    break;

                case Chords.G_:
                    PlayMIDI(56, volume);
                    break;

                case Chords.A:
                    PlayMIDI(57, volume);
                    break;

                case Chords.A_:
                    PlayMIDI(58, volume);
                    break;

                case Chords.B:
                    PlayMIDI(59, volume);
                    break;
            }
        }
    }
}

