using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using MidiPlayerTK;
using TMPro;

namespace VRGuitar
{
    /// <summary>
    /// ÉÅÉgÉçÉmÅ[ÉÄÇñ¬ÇÁÇ∑
    /// </summary>
    public class MusicPlayer : MonoBehaviour
    {
        public MidiStreamPlayer midiStreamPlayer;
        public MidiFilePlayer midiFilePlayer;
        [SerializeField] private TextMeshProUGUI musicChordsText;
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject musicPanel;
        private MPTKEvent NotePlaying;
        private List<Tuple<float, string>> cherryChords;
        private float _speed;

        private void Start()
        {
            _speed = midiFilePlayer.MPTK_Speed;
            Debug.Log("Music Speed: " + _speed);
            cherryChords = new List<Tuple<float, string>>
            {
                Tuple.Create(20 * 4 * 60 / (196f * _speed), "C"),
                Tuple.Create(2 * 4 * 60 / (196f * _speed), "G"),
                Tuple.Create(2 * 4 * 60 / (196f * _speed), "Am"),
                Tuple.Create(2 * 4 * 60 / (196f * _speed), "Em"),
                Tuple.Create(2 * 4 * 60 / (196f * _speed), "F"),
                Tuple.Create(2 * 4 * 60 / (196f * _speed), "C"),
                Tuple.Create(2 * 4 * 60 / (196f * _speed), "F"),
                Tuple.Create(2 * 4 * 60 / (196f * _speed), "G"),
                Tuple.Create(2 * 4 * 60 / (196f * _speed), "C"),
                Tuple.Create(2 * 4 * 60 / (196f * _speed), "G"),
                Tuple.Create(2 * 4 * 60 / (196f * _speed), "Am"),
                Tuple.Create(2 * 4 * 60 / (196f * _speed), "Em"),
                Tuple.Create(2 * 4 * 60 / (196f * _speed), "F"),
                Tuple.Create(1 * 4 * 60 / (196f * _speed), "G"),
                Tuple.Create(1 * 4 * 60 / (196f * _speed), "C"),
                Tuple.Create(1 * 4 * 60 / (196f * _speed), "Am"),
                Tuple.Create(1 * 4 * 60 / (196f * _speed), "F"),
                Tuple.Create(1 * 4 * 60 / (196f * _speed), "G"),
                Tuple.Create(1 * 4 * 60 / (196f * _speed), "C"),
                Tuple.Create(2 * 4 * 60 / (196f * _speed), "Am"),
                Tuple.Create(1 * 4 * 60 / (196f * _speed), "Em"),
                Tuple.Create(1 * 4 * 60 / (196f * _speed), "F"),
                Tuple.Create(1 * 4 * 60 / (196f * _speed), "C"),
                Tuple.Create(1 * 4 * 60 / (196f * _speed), "Am"),
                Tuple.Create(1 * 4 * 60 / (196f * _speed), "Em"),
                Tuple.Create(1 * 4 * 60 / (196f * _speed), "F"),
                Tuple.Create(1 * 4 * 60 / (196f * _speed), "C"),
                Tuple.Create(1 * 4 * 60 / (196f * _speed), "Am"),
                Tuple.Create(1 * 4 * 60 / (196f * _speed), "Em"),
                Tuple.Create(1 * 4 * 60 / (196f * _speed), "F"),
                Tuple.Create(1 * 4 * 60 / (196f * _speed), "C"),
                Tuple.Create(1 * 4 * 60 / (196f * _speed), "Am"),
                Tuple.Create(1 * 4 * 60 / (196f * _speed), "Em"),
                Tuple.Create(1 * 4 * 60 / (196f * _speed), "F"),
                Tuple.Create(0.5f * 4 * 60 / (196f * _speed), "G"),
                Tuple.Create(0.5f * 4 * 60 / (196f * _speed), "C"),
            };
        }

        public void PlayMusic()
        {
            menuPanel.SetActive(false);
            musicPanel.SetActive(true);
            midiFilePlayer.MPTK_Play();
            StartCoroutine(DisplayMusicNotes());
        }

        private IEnumerator DisplayMusicNotes()
        {
            foreach (var tuple in cherryChords)
            {
                yield return new WaitForSeconds(tuple.Item1);
                musicChordsText.text = tuple.Item2;
            }
            yield return new WaitForSeconds(0.5f * 4 * 60 / (196f * _speed));
            midiFilePlayer.MPTK_Stop();
            yield return new WaitForSeconds(2f);
            menuPanel.SetActive(true);
            musicPanel.SetActive(false);
            yield break;
        }

        
    }
}

