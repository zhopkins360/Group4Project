using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public float speed, mouseSensitivity, interactionDist;

    private Rigidbody player;

    private float mouseX;

    private PlayerManager manager;

    [SerializeField]
    private GameObject backpack;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        backpack.SetActive(false);

        manager = GetComponent<PlayerManager>();
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

        //finds all colliders in an area
        Collider[] interactables = Physics.OverlapSphere(transform.position, interactionDist);

        foreach (Collider item in interactables)
        {
            if (item.GetComponent<Interactables>() != null)
            {
                item.GetComponent<Interactables>().isHighlighted = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            DoInteraction(interactables);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            backpack.SetActive(!backpack.activeSelf);
        }
    }

    private void DoInteraction(Collider[] interactables)
    {
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
