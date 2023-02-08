using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace VRGuitar
{
    /// <summary>
    /// �A�h�o�C�X�̕\�����Ǘ�����
    /// </summary>
    public class AdviceManager : MonoBehaviour
    {
        [SerializeField] private GameObject advicePanel1;
        [SerializeField] private GameObject advicePanel2;
        [SerializeField] private GameObject advicePanel3;
        [SerializeField] private GameObject advicePanel4;
        [SerializeField] private TextMeshProUGUI adviceText1;
        [SerializeField] private TextMeshProUGUI adviceText2;
        [SerializeField] private TextMeshProUGUI adviceText3;
        [SerializeField] private TextMeshProUGUI adviceText4;

        private string rythmAdvice;
        private string yRotationAdvice;
        private string zRotationAdvice;
        private string ForearmAdvice;

        public void InitializeAdvicePanel()
        {
            advicePanel1.SetActive(false);
            advicePanel2.SetActive(false);
            advicePanel3.SetActive(false);
            advicePanel4.SetActive(false);
        }

        public void OpenAdvice(int item)
        {
            switch (item)
            {
                case 0:
                    advicePanel1.SetActive(true);
                    advicePanel2.SetActive(false);
                    advicePanel3.SetActive(false);
                    advicePanel4.SetActive(false);
                    adviceText1.text = rythmAdvice;
                    break;
                case 1:
                    advicePanel1.SetActive(false);
                    advicePanel2.SetActive(true);
                    advicePanel3.SetActive(false);
                    advicePanel4.SetActive(false);
                    adviceText2.text = zRotationAdvice;
                    break;
                case 2:
                    advicePanel1.SetActive(false);
                    advicePanel2.SetActive(false);
                    advicePanel3.SetActive(true);
                    advicePanel4.SetActive(false);
                    adviceText3.text = yRotationAdvice;
                    break;
                case 3:
                    advicePanel1.SetActive(false);
                    advicePanel2.SetActive(false);
                    advicePanel3.SetActive(false);
                    advicePanel4.SetActive(true);
                    adviceText4.text = ForearmAdvice;
                    break;
            }
        }

        public void MakeAdvice(float rythmScore, float zScore, float yScore, float ForearmScore)
        {
            // ���Y���̃A�h�o�C�X������
            if (rythmScore < 1.5)
            {
                rythmAdvice = "���Y���ւ̃A�h�o�C�X�P\n" +
                    "���Y�����傫������Ă��܂��Ă��܂��B�܂��́A�X�g���[�N�p�^�[�����o����Ƃ��납��n�߂܂��傤�B";
            }
            else  if (rythmScore < 2.5)
            {
                rythmAdvice = "���Y���ւ̃A�h�o�C�X�Q\n" +
                    "���Y�����傫������Ă��܂��Ă��܂��B��s�b�L���O���ӎ����Ȃ���X�g���[�N���s���܂��傤�B";
            }
            else if (rythmScore < 3.5)
            {
                rythmAdvice = "���Y���ւ̃A�h�o�C�X�R\n" +
                    "���Y������������Ă��܂��Ă��܂��B��s�b�L���O���ӎ����Ȃ���X�g���[�N���s���܂��傤�B";
            }
            else if (rythmScore < 4.5)
            {
                rythmAdvice = "���Y���ւ̃A�h�o�C�X�S\n" +
                    "�ɂ����ł��ˁB�����������Y��������Ă��܂��Ă��܂��B\n" +
                    "���g���m�[���̉��������ƕ����A���t�̍Ō�܂ł��̃��Y�������ɕۂ悤�Ɉӎ����܂��傤�B";
            }
            else
            {
                rythmAdvice = "���Y���ւ̃A�h�o�C�X�T\n" +
                    "���ꂢ�ȃ��Y���ŉ��t���ł��Ă��܂��B���̒��q�ł��I";
            }

            // ����y����]�̃A�h�o�C�X������
            if (yScore < 1.5)
            {
                yRotationAdvice = "���y���̃A�h�o�C�X�P";
            }
            else if (yScore < 2.5)
            {
                yRotationAdvice = "���y���̃A�h�o�C�X�Q";
            }
            else if (yScore < 3.5)
            {
                yRotationAdvice = "���y���̃A�h�o�C�X�R";
            }
            else if (yScore < 4.5)
            {
                yRotationAdvice = "���y���̃A�h�o�C�X�S";
            }
            else
            {
                yRotationAdvice = "���y���̃A�h�o�C�X�T";
            }

            // ����z����]�̃A�h�o�C�X������
            if (zScore < 1.5)
            {
                zRotationAdvice = "���z���̃A�h�o�C�X�P";
            }
            else if (zScore < 2.5)
            {
                zRotationAdvice = "���z���̃A�h�o�C�X�Q";
            }
            else if (zScore < 3.5)
            {
                zRotationAdvice = "���z���̃A�h�o�C�X�R";
            }
            else if (zScore < 4.5)
            {
                zRotationAdvice = "���z���̃A�h�o�C�X�S";
            }
            else
            {
                zRotationAdvice = "���z���̃A�h�o�C�X�T";
            }

            // �O�r�̃A�h�o�C�X������
            if (ForearmScore < 1.5)
            {
                ForearmAdvice = "�O�r�̃A�h�o�C�X�P\n" +
                    "�O�r�̐U�肪�傫�����܂��B�r�̓R���p�N�g�ɐU��悤�ɐS�����܂��傤�B";
            }
            else if (ForearmScore < 2.5)
            {
                ForearmAdvice = "�O�r�̃A�h�o�C�X�Q\n" +
                    "�O�r�̐U�肪�傫���Ȃ��Ă��܂��B�r�̓R���p�N�g�ɐU��悤�ɐS�����܂��傤�B";
            }
            else if (ForearmScore < 3.5)
            {
                ForearmAdvice = "�O�r�̃A�h�o�C�X�R\n" +
                    "�O�r�̐U�肪�����傫���Ȃ��Ă��܂��B�r�͂��������R���p�N�g�ɐU��悤�ɐS�����܂��傤�B";
            }
            else if (ForearmScore < 4.5)
            {
                ForearmAdvice = "�O�r�̃A�h�o�C�X�S\n" +
                    "�O�r�̐U�肪�����傫���Ȃ��Ă��܂��B�r�͂��������R���p�N�g�ɐU��悤�ɐS�����܂��傤�B";
            }
            else
            {
                ForearmAdvice = "�O�r�̃A�h�o�C�X�T\n" +
                    "�O�r�R���p�N�g�ɐU�邱�Ƃ��ł��Ă��܂��ˁB���̒��q�ł��I";
            }
        }
    }
}

