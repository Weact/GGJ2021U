﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public int requiredKeys;
    public int keysCollected = 0;
    [SerializeField]
    AudioSource allkeyscollected;

    public bool lockdoor = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tryToOpenDoor()
    {
        if (keysCollected == requiredKeys)
        {
            if (allkeyscollected != null)
            {
                allkeyscollected.Play();
            }
            lockdoor = false;
        }
    }
}
