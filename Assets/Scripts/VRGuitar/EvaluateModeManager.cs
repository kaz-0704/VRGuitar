using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using TMPro;

namespace VRGuitar
{
    /// <summary>
    /// ���t�]���̂��߂̈�A�̏������s��
    /// �g���b�L���O �� �T�[�o�[�Ƀf�[�^���M �� �T�[�o�[���琄�_���ʎ擾
    /// </summary>
    public class EvaluateModeManager : MonoBehaviour
    {
        public bool eval_mode = false;
        public Metronome metronome;
        public JsonWriter jsonWriter;
        public TextMeshProUGUI resultText;
        public ChartScript chartScript;
        public MenuManager menuManager;
        public AdviceManager adviceManager;

        private const string url = "http://localhost:5000/";
        string jsonpath = $"C:/Users/xr/Documents/Oiwa/VRGuitar/Assets/Scripts/VRGuitar/PythonScripts/tracker_data.json";
        string json;

        public void StartEvaluating()
        {
            Debug.Log("StartRecording");
            eval_mode = true;
            jsonWriter.GetReadyWriting();
            metronome.OnMetronome();
        }

        public void StopRecording()
        {
            Debug.Log("StopRecording");
            eval_mode = false;
            metronome.OffMetronome();

            resultText.text = "���t��]�����Ă��܂�...";
            SendData();
        }

        public void SendData()
        {
            json = File.ReadAllText(jsonpath);
            //�R���[�`�����Ăяo��
            StartCoroutine(GetRequest(url, json));
        }

        IEnumerator GetRequest(string url, string tracker_data)
        {
            List<IMultipartFormSection> data = new List<IMultipartFormSection>();
            data.Add(new MultipartFormDataSection(tracker_data));

            using (UnityWebRequest webRequest = UnityWebRequest.Post(url, data))
            {
                //URL�ɐڑ����Č��ʂ��߂��Ă���܂őҋ@
                yield return webRequest.SendWebRequest();

                //�G���[���o�Ă��Ȃ����`�F�b�N
                if (webRequest.isNetworkError)
                {
                    //�ʐM���s
                    Debug.Log(webRequest.error);
                }
                else
                {
                    //�ʐM����
                    Debug.Log(webRequest.downloadHandler.text);
                    string[] scoreList = webRequest.downloadHandler.text.Split(',');
                    float rythmScore = float.Parse(scoreList[0]);
                    float zScore = float.Parse(scoreList[1]);
                    float yScore = float.Parse(scoreList[2]);
                    float forearmScore = float.Parse(scoreList[3]);
                    //JObject jsonData = JObject.Parse(webRequest.downloadHandler.text);
                    //int rythmScore = (int)jsonData["Rythm_Score"];
                    //int zScore = (int)jsonData["zRotation_Score"];
                    //int yScore = (int)jsonData["yRotation_Score"];
                    //int forearmScore = (int)jsonData["Forarm_Score"];
                    //resultText.text = $"���Y���F{rythmScore}\n" +
                    //    $"���̂�����]�F{zScore}\n" +
                    //    $"���̂�����]�F{yScore}\n" +
                    //    $"�O�r�F{forearmScore}";
                    chartScript.ScoreSet(rythmScore, zScore, yScore, forearmScore);
                    menuManager.OpenRadarChart();
                    //adviceManager.MakeAdvice(rythmScore, zScore, yScore, forearmScore);
                }
            }
        }
    }
}

