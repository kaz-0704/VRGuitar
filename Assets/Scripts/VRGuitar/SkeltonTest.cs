using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SkeltonTest : MonoBehaviour
{
    public SteamVR_Action_Skeleton skeletonAction;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (skeletonAction.thumbCurl > 0.5)
        {
            Debug.Log("THUMB");
        }
        if (skeletonAction.indexCurl > 0.5)
        {
            Debug.Log("INDEX");
        }
        if (skeletonAction.middleCurl > 0.5)
        {
            Debug.Log("MIDDLE");
        }
        if (skeletonAction.ringCurl > 0.5)
        {
            Debug.Log("RING");
        }
        if (skeletonAction.pinkyCurl > 0.5)
        {
            Debug.Log("PINKY");
        }
    }
}
