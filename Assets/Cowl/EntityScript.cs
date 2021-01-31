using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityScript : MonoBehaviour
{
    public GameObject target;

    public Camera playerCamera;

    bool go;

    SC_FPSController playerScript;

    float timer = 0.0f;
    float timerDeath = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        go = true;

        playerScript = target.GetComponent<SC_FPSController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.transform.position.x < target.transform.position.x && go )
        {
            transform.position += Vector3.right * Time.deltaTime;
        }
        if (gameObject.transform.position.z < target.transform.position.z && go)
        {
            transform.position += Vector3.forward * Time.deltaTime;
        }
        if (gameObject.transform.position.y < target.transform.position.y && go)
        {
            transform.position += Vector3.up * Time.deltaTime;
        }

        if (gameObject.transform.position.x > target.transform.position.x && go)
        {
            transform.position += Vector3.left * Time.deltaTime;
        }
        if (gameObject.transform.position.z > target.transform.position.z && go)
        {
            transform.position += Vector3.back * Time.deltaTime;
        }
        if (gameObject.transform.position.y > target.transform.position.y && go)
        {
            transform.position += Vector3.down * Time.deltaTime;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            timerDeath = 0.0f;
            timer = 0.0f;
            playerScript.runningSpeed = 0.25f;
            playerScript.walkingSpeed = 0.25f;
            go = false;            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            timerDeath += Time.deltaTime;
            Debug.Log(timerDeath);

            if(GetComponent<Renderer>().IsVisibleFrom(playerCamera)) //if player see Dudule
            {
                timer += Time.deltaTime;

                if(timer >= 2f) //after 2sec be seen Dudule
                {
                    Vector3 posit = gameObject.transform.position; //tp DUdule
                    posit.x += 80;
                    gameObject.transform.position = posit;
                }
            }
            else
            {
                timer = 0.0f;
            }

            if (timerDeath >= 4f) //after 4 sec in range
            {
                SceneManager.LoadScene("Main"); //return menu Screen
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //reset all parameter
        if (other.tag == "Player")
        {
            playerScript.walkingSpeed = 2f;
            playerScript.runningSpeed = 3f;
            go = true;
        }
    }
}

public static class RendererExtensions
{
    public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
}