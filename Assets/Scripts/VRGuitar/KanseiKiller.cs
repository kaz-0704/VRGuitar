using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanseiKiller : MonoBehaviour
{

    public float speed;
    private Rigidbody rigid; //�ǉ�

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();  //�ǉ�
    }

    // Update is called once per frame
    void Update()
    {
        //�ϐ��ύX
        rigid.AddForce(transform.right * Input.GetAxisRaw("Horizontal") * speed, ForceMode.VelocityChange);
    }

    //�~�߂������ɌĂяo��
    public void Stop()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

}