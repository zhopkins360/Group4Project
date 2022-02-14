using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyBehavior : MonoBehaviour
{
    public bool haveSon;
    public float sonPower;
    public bool haveDaughter;
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
    }

    // Update is called once per frame
    void Update()
    {
        
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
                if (leftOrRight < 0)
                {
                    playerCar.AddForce(Vector3.right * sonPower);
                }
                else
                {
                    playerCar.AddForce(Vector3.left * sonPower);
                }
            }
            yield return new WaitForSeconds(delay);
        }
    }

    //Calls the spawn image function and randomizes the delayes between images
    IEnumerator DaughterDebuf() 
    {
        yield return new WaitForSeconds(1f);

        while (!levelManagerScript.gameOver)
        {
            float delay = Random.Range(3f, 4f);
            SpawnImage();
            yield return new WaitForSeconds(delay);
        }
    }
    //randomly spawns image prefab on the screen moving from one sid to the other 
    void SpawnImage()
    {
        int randIndex = Random.Range(0, imagePrefabs.Length);
        Vector3 spawnPos = new Vector3(-630, Random.Range(-130, 130), 0);
        Instantiate(imagePrefabs[randIndex], spawnPos, imagePrefabs[randIndex].transform.rotation, canvas.transform);
    }
}
