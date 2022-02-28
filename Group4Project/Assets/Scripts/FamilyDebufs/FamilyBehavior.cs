using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyBehavior : MonoBehaviour
{
    public AudioSource playerAudio;
    public AudioClip sonAudio;
    public AudioClip daughterAudio;
    public AudioClip wifeAudio;
    public float incomingVehicleSpeed;
    public bool haveSon;
    public float sonPower;
    public bool haveDaughter;
    public bool haveWife;
    public float wifePower;
    private float wifeSpeed;
    public GameObject[] imagePrefabs;

    private GameObject canvas;
    
    private LevelManager levelManagerScript;
    private Rigidbody playerCar;

    // Start is called before the first frame update
    void Start()
    {
        levelManagerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();
        canvas = GameObject.FindGameObjectWithTag("Overlay");
        playerCar = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        //if you have the son debuf
        if (haveSon)
        {
            StartCoroutine(SonDebuf());
        }
        //if you have the daughter debuf
        if (haveDaughter)
        {
            StartCoroutine(DaughterDebuf());
        }
        //if you have the wife debuf start it
        if (haveWife)
        {
            StartCoroutine(WifeDebuf());
            wifeSpeed = incomingVehicleSpeed * (1 + wifePower);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //have wife function
    IEnumerator WifeDebuf()
    {
       
            while (!levelManagerScript.gameOver)
            {
                float delay = Random.Range(5f, 8f);
                if (haveWife)
                {
                    yield return new WaitForSeconds(delay);
                    incomingVehicleSpeed = wifeSpeed;
                    playerAudio.PlayOneShot(wifeAudio);
                }
                yield return new WaitForSeconds(10f);
                //incomingVehicleSpeed = 10;
            }
        
    }

    //ienumerator to randomize the delay s for 
    IEnumerator SonDebuf()
    {
       
            yield return new WaitForSeconds(3f);
            while (!levelManagerScript.gameOver)
            {
                float delay = Random.Range(3f, 5f);
                if (haveSon)
                {
                    float leftOrRight = Random.Range(-1, 1);
                    playerAudio.PlayOneShot(sonAudio);
                    if (leftOrRight < 0)
                    {
                        playerCar.AddForce(Vector3.right * sonPower, ForceMode.Impulse);
                        yield return new WaitForSeconds(1f);
                        playerCar.AddForce((-1) * Vector3.right * sonPower, ForceMode.Impulse);
                    }
                    else
                    {
                        playerCar.AddForce(Vector3.left * sonPower, ForceMode.Impulse);
                        yield return new WaitForSeconds(1f);
                        playerCar.AddForce((-1) * Vector3.left * sonPower, ForceMode.Impulse);
                    }
                }
                yield return new WaitForSeconds(delay);
            }
        
    }

    //Calls the spawn image function and randomizes the delayes between images
    IEnumerator DaughterDebuf() 
    {
       
            yield return new WaitForSeconds(Random.Range(1f, 5f));

            while (!levelManagerScript.gameOver)
            {
                float delay = Random.Range(3f, 4f);
                SpawnImage();
                playerAudio.PlayOneShot(daughterAudio);
                yield return new WaitForSeconds(delay);
            }
        
    }
    //randomly spawns image prefab on the screen moving from one sid to the other 
    void SpawnImage()
    {
        int randIndex = Random.Range(0, imagePrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(50,650), Random.Range(100, 350), 0);
        Instantiate(imagePrefabs[randIndex], spawnPos, imagePrefabs[randIndex].transform.rotation, canvas.transform);
    }

    public void stopBehaviors()
    {
        StopAllCoroutines();
        Debug.Log("Stop");

        Invoke("StartBehavior", 10f);
    }

    private void StartBehavior()
    {
        Debug.Log("Start");
        StartCoroutine(SonDebuf());
        StartCoroutine(DaughterDebuf());
        StartCoroutine(WifeDebuf());
    }
  
}
