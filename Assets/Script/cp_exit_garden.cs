using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cp_exit_garden : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private BoxCollider colliderteleporttrigger;
    [SerializeField]
    private GameObject fencegate;

    public int requiredNumbersOfItems;
    public int currentCollectedItems;

    [SerializeField]
    private AudioSource unlockedGateSound;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(fencegate != null)
        {
            if (Input.GetButton("R"))
            {
                Destroy(fencegate);
                colliderteleporttrigger.enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.GetComponent<SC_FPSController>().walkingSpeed = 3.0f;
            player.GetComponent<SC_FPSController>().runningSpeed = 4.0f;
        }
    }

    public void tryToOpenGate()
    {
        if(currentCollectedItems == requiredNumbersOfItems)
        {
            openGate();
        }
    }

    private void openGate()
    {
        Destroy(fencegate);
        colliderteleporttrigger.enabled = true;
        unlockedGateSound.Play();
    }

}
