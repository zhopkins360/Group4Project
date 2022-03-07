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

    public GameObject wifeModel, sonModel, daughterModel;

    public ParticleSystem sonEffect, wifeEffect;

    //for debug below
    //public GameObject[] prefab;

    private FamilyBehavior familyBehaviorScript;

    private void Start()
    {
        familyBehaviorScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<FamilyBehavior>();
        level = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();
        sonEffect = sonModel.GetComponentInChildren<ParticleSystem>();
        wifeEffect = wifeModel.GetComponentInChildren<ParticleSystem>();
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

        wifeModel.SetActive(familyBehaviorScript.haveWife);
        if (familyBehaviorScript.wifeActive)
        {
            wifeEffect.Play();
        }
        else
        {
            wifeEffect.Pause();
            wifeEffect.Clear();
        }

        sonModel.SetActive(familyBehaviorScript.haveSon);
        if (familyBehaviorScript.sonActive)
        {
            sonEffect.Play();
        }
        else
        {
            sonEffect.Pause();
            sonEffect.Clear();
        }

        daughterModel.SetActive(familyBehaviorScript.haveDaughter);

        //Debug summon cars
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Instantiate(prefab[Random.Range(0,prefab.Length)], transform.position + new Vector3(0, 0, 20), new Quaternion());
        //}
    }
}
