using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityScript : MonoBehaviour
{
    public GameObject target;

    public Camera playerCamera;

    private bool go;

    private SC_FPSController playerScript;

    public float Dificulty = 60f;

    private float timer = 0.0f;
    private float timerDeath = 0.0f;

    private float speedB;
    private float fullSpeedB;

    public AudioSource hearBeat;

    public AudioSource goAway;


    // Start is called before the first frame update
    void Start()
    {
        go = true;

        playerScript = target.GetComponent<SC_FPSController>();
    }

    // Update is called once per frame
    void Update()
    {
            transform.LookAt(target.transform.position); // dudule see always player

        if (go)
        {

            if (gameObject.transform.position.x < target.transform.position.x)
            {
                transform.position += Vector3.right * playerScript.walkingSpeed * Time.deltaTime;
            }
            if (gameObject.transform.position.z < target.transform.position.z)
            {
                transform.position += Vector3.forward * playerScript.walkingSpeed * Time.deltaTime;
            }
            if (gameObject.transform.position.y < target.transform.position.y)
            {
                transform.position += Vector3.up * playerScript.walkingSpeed * Time.deltaTime;
            }

            if (gameObject.transform.position.x > target.transform.position.x)
            {
                transform.position += Vector3.left * playerScript.walkingSpeed * Time.deltaTime;
            }
            if (gameObject.transform.position.z > target.transform.position.z)
            {
                transform.position += Vector3.back * playerScript.walkingSpeed * Time.deltaTime;
            }
            if (gameObject.transform.position.y > target.transform.position.y)
            {
                transform.position += Vector3.down * playerScript.walkingSpeed * Time.deltaTime;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            speedB = playerScript.walkingSpeed;
            fullSpeedB = playerScript.walkingSpeed;

            timerDeath = 0.0f;
            timer = 0.0f;

            playerScript.runningSpeed = 0.25f;
            playerScript.walkingSpeed = 0.25f;
            go = false;

            hearBeat.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {

            timerDeath += Time.deltaTime;
            //Debug.Log(timerDeath);

            if(GetComponent<Renderer>().IsVisibleFrom(playerCamera)) //if player see Dudule
            {
                timer += Time.deltaTime;
                Debug.Log("Je le vois");
                Debug.Log(timer);

                if(!goAway.isPlaying)
                {
                    goAway.Play();
                }

                if(timer >= 2f) //after 2sec be seen Dudule
                {
                    Vector3 posit = gameObject.transform.position; //tp Dudule
                    posit.x += Dificulty;
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
            playerScript.walkingSpeed = speedB;
            playerScript.runningSpeed = fullSpeedB;
            go = true;

            if(hearBeat.isPlaying)
            {
                hearBeat.Stop();
            }
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