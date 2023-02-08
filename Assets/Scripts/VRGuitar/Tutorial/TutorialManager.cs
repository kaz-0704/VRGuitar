using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameMainSystem mainSystem;
    [SerializeField] private TextController textController;
    [SerializeField] private GameObject pointer;
    [SerializeField] private GameObject tutorialButton;
    [SerializeField] private GameObject nextButton;
    private TutorialState state;
    private string[] initialSentences;
    private string[] pointerSentences;
    private string[] menuSentences;
    private string[] howToPlaySentences;
    private string[] playingSentences;

    /// <summary>
    /// �`���[�g���A�����̏��
    /// </summary>
    public enum TutorialState
    {
        Begining,
        PointerIntroduction,
        PlayingIntroduction,
    }

    private void Start()
    {
        nextButton.SetActive(false);

        initialSentences = new string[]
        {
            "VR�G�A�M�^�[���b�X���ւ悤�����I",
            "�����ł́A�V�X�e���̎g�������w��ł��炢�܂��B",
        };

        pointerSentences = new string[]
        {
            "�͂��߂ɁA���[�U�[�|�C���^�̑�����@�ɂ��Đ������܂��B",

            "�܂��́A���[�U�[�|�C���^���o���Ă݂܂��傤�B",
            "�E��ň��肱�Ԃ������A���̏�Ԃ��L�[�v���Ă��������B",
            "�����ł��ˁI",
            "���̂Ƃ��A�����Ƀ��j���[��ʂ��J����܂��B",
            "���[�U�[�|�C���^�́A��{�I�ɐe�w�𗧂Ă���Ԃœ������܂��B",
            "������x���肱�Ԃ��̃|�[�Y���L�[�v���邱�ƂŁA�|�C���^���������Ƃ��ł��܂��B",

            "���́A���[�U�[�|�C���^���g���ă��j���[��ʂ̃{�^���������Ă݂܂��傤�B",
            "�|�C���^���{�^���ɓ��Ă�ƁA�{�^���̐F���ς��܂��B",
            "���̏�ԂŁA���ĂĂ���e�w��|���Ă݂܂��傤�B",
            "����Ń{�^�����������Ƃ��ł��܂����I",
            "���ꂩ��܂��`���[�g���A���������܂����A�킩���Ă��镔����"
        };

        menuSentences = new string[]
        {

        };

        howToPlaySentences = new string[]
        {
            "�ł͂��悢��A�M�^�[�̉��t���@�ɓ����Ă����܂��傤�B",

            "�܂��A�M�^�[�������̍D���Ȉʒu�Ɉړ������܂��B",
            "���j���[��ʂ��J���A'�M�^�[�ʒu�ύX'���N���b�N���܂��B",
            "����ɂ��A�M�^�[�𓮂�����悤�ɂȂ�܂��B",
            "����̐e�w�Ɛl�����w�ŃM�^�[���܂ނ悤�ɂ���ƁA�M�^�[�������Ƃ��ł��܂��B",
            "���̂܂܃M�^�[�������̉��t���₷���ʒu�Ɉړ������܂��傤�B",
            "�M�^�[�̃l�b�N�ƃ{�f�B�̂Ȃ��ڂ̕�����̂̐^���ʂɎ����Ă���ƁA�Ђ��₷���Ȃ�Ǝv���܂��B",
            "�ʒu�����܂�����A���j���[��ʂ�'�ʒu����'���N���b�N���ăM�^�[���Œ肵�܂��B",

            "���ɁA���̖炵���ɂ��Đ������܂��B",
            "�M�^�[�̃l�b�N�̕���������ƁA�J���t���ȉ~���ɃA���t�@�x�b�g�������ꂽ���̂�����ł���Ǝv���܂��B",
            "�����̃A���t�@�x�b�g�́A�M�^�[�̃R�[�h��\���Ă��܂��B\n" +
            "�i�R�[�h�͘a���Ƃ��Ă΂�܂��B�j",
            "�R�[�h�Ƃ́A���a���鉹�̑g�ݍ��킹�̂��Ƃł��B",
            "�قȂ�R�[�h��e���A�˂邱�ƂŁA�y�Ȃ͍��o����Ă��܂��B",
            "�܂��́A�炷�R�[�h���w�肵�܂��B",
            "�~���ɍ���ŐG���ƁA�G�ꂽ�R�[�h�̃A���t�@�x�b�g���傫���Ȃ�܂��B",
            "���̏�Ԃō���̐e�w���Ȃ���ƁA�~���̐F���ЂƂ����ς��܂��B",
            "���ꂪ�A�R�[�h��I���ł��Ă����Ԃł��B",
            "�����ŁA�E��ŃM�^�[�̃{�f�B�̌��̊J���������̌����͂����Ă݂܂��傤�B",
            "������܂����ˁI",
            "����ŃR�[�h���w�肵�A�E��ŉ���炷�A���ꂪ�M�^�[�̊�{�I�ȓ����ł��B",
            "���ۂ̃M�^�[�ł́A����̎w�Ō���}���邱�ƂŁA�R�[�h���w�肵�܂��B",
        };

        StartCoroutine(StartTutorial());
    }

    public IEnumerator StartTutorial()
    {
        //*************************
        //   �`���[�g���A���`��
        //*************************
        // �܂��|�C���^�𑀍�ł��Ȃ����߁A�e�L�X�g�������Ő؂�ւ��B
        state = TutorialState.Begining;
        textController.SetSenteces(initialSentences);

        for (int i = 0; i <= initialSentences.Length; i++)
        {
            mainSystem.PushText();
            yield return new WaitForSeconds(3.0f);
        }

        //*************************
        // �|�C���^�̎g�����̐���
        //*************************
        //state = TutorialState.PointerIntroduction;
        //textController.SetSenteces(pointerSentences);

        //for (int i = 0; i < 3; i++)
        //{
        //    mainSystem.PushText();
        //    yield return new WaitForSeconds(3.0f);
        //}
        //// �|�C���^���o�����玟�֐i��
        //while (true)
        //{
        //    if (pointer.activeSelf)
        //    {
        //        break;
        //    }
        //    yield return null;
        //}
        //for (int i = 0; i <= 6; i++)
        //{
        //    mainSystem.PushText();
        //    yield return new WaitForSeconds(3.0f);
        //}
        //tutorialButton.SetActive(true);
        //Button button = tutorialButton.GetComponent<Button>();
        //// �{�^�����������玟�֐i��
        //while (true)
        //{
        //    if (button.onClick != null)
        //    {
        //        break;
        //    }
        //    yield return null;
        //}
        //for (int i = 0; i <= 1; i++)
        //{
        //    mainSystem.PushText();
        //    yield return new WaitForSeconds(3.0f);
        //}


        //*************************
        // �@���t���@�̐���
        //*************************
        textController.SetSenteces(howToPlaySentences);
        mainSystem.PushText();
        yield return new WaitForSeconds(2.0f);
        nextButton.SetActive(true);

        yield return null;
    }
}
