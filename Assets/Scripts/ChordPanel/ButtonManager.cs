using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VRGuitar
{
    public class ButtonManager : MonoBehaviour
    {
        public StringCollider stringCollider;
        Setting setting = new Setting();
        Button[] buttons = new Button[12];
        // Start is called before the first frame update
        void Start()
        {
            buttons = GetComponentsInChildren<Button>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetChord(Chords chords)
        {
            ChangeButtonColor(chords);
            stringCollider.chord = chords;
        }

        private void ChangeButtonColor(Chords chords)
        {
            Button pushedButton = buttons[(int)chords-1];   // enum->int and get whitch button pushed
            for (int i = 0; i < setting.numberOfChords ; i++)
            {
                buttons[i].image.color = Color.white;
            }
            pushedButton.image.color = Color.green;
        }
    }
}
