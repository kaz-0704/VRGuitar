using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;
using TMPro;

namespace VRGuitar
{
    public class Metronome : MonoBehaviour
    {
        public MidiStreamPlayer midiStreamPlayer;
        private MPTKEvent NotePlaying;
        public int bpm = 60;

        private float timeOut;
        private float timeElapsed = 0;

        private bool metronome = false;
        private TextMeshProUGUI bpmText;
        // Start is called before the first frame update
        void Start()
        {
            timeOut = 60 / bpm;
            bpmText = GetComponentInChildren<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            bpmText.text = "BPM: " + bpm;
            timeOut = 60 / bpm;
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

            GetComponent<Renderer>().material.color = Color.red;
            Invoke("SetColorDefault", 0.1f);
        }

        private void SetColorDefault()
        {
            GetComponent<Renderer>().material.color = Color.white;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (metronome)
            {
                metronome = false;
                Debug.Log("Metronome Off");
            }
            else
            {
                metronome = true;
                Debug.Log("Metronome On");
            }
        }
    }
}

