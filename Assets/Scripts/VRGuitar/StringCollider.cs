using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;
using Valve.VR;

namespace VRGuitar
{
    /// <summary>
    /// 弦オブジェクトの衝突判定, 演奏音を出す処理を行う
    /// </summary>
    public class StringCollider : MonoBehaviour
    {
        public MidiFilePlayer midiFilePlayer;
        public MidiStreamPlayer midiStreamPlayer;
        public MidiFileLoader MidiLoader;

        [SerializeField] [Range(0, 127)] private int preset;
        // Preset
        // 
        // 33, 34: アコギに近い

        Setting setting = new Setting();
        //public MidiExternalPlayer midiExternalPlayer;
        //public MidiInReader midiInReader;
        //public MidiListPlayer midiListPlayer;

        private MPTKEvent NotePlaying;
        public Chords chord;
        public RightHandRecorder rightRecorder;

        private SteamVR_Action_Pose right_tracker = SteamVR_Actions.default_Pose;

        // Start is called before the first frame update
        void Start()
        {
            midiFilePlayer = FindObjectOfType<MidiFilePlayer>();
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log(rightRecorder.RightHandAngularVelocity);
            //if (Input.GetKeyUp(KeyCode.RightArrow))
            //    preset += 1;
            //else if (Input.GetKeyUp(KeyCode.LeftArrow))
            //    preset -= 1;
            midiStreamPlayer.MPTK_ChannelPresetChange(0, preset);
        }

        void OnTriggerEnter(Collider other)    //弦とオブジェクトが重なったときに
        {
            if (other.gameObject.name == setting.playCollisionObject)
            //if (other.gameObject.name == setting.playCollisionObject | other.gameObject.name == "thumb_2_r")
            {
                //Debug.Log("Tatched");
                //音を鳴らす
                PlayChord();
            }
            //Debug.Log("String: " + other.gameObject.name);
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
        /// <summary>
        /// メジャーコードを鳴らす
        /// </summary>
        /// <param name="firstvalue"></param>
        /// <param name="volume"></param>
        private void PlayMajor(int firstvalue, int volume)
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

        /// <summary>
        /// マイナーコードを鳴らす
        /// </summary>
        /// <param name="firstvalue"></param>
        /// <param name="volume"></param>
        private void PlayMinor(int firstvalue, int volume)
        {
            int[] array = new int[] { firstvalue, firstvalue + 3, firstvalue + 7, firstvalue + 12, firstvalue + 15 };
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
            //float volumef = rightRecorder.RightHandAngularVelocity.x * 10f;
            //float volumef = right_tracker.GetAngularVelocity(SteamVR_Input_Sources.RightHand).x * 10f;
            //int volume = Mathf.Abs(Mathf.RoundToInt(volumef));
            int volume = 100;
            //Debug.Log("Volume: " + volume);
            //chord = Chords.C;
            switch (chord)
            {
                case Chords.C:
                    PlayMajor(48, volume);
                    break;

                case Chords.Cm:
                    PlayMinor(48, volume);
                    break;

                case Chords.C_:
                    PlayMajor(49, volume);
                    break;

                case Chords.C_m:
                    PlayMinor(49, volume);
                    break;

                case Chords.D:
                    PlayMajor(50, volume);
                    break;

                case Chords.Dm:
                    PlayMinor(50, volume);
                    break;

                case Chords.D_:
                    PlayMajor(51, volume);
                    break;

                case Chords.D_m:
                    PlayMinor(51, volume);
                    break;

                case Chords.E:
                    PlayMajor(52, volume);
                    break;

                case Chords.Em:
                    PlayMinor(52, volume);
                    break;

                case Chords.F:
                    PlayMajor(53, volume);
                    break;

                case Chords.Fm:
                    PlayMinor(53, volume);
                    break;

                case Chords.F_:
                    PlayMajor(54, volume);
                    break;

                case Chords.F_m:
                    PlayMinor(54, volume);
                    break;

                case Chords.G:
                    PlayMajor(55, volume);
                    break;

                case Chords.Gm:
                    PlayMinor(55, volume);
                    break;

                case Chords.G_:
                    PlayMajor(56, volume);
                    break;

                case Chords.G_m:
                    PlayMinor(56, volume);
                    break;

                case Chords.A:
                    PlayMajor(57, volume);
                    break;

                case Chords.Am:
                    PlayMinor(57, volume);
                    break;

                case Chords.A_:
                    PlayMajor(58, volume);
                    break;

                case Chords.A_m:
                    PlayMinor(58, volume);
                    break;

                case Chords.B:
                    PlayMajor(59, volume);
                    break;

                case Chords.Bm:
                    PlayMinor(59, volume);
                    break;
            }
        }
    }
}

