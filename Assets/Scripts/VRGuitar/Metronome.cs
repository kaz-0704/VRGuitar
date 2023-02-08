using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;
using TMPro;

namespace VRGuitar
{
    /// <summary>
    /// ÉÅÉgÉçÉmÅ[ÉÄÇñ¬ÇÁÇ∑
    /// </summary>
    public class Metronome : MonoBehaviour
    {
        public MidiStreamPlayer midiStreamPlayer;
        private MPTKEvent NotePlaying;
        public float bpm;
        public EvaluateModeManager evaluate;
        public JsonWriter jsonWriter;
        public CSVWriter csvWriter;
        public TextMeshProUGUI resultText;

        private float timeOut;
        private float timeElapsed = 0;
        private int count = 0;

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
            //bpmText.text = "BPM: " + bpm;
            timeOut = 60 / bpm;
            if (metronome)
            {
                timeElapsed += Time.deltaTime;
                if (timeElapsed >= timeOut)
                {
                    ClickMetronome();
                    if (evaluate.eval_mode) count += 1;
                    timeElapsed = timeElapsed - timeOut;
                }
            }

            if (0 < count && count < 5) { resultText.text = "" + (5 - count); }
            else if (5 <= count && count <= 13) { resultText.text = "Recording..."; }

            if (count >= 5)
            {
                jsonWriter.StartWriting();
                csvWriter.StartWriting();
            }

            if (count >= 13 && evaluate.eval_mode)
            {
                count = 0;
                jsonWriter.EndWriting();
                csvWriter.EndWriting();
                evaluate.StopRecording();
            }
        }

        public void ClickMetronome()
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

            ChangeColor();
            Invoke("SetColorDefault", 0.1f);
        }

        private void ChangeColor()
        {
            GetComponent<Renderer>().material.color = Color.red;
        }

        private void SetColorDefault()
        {
            GetComponent<Renderer>().material.color = Color.white;
        }

        public void OnMetronome()
        {
            metronome = true;
        }

        public void OffMetronome()
        {
            metronome = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (metronome)
            {
                OffMetronome();
            }
            else
            {
                OnMetronome();
            }
        }
    }
}

