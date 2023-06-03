using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 10f;
    [SerializeField] float AirMovement = 0.5f;
    [SerializeField] Transform Orientation;
    [SerializeField] LayerMask GroundMask;
    [SerializeField] Camera Camera;
    Rigidbody rb;

    private float movementForward;
    private float movementSide;

    private bool isGrounded;
    private float GroundDistance = 5f;

    Vector3 Direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, GroundDistance, GroundMask);

        Movement();

        SpeedLimiter();
    }

    private void FixedUpdate()
    {
        MoveToDirection();

        RotateToDirection();
    }

    void Movement()
    {
        movementForward = Input.GetAxis("Vertical") * MovementSpeed;
        movementSide = Input.GetAxis("Horizontal") * MovementSpeed;
    }

    private void MoveToDirection()
    {
        Direction = Orientation.forward * movementForward + Orientation.right * movementSide;

        if (isGrounded)
        {
            rb.AddForce(Direction.normalized * MovementSpeed, ForceMode.Force);
        }

        if (!isGrounded)
        {
            rb.AddForce(Direction.normalized * MovementSpeed * AirMovement, ForceMode.Force);
        }
    }

    private void RotateToDirection()
    {
        transform.rotation = Quaternion.LookRotation(-Camera.transform.forward, Camera.transform.up);
    }

    private void SpeedLimiter()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > MovementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * MovementSpeed;
            rb.velocity = limitedVel = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
