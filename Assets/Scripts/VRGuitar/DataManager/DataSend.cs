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
                }
            }
        }
    }
}
