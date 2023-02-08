using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

namespace VRGuitar
{
    /// <summary>
    /// コードパネルのボタンの色を変える
    /// </summary>
    public class ChordButtonManager : MonoBehaviour
    {
        [SerializeField] private GameObject ButtonA;
        [SerializeField] private GameObject ButtonAm;
        [SerializeField] private GameObject ButtonA_;
        [SerializeField] private GameObject ButtonA_m;
        [SerializeField] private GameObject ButtonB;
        [SerializeField] private GameObject ButtonBm;
        [SerializeField] private GameObject ButtonC;
        [SerializeField] private GameObject ButtonCm;
        [SerializeField] private GameObject ButtonC_;
        [SerializeField] private GameObject ButtonC_m;
        [SerializeField] private GameObject ButtonD;
        [SerializeField] private GameObject ButtonDm;
        [SerializeField] private GameObject ButtonD_;
        [SerializeField] private GameObject ButtonD_m;
        [SerializeField] private GameObject ButtonE;
        [SerializeField] private GameObject ButtonEm;
        [SerializeField] private GameObject ButtonF;
        [SerializeField] private GameObject ButtonFm;
        [SerializeField] private GameObject ButtonF_;
        [SerializeField] private GameObject ButtonF_m;
        [SerializeField] private GameObject ButtonG;
        [SerializeField] private GameObject ButtonGm;
        [SerializeField] private GameObject ButtonG_;
        [SerializeField] private GameObject ButtonG_m;

        [SerializeField] private TMP_Dropdown dropdown;

        public StringCollider stringCollider;
        Scale scale;
        Key key; 
        Setting setting = new Setting();
        private Button[] buttons = new Button[12];
        private GameObject[] buttonObjects = new GameObject[24];
        private GameObject[] scaleChords = new GameObject[12];

        // Start is called before the first frame update
        void Start()
        {
            scale = Scale.Major;
            buttonObjects = GameObject.FindGameObjectsWithTag("コードボタン");
            SetKey(Key.C);
        }

        private void Update()
        {
            switch (dropdown.value)
            {
                case 0:
                    SetScale(Scale.Major);
                    break;
                case 1:
                    SetScale(Scale.NaturalMinor);
                    break;
                case 2:
                    SetScale(Scale.Lydian);
                    break;
                case 3:
                    SetScale(Scale.Dorian);
                    break;
            }
        }

        /// <summary>
        /// コードを指定する
        /// </summary>
        /// <param name="chords"></param>
        public void SetChord(Chords chords)
        {
            ChangeButtonColor(chords);
            stringCollider.chord = chords;
        }

        /// <summary>
        /// 選択されたコードのボタンの色を変える
        /// </summary>
        /// <param name="chords"></param>
        private void ChangeButtonColor(Chords chords)
        {
            buttons = GetComponentsInChildren<Button>();
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].name == "Button" + chords.ToString())
                {
                    buttons[i].image.color = Color.green;
                }
                else
                {
                    buttons[i].image.color = Color.white;
                }
            }
        }

        public void SetScale(Scale chosenScale)
        {
            scale = chosenScale;
        }

        /// <summary>
        /// キーを指定する
        /// </summary>
        /// <param name="chosenScale"></param>
        public void SetKey(Key chosenKey)
        {
            switch (chosenKey)
            {
                case Key.C:
                    this.scaleChords = new GameObject[] { ButtonC, ButtonDm, ButtonEm, ButtonF, ButtonG, ButtonAm, ButtonBm };
                    break;
                case Key.C_:
                    this.scaleChords = new GameObject[] { ButtonC_, ButtonD_m, ButtonFm, ButtonF_, ButtonG_, ButtonA_m, ButtonCm };
                    break;
                case Key.D:
                    this.scaleChords = new GameObject[] { ButtonD, ButtonEm, ButtonF_m, ButtonG, ButtonA, ButtonBm, ButtonC_m };
                    break;
                case Key.D_:
                    this.scaleChords = new GameObject[] { ButtonD_, ButtonFm, ButtonGm, ButtonG_, ButtonA_, ButtonCm, ButtonDm };
                    break;
                case Key.E:
                    this.scaleChords = new GameObject[] { ButtonE, ButtonF_m, ButtonG_m, ButtonA, ButtonB, ButtonC_m, ButtonD_m };
                    break;
                case Key.F:
                    this.scaleChords = new GameObject[] { ButtonF, ButtonGm, ButtonAm, ButtonA_, ButtonC, ButtonDm, ButtonEm };
                    break;
                case Key.F_:
                    this.scaleChords = new GameObject[] { ButtonF_, ButtonFm, ButtonGm, ButtonG_, ButtonA_, ButtonCm, ButtonDm };
                    break;
                case Key.G:
                    this.scaleChords = new GameObject[] { ButtonD_, ButtonFm, ButtonGm, ButtonG_, ButtonA_, ButtonCm, ButtonDm };
                    break;
                case Key.G_:
                    this.scaleChords = new GameObject[] { ButtonD_, ButtonFm, ButtonGm, ButtonG_, ButtonA_, ButtonCm, ButtonDm };
                    break;
                case Key.A:
                    this.scaleChords = new GameObject[] { ButtonD_, ButtonFm, ButtonGm, ButtonG_, ButtonA_, ButtonCm, ButtonDm };
                    break;
                case Key.A_:
                    this.scaleChords = new GameObject[] { ButtonD_, ButtonFm, ButtonGm, ButtonG_, ButtonA_, ButtonCm, ButtonDm };
                    break;
                case Key.B:
                    this.scaleChords = new GameObject[] { ButtonD_, ButtonFm, ButtonGm, ButtonG_, ButtonA_, ButtonCm, ButtonDm };
                    break;
            }
            
            for (int i = 0; i < buttonObjects.Length; i++)
            {
                if (this.scaleChords.Contains(buttonObjects[i]))
                {
                    // 選ばれたスケールに含まれるコードのボタンのみをアクティブにする
                    buttonObjects[i].SetActive(true);
                }
                else
                {
                    buttonObjects[i].SetActive(false);
                }
            }
        }
    }
}
