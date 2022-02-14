/*
 * group 4
 * 2/2/22
 * controls player movement
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //veriable for input, max speed, and limit of +/- x
    public float horizontalInput, speed, xLimit;

    public GameObject[] wheels;

    public LevelManager level;

    //for debug below
    //public GameObject[] prefab;

    private void Start()
    {
        level = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //get input
        horizontalInput = Input.GetAxis("Horizontal");

        if (!level.gameOver)
        {
            //move player
            transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right, Space.World);

            //Rotate on move
            transform.rotation = Quaternion.Euler(0, horizontalInput * 20, 0);
        }

        //rotate players wheels (I know this is practically pointless)
        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].transform.Rotate(270 * speed * Time.deltaTime * Vector3.right);
        }

        //keep player bounded
        if (transform.position.x < -xLimit || transform.position.x > xLimit)
        {
            transform.position = new Vector3(xLimit * Mathf.Sign(transform.position.x), transform.position.y, transform.position.z);
        }

        //Debug summon cars
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Instantiate(prefab[Random.Range(0,prefab.Length)], transform.position + new Vector3(0, 0, 20), new Quaternion());
        //}
    }
}
