using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace VRGuitar
{
    enum AdvicePanelState
    {
        ScoreList,
        RythmPage,
        zRotationPage,
        yRotationPage,
        ForearmPage
    }

    /// <summary>
    /// アドバイスの表示を管理する
    /// </summary>
    public class AdviceManager : MonoBehaviour
    {
        [SerializeField] private GameObject scoreList;
        [SerializeField] private GameObject advicePanel;
        [SerializeField] private TextMeshProUGUI rythmScoreText;
        [SerializeField] private TextMeshProUGUI zScoreText;
        [SerializeField] private TextMeshProUGUI yScoreText;
        [SerializeField] private TextMeshProUGUI forearmScoreText;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI adviceText;

        private string rythmAdvice;
        private string yRotationAdvice;
        private string zRotationAdvice;
        private string forearmAdvice;
        private AdvicePanelState state;

        public void InitializeAdvicePanel()
        {
            scoreList.SetActive(true);
            advicePanel.SetActive(false);
            state = AdvicePanelState.ScoreList;
        }

        public void OpenRythmAdvice()
        {
            scoreList.SetActive(false);
            advicePanel.SetActive(true);
            scoreText.text = "リズム：" + rythmScoreText.text;
            adviceText.text = rythmAdvice;
            state = AdvicePanelState.RythmPage;
        }

        public void OpenzRotationAdvice()
        {
            scoreList.SetActive(false);
            advicePanel.SetActive(true);
            scoreText.text = "手首のひねり：" + zScoreText.text;
            adviceText.text = zRotationAdvice;
            state = AdvicePanelState.zRotationPage;
        }

        public void OpenyRotationAdvice()
        {
            scoreList.SetActive(false);
            advicePanel.SetActive(true);
            scoreText.text = "手首の振り：" + yScoreText.text;
            adviceText.text = yRotationAdvice;
            state = AdvicePanelState.yRotationPage;
        }

        public void OpenForearmAdvice()
        {
            scoreList.SetActive(false);
            advicePanel.SetActive(true);
            scoreText.text = "前腕の振り：" + forearmScoreText.text;
            adviceText.text = forearmAdvice;
            state = AdvicePanelState.ForearmPage;
        }

        public void Back()
        {
            if (state != AdvicePanelState.ScoreList)
            {
                scoreList.SetActive(true);
                advicePanel.SetActive(false);
                state = AdvicePanelState.ScoreList;
            }
        }

        public void SetAdviceAndScore(float rythmScore, float zScore, float yScore, float forearmScore)
        {
            // リズムのアドバイスを決定
            switch (rythmScore)
            {
                case 0:
                    rythmScoreText.text = "悪い";
                    rythmAdvice = "リズムが大きくずれてしまっています。\nまずは、ストロークパターンを覚えるところから始めましょう。";
                    break;

                case 1:
                    rythmScoreText.text = "普通";
                    rythmAdvice = "リズムが少しずれてしまっています。\nメトロノームの音をしっかり聞きながら、\nリズムを合わせるようにしましょう。";
                    break;

                case 2:
                    rythmScoreText.text = "良い";
                    rythmAdvice = "一定のリズムでストロークができています。その調子です！";
                    break;
            }

            // 手首のz軸回転のアドバイスを決定
            switch (zScore)
            {
                case 0:
                    zScoreText.text = "悪い";
                    zRotationAdvice = "手首のひねり方が良くありません。\n手首のひねりが大きすぎると、速いリズムに対応できなくなるので、大きくひねりすぎないようにしましょう。";
                    break;

                case 1:
                    zScoreText.text = "普通";
                    zRotationAdvice = "手首のひねりはまずまずですが、まだ改善できます。\n手首をひねって弦を弾くのではなく、手首の振りで弦を弾くことを意識しましょう。";
                    break;

                case 2:
                    zScoreText.text = "良い";
                    zRotationAdvice = "うまく手首のひねりを使えています。その調子です！";
                    break;
            }

            // 手首のy軸回転のアドバイスを決定
            switch (yScore)
            {
                case 0:
                    yScoreText.text = "悪い";
                    yRotationAdvice = "手首がうまく振れていません。\n腕を振って弦を弾くのではなく、手首のスナップを使って弦を弾くようにしましょう。";
                    break;

                case 1:
                    yScoreText.text = "普通";
                    yRotationAdvice = "手首の振りはまずまずですが、まだ改善できます。\n手首のスナップを使って素早く振るようにしてみましょう。";
                    break;

                case 2:
                    yScoreText.text = "良い";
                    yRotationAdvice = "うまく手首を振れています。その調子です！";
                    break;
            }

            // 前腕のアドバイスを決定
            switch (forearmScore)
            {
                case 0:
                    forearmScoreText.text = "悪い";
                    forearmAdvice = "前腕の振りがよくありません。\n前腕の振りが大きすぎると、リズムが速くなった時に対応できなくなるため、コンパクトに振ることが重要です。";
                    break;

                case 1:
                    forearmScoreText.text = "普通";
                    forearmAdvice = "前腕の振りはまずまずですが、まだ改善できます。\n前腕の振りで弦を弾くのではなく、手首の振りで弦を弾くことを意識しましょう。";
                    break;

                case 2:
                    forearmScoreText.text = "良い";
                    forearmAdvice = "うまく前腕を振ることができています。その調子です！";
                    break;
            }
        }
    }
}

