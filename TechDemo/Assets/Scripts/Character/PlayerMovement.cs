using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Camera myCamera;
    float cameraZoomInSpeed = .1f;
    float cameraZoomOutSpeed = .7f;
    float maxFOV = 60f;
    float zoomInFOV = 30f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    public bool isGrounded;

    //Can be adjusted in the future to allow for more jumps *item drop/power up/etc*
    public float maxJump;
    public float timesJumped;

    void ChangeFOV(string direction)
    {
        if(myCamera.fieldOfView > zoomInFOV && direction == "in")
        {
            Debug.Log("Trying to lower camera FOV");
            myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, zoomInFOV, cameraZoomInSpeed);
        }
        if(myCamera.fieldOfView <= maxFOV && direction == "out")
        {
            Debug.Log("resetting camera fov to 60");
            myCamera.fieldOfView = Mathf.MoveTowards(myCamera.fieldOfView, maxFOV, cameraZoomOutSpeed);             
        }
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            timesJumped = 0;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        // put the functionality within this if statement because of an issue where the pause menu could be overwritten by right clicking again
        if (PauseMenu.GameIsPaused == false)
        {
            //Slowing time down with right click
            if (Input.GetMouseButton(1))
            {
                Debug.Log("Pressed Right click");
                Time.timeScale = 0.35f; //could potentially make this gradually scale instead of instantly.
                ChangeFOV("in");
            }
            //putting time back to normal when letting go of right click
            else
            {
                Debug.Log("Let Right click go");
                Time.timeScale = 1f;
                ChangeFOV("out");
            }
        }

        // Jumping will work if the user is on the floor OR is in the air and has jumped less than the max number of jumps. These values are set in the editor
        if((Input.GetButtonDown("Jump") && isGrounded) || (timesJumped < maxJump && Input.GetButtonDown("Jump")))
        {
            Debug.Log("Jumped");
            timesJumped++;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
