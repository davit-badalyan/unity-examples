using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 startPosition = new Vector3(-1.75f, 4.25f, 0);
    public float sideMovementSpeed = 25;
    public float jumpForce = 5f;

    private float fallBound = -25.0f;
    private bool jumpPressed = false;
    private bool rightPressed = false;
    private bool leftPressed = false;

    private void Start()
    {
        ResetPlayer();
    }

    private void Update()
    {
        CheckForInput();
    }

    private void FixedUpdate()
    {
        CheckForJump();
        CheckForMovement();
        CheckForPlayerFall();
    }

    private void CheckForInput()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rightPressed = true;
        }
        else
        {
            rightPressed = false;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            leftPressed = true;
        }
        else
        {
            leftPressed = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            jumpPressed = true;
        }
        else
        {
            jumpPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetPlayer();
        }
    }

    private void CheckForJump()
    {
        if (jumpPressed && IsOnGround())
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    private void CheckForMovement()
    {
        Rigidbody rb = transform.GetComponent<Rigidbody>();
        float force = sideMovementSpeed * Time.deltaTime;

        if (rightPressed)
        {
            rb.AddForce(force, 0, 0, ForceMode.VelocityChange);
        }

        if (leftPressed)
        {
            rb.AddForce(-force, 0, 0, ForceMode.VelocityChange);
        }
    }

    private void CheckForPlayerFall()
    {
        if (transform.position.y < fallBound)
        {
            ResetPlayer();
        }
    }

    private void ResetPlayer()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = Vector3.zero;
        transform.position = startPosition;
    }

    private bool IsOnGround()
    {
        RaycastHit hit;
        int distance = 1;
        int layerMask = 1 << 8;
        bool result = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, distance, layerMask);

        return result;
    }
}
