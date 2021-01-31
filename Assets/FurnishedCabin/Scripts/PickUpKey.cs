using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    AudioSource pickupitem;

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
            if(pickupitem != null)
            {
                pickupitem.Play();
            }
            if(target.GetComponent<Lock>() != null)
            {
                target.GetComponent<Lock>().keysCollected++;
                target.GetComponent<Lock>().tryToOpenDoor();
            }
            if (target.GetComponent<cp_exit_garden>() != null)
            {
                target.GetComponent<cp_exit_garden>().currentCollectedItems++;
                target.GetComponent<cp_exit_garden>().tryToOpenGate();
            }
            
            Destroy(gameObject);
        }
    }
}
