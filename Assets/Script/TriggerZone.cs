using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public GameObject target;
    public GameObject Player;
    public Transform Dudule;

    EntityScript scriptDudule;

    Vector3 diff;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            diff = Player.transform.position - Dudule.position;

           // Debug.Log(Player.transform.position);
           Player.transform.position = target.transform.position;
            // Debug.Log(Player.transform.position);

            Dudule.position = target.transform.position + diff;

            scriptDudule.Dificulty = 30f;

        }
    }
}
