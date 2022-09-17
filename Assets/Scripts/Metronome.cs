using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

namespace VRGuitar
{
    public class Metronome : MonoBehaviour
    {
        public MidiStreamPlayer midiStreamPlayer;
        private MPTKEvent NotePlaying;
        public int bpm;

        private float timeOut;
        private float timeElapsed = 0;

        public bool metronome = true;
        // Start is called before the first frame update
        void Start()
        {
            timeOut = 60 / bpm;
        }

        // Update is called once per frame
        void Update()
        {
            if (metronome)
            {
                timeElapsed += Time.deltaTime;
                if (timeElapsed >= timeOut)
                {
                    OnMetronome();
                    timeElapsed = 0.0f;
                }
            }
        }

        public void OnMetronome()
        {
            midiStreamPlayer.MPTK_ChannelPresetChange(1, 113);
            NotePlaying = new MPTKEvent()
            {
                Command = MPTKCommand.NoteOn,
                Value = 72,
                Channel = 1,
                Duration = 200,
                Velocity = 100,
                Delay = 0,
            };
            midiStreamPlayer.MPTK_PlayEvent(NotePlaying);
        }
    }
}

