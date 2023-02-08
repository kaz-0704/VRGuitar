using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

namespace VRGuitar
{
    public class DataSend : MonoBehaviour
    {
        private const string url = "http://localhost:5000/";
        string jsonpath = $"C:/Users/xr/Documents/Oiwa/VRGuitar/Assets/Scripts/VRGuitar/PythonScripts/tracker_data.json";
        string json;

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
                }
            }
        }
    }
}
