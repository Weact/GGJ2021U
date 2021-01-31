using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [SerializeField]
    AudioSource toggle;

    private bool canInteract = false;
    [SerializeField]
    private GameObject Lumieres = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            Allumer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canInteract = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canInteract = false;
    }

    private void Allumer()
    {
        if (Lumieres != null)
        {
            if(toggle != null)
            {
                toggle.Play();
            }
            Lumieres.SetActive(!Lumieres.activeSelf);
        }
    }
}
