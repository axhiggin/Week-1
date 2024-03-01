using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontroller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;
    public float jumpForce = 10f;

    private bool isGrounded;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("Hello world!");
    }

    private void Update()
    {
        // Check if the character is on the ground
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // Player input for movement and rotation
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move the character
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Rotate the character
        float rotation = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotation);

        // Jumping
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Turning on and off
        if (Input.GetKeyDown("x"))
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        if (Input.GetKeyDown("c"))
        {
            transform.localScale *= 2f;
        }
    }
}
