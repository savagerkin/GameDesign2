/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisasterManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisasterManager : MonoBehaviour
{
    public float startTime = 10;
    private float timeRemaining;

    public bool timerIsRunning = false;
    public bool disastersActive = false;
    public bool disasterIsRandom = true;

    [Range(1, 3)] public int selectedDisaster = 1;
    
    public GameObject mainCamera;
    public bool cameraIsShaking = false;
    public float cameraShakeAmount = 0.1f;
    
    public GameObject wind;
    public GameObject boulder;
    public GameObject earthquake;

    private GameObject windInstant;
    private GameObject boulderInstant;
    private GameObject earthquakeInstant;

    public float boulderMass = 6f;
    public float windMagnitude = 5f;
    public float earthquakeMagnitude = 30f;

    private int disasterRandomiser;
    [SerializeField] private Canvas winCanvas;


    private void Start()
    {
        timeRemaining = startTime;
        InvokeRepeating("ChangeEarthquakeAngle", 0f, 0.2f);
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                //Time tick:
                timeRemaining -= Time.deltaTime;

                //Disaster updates:
                if (disastersActive)
                {
                    switch (disasterRandomiser)
                    {
                        case 1:
                            windInstant.GetComponentInChildren<AreaEffector2D>().forceMagnitude =
                                (startTime - timeRemaining) * windMagnitude;
                            Debug.Log(windInstant.GetComponentInChildren<AreaEffector2D>().forceMagnitude);
                            break;
                        case 2:
                            break;
                        case 3:
                            if (cameraIsShaking)
                            {
                                mainCamera.transform.localPosition =
                                    (Random.insideUnitSphere + new Vector3(0, 0, -10)) * cameraShakeAmount;
                            }

                            break;
                    }
                }
            }
            else
            {
                //Time end:
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                CancelInvoke("ChangeEarthquakeAngle"); // Stop the InvokeRepeating method

                //Disasters end:
                if (disastersActive)
                {
                    switch (disasterRandomiser)
                    {
                        case 1:
                            windInstant.GetComponentInChildren<AreaEffector2D>().forceMagnitude = 0;
                            Debug.Log(windInstant.GetComponentInChildren<AreaEffector2D>().forceMagnitude);
                            windInstant.SetActive(false);
                            break;
                        case 2:
                            boulderInstant.SetActive(false);
                            break;
                        case 3:
                            earthquakeInstant.SetActive(false);
                            cameraIsShaking = false;
                            mainCamera.transform.position = new Vector3(0, 0, -10);
                            break;
                    }
                }

                Time.timeScale = 0;
                winCanvas.gameObject.SetActive(true);
            }
        }
    }

    public void StartDisaster()
    {
        //Starting a random disaster:
        if (disastersActive)
        {
            if (disasterIsRandom)
            {
                disasterRandomiser = Random.Range(1, 4);
            }
            else
            {
                disasterRandomiser = selectedDisaster;
            }

            switch (disasterRandomiser)
            {
                case 1:
                    windInstant = Instantiate(wind);
                    break;
                case 2:
                    boulderInstant = Instantiate(boulder);
                    boulderInstant.GetComponent<Rigidbody2D>().mass = boulderMass;
                    break;
                case 3:
                    earthquakeInstant = Instantiate(earthquake);
                    earthquakeInstant.GetComponent<AreaEffector2D>().forceMagnitude = earthquakeMagnitude;
                    break;
            }
        }

        //Starting the timer:
        timerIsRunning = true;
    }

    // This function changes the earthquake angle randomly
    public void ChangeEarthquakeAngle()
    {
        if (disasterRandomiser == 3)
        {
            earthquakeInstant.GetComponent<AreaEffector2D>().forceAngle =
                Random.Range(-359.9999f, 359.9999f);
        }
    }
}