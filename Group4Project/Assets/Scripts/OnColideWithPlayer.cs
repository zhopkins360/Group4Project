/*
 * Group 4
 * CIS 350:01
 * Manage collision with player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnColideWithPlayer : MonoBehaviour
{
    public LevelManager level;

    public GameObject Explosion;

    public FamilyBehavior family;

    //public Obstacle rec;

    private void Start()
    {
        //gets the script to recycle and reference level variables
        //rec = gameObject.GetComponent<Obstacle>();
        level = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();
        family = GameObject.FindGameObjectWithTag("GameController").GetComponent<FamilyBehavior>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if collide with the player
        if (other.CompareTag("Player") && gameObject.CompareTag("MovingObstacle") && level.hasShield == false)
        {
            //damage player
            level.Damage();

            Instantiate(Explosion, transform.position, Explosion.transform.rotation);
            Debug.Log("Explosion");

            Destroy(gameObject);
        }
        else if(other.CompareTag("Player") && gameObject.CompareTag("MovingObstacle") && level.hasShield == true)
        {
            Instantiate(Explosion, transform.position, Explosion.transform.rotation);
            Debug.Log("Explosion");
            level.hasShield = false;
            level.Shield.SetActive(false);

            Destroy(gameObject);
        }
        else if (other.CompareTag("Player") && gameObject.CompareTag("Finish"))
        {
            level.gameOver = true;
            level.win = true;
        }
        else if(other.CompareTag("Player") && gameObject.CompareTag("Health"))
        {
            level.Heal();

            Destroy(gameObject);
        }

        else if (other.CompareTag("Player") && gameObject.CompareTag("Shield"))
        {
            level.ShieldTime();

            Destroy(gameObject);
        }

        else if (other.CompareTag("Player") && gameObject.CompareTag("Note"))
        {
            family.stopBehaviors();
        }
    }
}
