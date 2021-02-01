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
        Debug.Log(other);
        if(other.tag == "Player")
        {
            if(Dudule != null)
            {
                diff = Player.transform.position - Dudule.position;
            }

           // Debug.Log(Player.transform.position);
           Player.transform.position = target.transform.position;
            // Debug.Log(Player.transform.position);

            if (Dudule != null)
            {
                Dudule.position = target.transform.position + diff;

                if(scriptDudule != null)
                {
                    scriptDudule.Dificulty = 30f;
                }
            }
        }
    }
}
