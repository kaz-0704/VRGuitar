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

        // Start is called before the first frame update
        void Start()
        {
            midiFilePlayer = FindObjectOfType<MidiFilePlayer>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider other)    //���ƃI�u�W�F�N�g���d�Ȃ����Ƃ���
        {
            Debug.Log("String: " + other.gameObject.name);

            //����炷
            PlayChord();
        }

        public void PlayChord()
        {
            NotePlaying = new MPTKEvent()
            {
                Command = MPTKCommand.NoteOn,
                Value = 60,
                Channel = 0,
                Duration = 1000,
                Velocity = 100,
                Delay = 0,
            };
            midiStreamPlayer.MPTK_PlayEvent(NotePlaying);
        }
    }
}

