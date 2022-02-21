/*
 * group 4
 * 2/2/22
 * moves obstacles over time
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    //speed of movement
    public float speed;

    public LevelManager level;

    public FamilyBehavior familyBehaviorScript;
    private void Start()
    {
        level = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();
        familyBehaviorScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<FamilyBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!level.gameOver && !CompareTag("Prop"))
        {
            speed = familyBehaviorScript.incomingVehicleSpeed;
        }
        else
        {
            speed = 50;
        }

        //move car speed units per second towards the back
        transform.Translate(speed * Time.deltaTime * Vector3.back, Space.World);
    }
}
