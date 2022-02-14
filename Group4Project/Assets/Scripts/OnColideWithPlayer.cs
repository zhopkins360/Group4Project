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

    //public Obstacle rec;

    private void Start()
    {
        //gets the script to recycle and reference level variables
        //rec = gameObject.GetComponent<Obstacle>();
        level = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if collide with the player
        if (other.CompareTag("Player"))
        {
            //damage player
            level.Damage();

            //TODO destruction effects

            Destroy(gameObject);
        }
    }
}
