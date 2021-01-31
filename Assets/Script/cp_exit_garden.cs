using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cp_exit_garden : MonoBehaviour
{
    [SerializeField]
    private BoxCollider colliderteleporttrigger;

    // Start is called before the first frame update
    void Start()
    {
        colliderteleporttrigger.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
