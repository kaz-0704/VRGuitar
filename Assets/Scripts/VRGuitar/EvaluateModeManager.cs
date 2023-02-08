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
    /// 演奏評価のための一連の処理を行う
    /// トラッキング → サーバーにデータ送信 → サーバーから推論結果取得
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

            resultText.text = "演奏を評価しています...";
            SendData();
        }

        public void SendData()
        {
            json = File.ReadAllText(jsonpath);
            //コルーチンを呼び出す
            StartCoroutine(GetRequest(url, json));
        }

        IEnumerator GetRequest(string url, string tracker_data)
        {
            List<IMultipartFormSection> data = new List<IMultipartFormSection>();
            data.Add(new MultipartFormDataSection(tracker_data));

            using (UnityWebRequest webRequest = UnityWebRequest.Post(url, data))
            {
                //URLに接続して結果が戻ってくるまで待機
                yield return webRequest.SendWebRequest();

                //エラーが出ていないかチェック
                if (webRequest.isNetworkError)
                {
                    //通信失敗
                    Debug.Log(webRequest.error);
                }
                else
                {
                    //通信成功
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
                    //resultText.text = $"リズム：{rythmScore}\n" +
                    //    $"手首のｚ軸回転：{zScore}\n" +
                    //    $"手首のｙ軸回転：{yScore}\n" +
                    //    $"前腕：{forearmScore}";
                    chartScript.ScoreSet(rythmScore, zScore, yScore, forearmScore);
                    menuManager.OpenRadarChart();
                    //adviceManager.MakeAdvice(rythmScore, zScore, yScore, forearmScore);
                }
            }
        }
    }
}

