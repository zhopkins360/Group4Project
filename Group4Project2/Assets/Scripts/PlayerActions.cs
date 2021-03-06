using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    //player interaction settings
    public float speed, mouseSensitivity, interactionDist;

    //Rigidbody reference for player
    private Rigidbody player;

    //mouse position with sensitivity
    private float mouseX;

    //manager reference
    private PlayerManager manager;

    //backpack reference
    [SerializeField]
    private GameObject backpack;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody reference
        player = gameObject.GetComponent<Rigidbody>();

        //locks mouse pointer into game
        Cursor.lockState = CursorLockMode.Locked;

        //hides backpack
        backpack.SetActive(false);

        //set playerManager reference
        manager = GetComponent<PlayerManager>();

        Physics.gravity = new Vector3(0, -30, 0);
    }

    private void FixedUpdate()
    {
        //player movement 2.0
        float MH = Input.GetAxis("Horizontal");
        float MV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(MH, 0f, MV).normalized;

        player.AddRelativeForce((movement * speed)/Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        //get and set player rotation
        mouseX = Input.GetAxis("Mouse X")
                 * mouseSensitivity
                 * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        //finds all colliders in an area
        Collider[] interactables = Physics.OverlapSphere(transform.position, interactionDist);

        //if it is interactable, set as highlighted
        foreach (Collider item in interactables)
        {
            if (item.GetComponent<Interactables>() != null)
            {
                item.GetComponent<Interactables>().isHighlighted = true;
            }
        }

        //interact on E or mouse0
        if (Input.GetKeyDown(KeyCode.E))
        {
            DoInteraction(interactables);
        }

        //show backpack on R
        if (Input.GetKeyDown(KeyCode.R))
        {
            backpack.SetActive(!backpack.activeSelf);
        }
    }

    private void DoInteraction(Collider[] interactables)
    {
        //variables declaration
        GameObject interaction = null;
        float minDist = float.MaxValue;

        //itterates through all things in range to find the closest intreractable object
        foreach (Collider i in interactables)
        {
            float distance = Vector3.Distance(transform.position, i.gameObject.transform.position);
            if (distance < minDist && i.GetComponent<Interactables>() != null)
            {
                interaction = i.gameObject;
                minDist = distance;
            }
        }

        //checks if an interactable object was found and interacts with it if it can be
        if (interaction != null)
        {
            manager.UseAction();
            interaction.GetComponent<Interactables>().Interact();
        }
    }
}
