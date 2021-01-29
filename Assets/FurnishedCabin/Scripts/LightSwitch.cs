using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
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
            Lumieres.SetActive(!Lumieres.activeSelf);
        }
    }
}
