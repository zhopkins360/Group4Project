/*
 * Group 4
 * CIS 350:01
 * Manages game variables (health, timer, gamestate)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int health, maxHealth;
    
    public float timeLeft;

    public bool gameOver;

    public GameObject[] prefab;

    //particle systems when health is low, critical, and 0
    public GameObject lowHealthParticles;
    public GameObject criticalHealthParticles;
    public GameObject zeroHealthParticles;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        lowHealthParticles.SetActive(false);
        criticalHealthParticles.SetActive(false);
        zeroHealthParticles.SetActive(false);
        StartCoroutine(SpawnCars());
    }

    // Update is called once per frame
    void Update()
    {
        //enforce max health
        if(health> maxHealth)
        {
            health = maxHealth;
        }

        //if out of health or time, clean up time and end game
        if (health <= 0 || timeLeft <=0)
        {
            timeLeft = 0f;
            gameOver = true;
        }

        //when the game is not over, reduce timer
        if (!gameOver)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            //when game is over, restart level when key R is pressed
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    //called when the player is damaged, such as when coliding with obstacles
    public void Damage()
    {
        health--;

        //when damaged, show relevant smoke/fire particles
        //if health is low or critical, show smoke particles, show fire if 0
        //for now, low threshold is 2 and critical threshold is 1

        if (health <= 0)
        {
            lowHealthParticles.SetActive(false);
            criticalHealthParticles.SetActive(false);
            zeroHealthParticles.SetActive(true);
        }
        else if (health == 1)
        {
            lowHealthParticles.SetActive(false);
            criticalHealthParticles.SetActive(true);
            zeroHealthParticles.SetActive(false);
        }
        else if (health <= 2)
        {
            lowHealthParticles.SetActive(true);
            criticalHealthParticles.SetActive(false);
            zeroHealthParticles.SetActive(false);
        }
    }

    IEnumerator SpawnCars()
    {
        yield return new WaitForSeconds(4f);

        while (!gameOver)
        {
            Spawn();

            yield return new WaitForSeconds(Random.Range(0,2f));
        }
    }

    void Spawn()
    {
        //randomize what one of 5 lanes the obstacle appears in
        int laneIndex = Random.Range(-2, 3) * 2;

        //create position to create new copy of prefab
        Vector3 recyclePosition = new Vector3(laneIndex, 0, 20);

        //create new obstacle with no roatation in case of collision
        Instantiate(prefab[Random.Range(0, prefab.Length)], recyclePosition, new Quaternion());
    }
}
