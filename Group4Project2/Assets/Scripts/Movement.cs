using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed, mouseSensitivity = 500f;

    private Rigidbody player;

    private float mouseX;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        player.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * speed);

        player.AddRelativeForce(Vector3.right * Input.GetAxis("Horizontal") * speed);

        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);
    }
}
