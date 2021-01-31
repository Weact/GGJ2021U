using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cp_house_exit : MonoBehaviour
{
    
    private AudioSource heartbeat_slow;
    public AudioClip heartbeatslow_clip;

    [SerializeField]
    private GameObject gamemusicmanager;
    [SerializeField]
    private AudioClip forestmusic;

    private bool forestmusichasstarted = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            heartbeat_slow = other.gameObject.GetComponent<AudioSource>();
            heartbeat_slow.clip = heartbeatslow_clip;
            if (!heartbeat_slow.isPlaying)
            {
                heartbeat_slow.Play();
            }

            other.gameObject.GetComponent<SC_FPSController>().walkingSpeed = 2.0f;
            other.gameObject.GetComponent<SC_FPSController>().runningSpeed = 3.0f;

            if (!forestmusichasstarted)
            {
                gamemusicmanager.GetComponent<AudioSource>().Stop();
                gamemusicmanager.GetComponent<AudioSource>().clip = forestmusic;
                gamemusicmanager.GetComponent<AudioSource>().Play();
                forestmusichasstarted = true;
            }
            
            
        }
    }
}
