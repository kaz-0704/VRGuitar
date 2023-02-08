using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RayController : MonoBehaviour
{
    [SerializeField] GameObject vrCamera;
    [SerializeField] GameObject helpCanvas;
    [SerializeField] GameObject helpText;

    private TextMeshProUGUI text;
    private float maxDistance = 100;

    // Start is called before the first frame update
    void Start()
    {
        helpCanvas.SetActive(false);
        text = helpText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(vrCamera.transform.position, vrCamera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 0.5f);

        if(Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.collider.gameObject.tag == "ヘルプ表示対象")
            {
                Debug.Log(hit.collider.gameObject.name);
                helpCanvas.SetActive(true);
                helpCanvas.transform.position = hit.collider.gameObject.transform.position + new Vector3(-0.05f, -0.15f, -0.1f);
                switch (hit.collider.gameObject.name)
                {
                    case "EvalButton":
                        text.text = "ストロークの評価を行います。";
                        break;
                    case "HistoryButton":
                        text.text = "これまでの演奏の記録を閲覧します。";
                        break;
                    case "EvalStartButton":
                        text.text = "ストロークの評価を開始します。\n" +
                            "４回のプリカウントに続けて演奏を始めてください。";
                        break;
                }
            }
            else
            {
                helpCanvas.SetActive(false);
            }
        }
    }
}
