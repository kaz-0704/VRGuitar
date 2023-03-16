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
    /// �A�h�o�C�X�̕\�����Ǘ�����
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
            scoreText.text = "���Y���F" + rythmScoreText.text;
            adviceText.text = rythmAdvice;
            state = AdvicePanelState.RythmPage;
        }

        public void OpenzRotationAdvice()
        {
            scoreList.SetActive(false);
            advicePanel.SetActive(true);
            scoreText.text = "���̂Ђ˂�F" + zScoreText.text;
            adviceText.text = zRotationAdvice;
            state = AdvicePanelState.zRotationPage;
        }

        public void OpenyRotationAdvice()
        {
            scoreList.SetActive(false);
            advicePanel.SetActive(true);
            scoreText.text = "���̐U��F" + yScoreText.text;
            adviceText.text = yRotationAdvice;
            state = AdvicePanelState.yRotationPage;
        }

        public void OpenForearmAdvice()
        {
            scoreList.SetActive(false);
            advicePanel.SetActive(true);
            scoreText.text = "�O�r�̐U��F" + forearmScoreText.text;
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
            // ���Y���̃A�h�o�C�X������
            switch (rythmScore)
            {
                case 0:
                    rythmScoreText.text = "����";
                    rythmAdvice = "���Y�����傫������Ă��܂��Ă��܂��B\n�܂��́A�X�g���[�N�p�^�[�����o����Ƃ��납��n�߂܂��傤�B";
                    break;

                case 1:
                    rythmScoreText.text = "����";
                    rythmAdvice = "���Y������������Ă��܂��Ă��܂��B\n���g���m�[���̉����������蕷���Ȃ���A\n���Y�������킹��悤�ɂ��܂��傤�B";
                    break;

                case 2:
                    rythmScoreText.text = "�ǂ�";
                    rythmAdvice = "���̃��Y���ŃX�g���[�N���ł��Ă��܂��B���̒��q�ł��I";
                    break;
            }

            // ����z����]�̃A�h�o�C�X������
            switch (zScore)
            {
                case 0:
                    zScoreText.text = "����";
                    zRotationAdvice = "���̂Ђ˂�����ǂ�����܂���B\n���̂Ђ˂肪�傫������ƁA�������Y���ɑΉ��ł��Ȃ��Ȃ�̂ŁA�傫���Ђ˂肷���Ȃ��悤�ɂ��܂��傤�B";
                    break;

                case 1:
                    zScoreText.text = "����";
                    zRotationAdvice = "���̂Ђ˂�͂܂��܂��ł����A�܂����P�ł��܂��B\n�����Ђ˂��Č���e���̂ł͂Ȃ��A���̐U��Ō���e�����Ƃ��ӎ����܂��傤�B";
                    break;

                case 2:
                    zScoreText.text = "�ǂ�";
                    zRotationAdvice = "���܂����̂Ђ˂���g���Ă��܂��B���̒��q�ł��I";
                    break;
            }

            // ����y����]�̃A�h�o�C�X������
            switch (yScore)
            {
                case 0:
                    yScoreText.text = "����";
                    yRotationAdvice = "��񂪂��܂��U��Ă��܂���B\n�r��U���Č���e���̂ł͂Ȃ��A���̃X�i�b�v���g���Č���e���悤�ɂ��܂��傤�B";
                    break;

                case 1:
                    yScoreText.text = "����";
                    yRotationAdvice = "���̐U��͂܂��܂��ł����A�܂����P�ł��܂��B\n���̃X�i�b�v���g���đf�����U��悤�ɂ��Ă݂܂��傤�B";
                    break;

                case 2:
                    yScoreText.text = "�ǂ�";
                    yRotationAdvice = "���܂�����U��Ă��܂��B���̒��q�ł��I";
                    break;
            }

            // �O�r�̃A�h�o�C�X������
            switch (forearmScore)
            {
                case 0:
                    forearmScoreText.text = "����";
                    forearmAdvice = "�O�r�̐U�肪�悭����܂���B\n�O�r�̐U�肪�傫������ƁA���Y���������Ȃ������ɑΉ��ł��Ȃ��Ȃ邽�߁A�R���p�N�g�ɐU�邱�Ƃ��d�v�ł��B";
                    break;

                case 1:
                    forearmScoreText.text = "����";
                    forearmAdvice = "�O�r�̐U��͂܂��܂��ł����A�܂����P�ł��܂��B\n�O�r�̐U��Ō���e���̂ł͂Ȃ��A���̐U��Ō���e�����Ƃ��ӎ����܂��傤�B";
                    break;

                case 2:
                    forearmScoreText.text = "�ǂ�";
                    forearmAdvice = "���܂��O�r��U�邱�Ƃ��ł��Ă��܂��B���̒��q�ł��I";
                    break;
            }
        }
    }
}

