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
            if (other.gameObject.name == "finger_ring_2_r")
            {
                Debug.Log("String: " + other.gameObject.name);

                //音を鳴らす
                PlayChord();
            }
        }

        public void PlayChord()
        {
            midiFilePlayer.MPTK_Stop();
            if (chord == Chords.A) { midiFilePlayer.MPTK_MidiName = "A"; }
            else if (chord == Chords.B) { midiFilePlayer.MPTK_MidiName = "B"; }
            else if (chord == Chords.C) { midiFilePlayer.MPTK_MidiName = "C"; }
            else if (chord == Chords.D) { midiFilePlayer.MPTK_MidiName = "D"; }
            else if (chord == Chords.E) { midiFilePlayer.MPTK_MidiName = "E"; }
            else if (chord == Chords.F) { midiFilePlayer.MPTK_MidiName = "F"; }
            else if (chord == Chords.G) { midiFilePlayer.MPTK_MidiName = "G"; }
            Debug.Log(midiFilePlayer.MPTK_MidiName);

            //右手の速度を取得してボリュームを変更
            //if (rightRecorder.RightHandAngularVelocityMagnitude > 10.0f)
            //{
            //    midiFilePlayer.MPTK_ChannelVolumeSet(0, 1.0f);
            //    Debug.Log("Set Volume: " + 1.0f);
            //}
            //else
            //{
            //    midiFilePlayer.MPTK_ChannelVolumeSet(0, 0.5f);
            //    Debug.Log("Set Volume: " + 0.5f);
            //}

            midiFilePlayer.MPTK_Play();
        }

        //public void PlayChord()
        //{
        //    NotePlaying = new MPTKEvent()
        //    {
        //        Command = MPTKCommand.NoteOn,
        //        Value = 60,
        //        Channel = 0,
        //        Duration = 1000,
        //        Velocity = 100,
        //        Delay = 0,
        //    };
        //    midiStreamPlayer.MPTK_PlayEvent(NotePlaying);
        //}
    }
}

