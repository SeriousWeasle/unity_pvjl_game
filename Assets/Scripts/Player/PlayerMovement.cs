using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Other objects and attributes the script needs
    public CharacterController controller;  //Player Character controller
    public InputHandler inputhandler;
    public Transform groundchecker; //Checker for ground intersections
    public Transform respawnPoint;

    //public variables
    public float speed = 7f; //walking speed of character in u/s
    public float runmult = 2f; //multiplication factor for speed when sprinting
    public float gravity = 10f; //gravitational acceleration for falling
    public float groundDistance = 0.5f; //distance the groundchecker will check for ground
    public float jumpHeight = 2f; //times gravity upwards acceleration in jump
    public float verticalOOB = -10f; //height at which player will be teleported back because it is out of bounds

    public LayerMask groundMask; //Layer used for jump checking

    //private variables
    Vector3 movement;
    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //Check if player is standing on the ground
        isGrounded = Physics.CheckSphere(groundchecker.position, groundDistance, groundMask); //Check from the floorchecker with a radius of ground distance for a floor layermask

        //If player reaches ground -> set y velocity to -4 u/s.
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -4f;
        }

        //get walking movement
        movement = inputhandler.walkDirection();

        //check for running
        if (inputhandler.isRunning())
        {
            movement *= runmult; //if running; multiply the movement vector with the run multiplier
        }

        //Move character along movement in 1 timestep
        controller.Move(movement * speed * Time.deltaTime); //move controller with set speed along movement axis, accounting for framerate

        //check if player can jump and is jumping
        if (isGrounded && inputhandler.isJumping())
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity); //Apply upward force for jump
        }

        //calculate downward velocity
        velocity.y += gravity * Time.deltaTime * -1f;

        controller.Move(velocity * Time.deltaTime);

        //check if player is out of bounds vertically
        if(groundchecker.transform.position.y < verticalOOB)
        {
            gameObject.transform.position = respawnPoint.position;
            velocity = new Vector3(0, 0, 0);
        }
    }
}