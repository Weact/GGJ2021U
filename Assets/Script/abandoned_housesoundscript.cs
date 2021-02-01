using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abandoned_housesoundscript : MonoBehaviour
{
    private AudioSource abandonedsound;

    // Start is called before the first frame update
    void Start()
    {
        abandonedsound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            abandonedsound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            abandonedsound.Stop();
        }
    }
}
