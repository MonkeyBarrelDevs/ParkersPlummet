using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Upgradeables
    public float horsepower; // Formerly jumpPower
    public float flexibility; // Formerly maxRotationAngle
    public float torque; // Formerly rotationSpeed

    // Player Fields
    [SerializeField] bool movementEnabled;
    [SerializeField] float jumpDelay; // in seconds
    [SerializeField] Transform top;
    [SerializeField] Transform bottom;
    [SerializeField] float centerOfMass;

    // Player Hiddens
    bool jumpIntent;
    float moveDirection;
    float jumpTimer;
    Rigidbody2D rb;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        // Initializes all Player Hiddens
        movementEnabled = true;
        jumpIntent = false;
        rb = GetComponent<Rigidbody2D>();
        rb.centerOfMass = Vector2.up * centerOfMass;
        jumpTimer = jumpDelay;
        moveDirection = 0;
        audio = GetComponent<AudioSource>();
    }
    
    // Update is called on every frame.
    private void Update()
    {
        // Increment timers
        jumpTimer += Time.deltaTime;

        // Handles movement input
        moveDirection = Input.GetAxis("Horizontal");

        // Determines if the player wants to use a jump
        if (Input.GetKey("space"))
        {
            jumpIntent = true;
        }
    }

    // FixedUpdate is called regularly. This is for executing movement controls.
    private void FixedUpdate()
    {
        // Checks to see if the player is allowed to move
        if (movementEnabled)
        {
            Move();
            Jump();
        }
    }

    // Handles movement
    private void Move() 
    {
        // Uses the intended movement direction to determine the angle of the next bend.
        float targetRotation = bottom.localRotation.eulerAngles.z + torque * moveDirection;

        // Bounds the bending to within maxRotation in either direction.
        if (flexibility < targetRotation && targetRotation < 180f)
            targetRotation = flexibility;
        else if (180f < targetRotation && targetRotation < 360f - flexibility)
            targetRotation = 360f - flexibility;

        // Executes the movement instructions on the top and bottom half of the character.
        top.localRotation = Quaternion.Euler(0f, 0f, 360f- targetRotation);
        bottom.localRotation = Quaternion.Euler(0f, 0f, targetRotation);
    }

    // Jump is currently broken, is not registering key presses
    private void Jump() 
    {
        // Checks if the player is willing and able to jump
        if (jumpIntent) 
        {
            // Checks if the player has jumped recently
            if (jumpTimer >= jumpDelay)
            {
                // Determines the intended jump direction, and adds force either straight up or 45 degrees left/right.
                float intentDirection = Input.GetAxis("Horizontal");

                Vector2 direction = Vector2.up;
                if (intentDirection != 0)
                {
                    direction = (((intentDirection > 0) ? -1 : 1) * Vector2.left + direction).normalized;
                    rb.angularVelocity += horsepower * ((intentDirection > 0) ? -1 : 1);
                }
                rb.AddForce(direction * horsepower);

                // Decrements relevant trackers on a successful jump attempt.
                jumpTimer = 0;

                //Plays jump audio file.
                audio.Play(0);
            }
            jumpIntent = false;
        }
    }

    // Disallows the player from moving
    public void DisableMovement() 
    {
        movementEnabled = false;
    }

    // Allows the player to move
    public void EnableMovement() 
    {
        movementEnabled = true;
    }

    public void Launch(Vector2 direction) 
    {
        rb.AddForce(direction);
    }
}