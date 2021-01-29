using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public GameObject target;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log(Player.transform.position);
            Player.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
            Debug.Log(Player.transform.position);
        }
    }
}
