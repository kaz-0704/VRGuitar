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
    public class MusicPlayer : MonoBehaviour
    {
        public MidiStreamPlayer midiStreamPlayer;
        public MidiFilePlayer midiFilePlayer;
        [SerializeField] private TextMeshProUGUI musicChordsText;
        private MPTKEvent NotePlaying;
        private Dictionary<float, string> cherryChords = new Dictionary<float, string>();

        private void Start()
        {
            cherryChords.Add(20 * 4 * 60 / 196f, "C");
            cherryChords.Add(2 * 4 * 60 / 196f, "G");
            cherryChords.Add(2 * 4 * 60 / 196f, "Am");
            cherryChords.Add(2 * 4 * 60 / 196f, "Em");
            cherryChords.Add(2 * 4 * 60 / 196f, "F");
            cherryChords.Add(2 * 4 * 60 / 196f, "C");
            cherryChords.Add(2 * 4 * 60 / 196f, "F");
            cherryChords.Add(2 * 4 * 60 / 196f, "G");
            cherryChords.Add(2 * 4 * 60 / 196f, "C");
            cherryChords.Add(2 * 4 * 60 / 196f, "G");
            cherryChords.Add(2 * 4 * 60 / 196f, "Am");
            cherryChords.Add(2 * 4 * 60 / 196f, "Em");
            cherryChords.Add(2 * 4 * 60 / 196f, "F");
            cherryChords.Add(1 * 4 * 60 / 196f, "G");
            cherryChords.Add(1 * 4 * 60 / 196f, "C");
            cherryChords.Add(1 * 4 * 60 / 196f, "Am");
            cherryChords.Add(1 * 4 * 60 / 196f, "F");
            cherryChords.Add(1 * 4 * 60 / 196f, "G");
            cherryChords.Add(1 * 4 * 60 / 196f, "C");
            cherryChords.Add(2 * 4 * 60 / 196f, "Am");
            cherryChords.Add(1 * 4 * 60 / 196f, "Em");
            cherryChords.Add(1 * 4 * 60 / 196f, "F");
            cherryChords.Add(1 * 4 * 60 / 196f, "C");
            cherryChords.Add(1 * 4 * 60 / 196f, "Am");
            cherryChords.Add(1 * 4 * 60 / 196f, "Em");
            cherryChords.Add(1 * 4 * 60 / 196f, "F");
            cherryChords.Add(1 * 4 * 60 / 196f, "C");
            cherryChords.Add(1 * 4 * 60 / 196f, "Am");
            cherryChords.Add(1 * 4 * 60 / 196f, "Em");
            cherryChords.Add(1 * 4 * 60 / 196f, "F");
            cherryChords.Add(1 * 4 * 60 / 196f, "C");
            cherryChords.Add(1 * 4 * 60 / 196f, "Am");
            cherryChords.Add(1 * 4 * 60 / 196f, "Em");
            cherryChords.Add(1 * 4 * 60 / 196f, "F");
            cherryChords.Add(0.5f * 4 * 60 / 196f, "G");
            cherryChords.Add(0.5f * 4 * 60 / 196f, "C");
        }

        public void PlayMusic()
        {
            midiFilePlayer.MPTK_Play();
            StartCoroutine(DisplayMusicNotes());
        }

        private IEnumerator DisplayMusicNotes()
        {
            foreach (KeyValuePair<float, string> dicItem in cherryChords)
            {
                yield return new WaitForSeconds(dicItem.Key);
                musicChordsText.text = dicItem.Value;
            }
            yield return new WaitForSeconds(1 * 4 * 60 / 196f);
            midiFilePlayer.MPTK_Stop();
            yield break;
        }

        
    }
}

