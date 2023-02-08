using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRGuitar
{
    /// <summary>
    /// メニューの各状態の列挙型
    /// </summary>
    enum State
    {
        /// <summary>
        /// メニューが開かれていない状態
        /// </summary>
        None,
        /// <summary>
        /// メインメニュー
        /// </summary>
        MainMenu,
        /// <summary>
        /// 演奏評価メニュー
        /// </summary>
        EvalMenu,
        /// <summary>
        /// 楽曲選択メニュー
        /// </summary>
        MusicSelectMenu,
        /// <summary>
        /// 演奏評価結果
        /// </summary>
        Result,
        /// <summary>
        /// 履歴閲覧
        /// </summary>
        History,
        /// <summary>
        /// 設定画面
        /// </summary>
        Setting,
    } 

    /// <summary>
    /// メニュー遷移を管理するクラス
    /// </summary>
    public class MenuManager : MonoBehaviour
    {
        public GameObject mainMenu;
        public GameObject evalMenu;
        public GameObject musicSelectMenu;
        public GameObject resultPage;
        public GameObject radarChart;
        public GameObject settingMenu;

        public AdviceManager adviceManager;
        public GameObject advicePanel;

        private State state;

        // Start is called before the first frame update
        void Start()
        {
            MainMenu();
        }

        public void InitialState()
        {
            mainMenu.SetActive(false);
            evalMenu.SetActive(false);
            musicSelectMenu.SetActive(false);
            resultPage.SetActive(false);
            settingMenu.SetActive(false);
            state = State.None;
        }

        public void MainMenu()
        {
            StartCoroutine(Pause());
            mainMenu.SetActive(true);
            evalMenu.SetActive(false);
            musicSelectMenu.SetActive(false);
            resultPage.SetActive(false);
            settingMenu.SetActive(false);
            state = State.MainMenu;
        }

        public void EvalMenu()
        {
            mainMenu.SetActive(false);
            evalMenu.SetActive(true);
            musicSelectMenu.SetActive(false);
            resultPage.SetActive(false);
            settingMenu.SetActive(false);
            state = State.EvalMenu;
        }

        public void SelectMenu()
        {
            StartCoroutine(Pause());
            mainMenu.SetActive(false);
            evalMenu.SetActive(false);
            musicSelectMenu.SetActive(true);
            resultPage.SetActive(false);
            settingMenu.SetActive(false);
            state = State.MusicSelectMenu;
        }

        public void WhileEvaluating()
        {
            mainMenu.SetActive(false);
            evalMenu.SetActive(false);
            musicSelectMenu.SetActive(false);
            resultPage.SetActive(true);
            radarChart.SetActive(false);
            state = State.Result;
        }

        public void GoSettingMenu()
        {
            mainMenu.SetActive(false);
            evalMenu.SetActive(false);
            musicSelectMenu.SetActive(false);
            resultPage.SetActive(false);
            settingMenu.SetActive(true);
        }

        public void OpenRadarChart()
        {
            //adviceManager.InitializeAdvicePanel();
            radarChart.SetActive(true);
            advicePanel.SetActive(true);
        }

        public void Back()
        {
            switch (state)
            {
                //case State.Main:
                //    InitialState();
                //    break;
                case State state when (state == State.EvalMenu || state == State.MusicSelectMenu || state == State.Setting):
                    MainMenu();
                    break;
                case State.Result:
                    EvalMenu();
                    break;
            }
        }

        public IEnumerator Pause()
        {
            yield return new WaitForSeconds(0.5f);
            yield break;
        }
    }
}

