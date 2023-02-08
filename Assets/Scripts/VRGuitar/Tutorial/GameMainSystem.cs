using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMainSystem : MonoBehaviour
{
    [SerializeField] TextController textController;
    [SerializeField] Camera playerCamera;
    [SerializeField] [Range(1.0f, 3.0f)] float panelDistance = 2.0f;
    bool IsTextPush = false;

    private void Start()
    {
        gameObject.transform.position = new Vector3(playerCamera.transform.position.x, 0.8f, panelDistance);
    }

    void Update(){
        if(textController.finished){
            textController.finished = false;
            return;
        }
        textController.TextUpdate(IsTextPush);
        IsTextPush = false;
    }
    public void PushText(){
        IsTextPush = true;
    }
}