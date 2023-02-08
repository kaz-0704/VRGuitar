using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// UI‚Ìƒpƒlƒ‹‚ğPlayer‚Ì‹ü‚É‡‚í‚¹‚Ä‰ñ“]‚³‚¹‚é.
/// </summary>
public class FocusPlayer : MonoBehaviour
{
    public Transform player;
    private List<Transform> buffa = new List<Transform>();

    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(player);
        transform.Rotate(0, 180, 0);
    }
}
