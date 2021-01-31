using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sortirreve : MonoBehaviour
{

    private AudioSource sortirrevesound;

    // Start is called before the first frame update
    void Start()
    {
        sortirrevesound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            sortirrevesound.Play();
        }

        Destroy(gameObject, sortirrevesound.clip.length);
    }
}
