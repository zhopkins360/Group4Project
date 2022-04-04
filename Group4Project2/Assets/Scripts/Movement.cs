using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed, mouseSensitivity;

    private Rigidbody player;

    private float mouseX;

    [SerializeField]
    private GameObject backpack;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        backpack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        player.AddRelativeForce(Input.GetAxis("Vertical")
                                * speed
                                * Vector3.forward);

        player.AddRelativeForce(Input.GetAxis("Horizontal")
                                * speed
                                * Vector3.right);

        mouseX = Input.GetAxis("Mouse X")
                 * mouseSensitivity
                 * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        if (Input.GetKey(KeyCode.E))
        {
            DoInteraction();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            backpack.SetActive(!backpack.activeSelf);
        }
    }

    private void DoInteraction()
    {
        //finds all colliders in an area
        Collider[] interactables = Physics.OverlapSphere(transform.position, 5);
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
            interaction.GetComponent<Interactables>().Interact();
        }
    }
}
