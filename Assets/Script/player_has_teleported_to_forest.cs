using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_has_teleported_to_forest : MonoBehaviour
{

    public AudioSource runlittlegirl;
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
        if(other.tag == "Player")
        {
            runlittlegirl.Play();
            Destroy(gameObject, runlittlegirl.clip.length);
        }
    }
}
