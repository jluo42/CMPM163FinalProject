using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float characterSpeed = 12f;
    public float gravity = 0f;
    public float jumpHeight = 3f;

   // public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        // Debug.Log("I am ground: " + isGrounded);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float playerX = Input.GetAxis("Horizontal"); //player X axis.
        float playerZ = Input.GetAxis("Vertical"); //player Y axis.

        Vector3 movement = transform.right * playerX + transform.forward * playerZ;
        controller.Move(movement * characterSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) //Able to double jump because of the charactercontroller collider in the plane. Look for fix.
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //velocity = squareroot of the jumpheight * -2 and gravity
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
