using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public GameObject target;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log(Player.transform.position);
            Player.transform.position = target.transform.position;
            Debug.Log(Player.transform.position);
        }
    }
}
