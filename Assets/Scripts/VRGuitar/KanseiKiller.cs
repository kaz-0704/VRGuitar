using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanseiKiller : MonoBehaviour
{

    public float speed;
    private Rigidbody rigid; //追加

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();  //追加
    }

    // Update is called once per frame
    void Update()
    {
        //変数変更
        rigid.AddForce(transform.right * Input.GetAxisRaw("Horizontal") * speed, ForceMode.VelocityChange);
    }

    //止めたい時に呼び出し
    public void Stop()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

}