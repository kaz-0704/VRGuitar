using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanseiKiller : MonoBehaviour
{

    public float speed;
    private Rigidbody rigid; //’Ç‰Á

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();  //’Ç‰Á
    }

    // Update is called once per frame
    void Update()
    {
        //•Ï”•ÏX
        rigid.AddForce(transform.right * Input.GetAxisRaw("Horizontal") * speed, ForceMode.VelocityChange);
    }

    //~‚ß‚½‚¢‚ÉŒÄ‚Ño‚µ
    public void Stop()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

}