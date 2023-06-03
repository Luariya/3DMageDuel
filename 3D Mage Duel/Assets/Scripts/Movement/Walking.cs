using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 100f;
    [SerializeField] float GroundDrag = 5f;
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
        Movement();

        if (isGrounded )
        {
            rb.drag = GroundDrag;
        }
        else
        {
            rb.drag = 0f;
        }
    }

    private void FixedUpdate()
    {
        MoveToDirection();

        RotateToDirection();

        isGrounded = Physics.Raycast(transform.position, Vector3.down, GroundDistance, GroundMask);
    }

    void Movement()
    {
        movementForward = Input.GetAxis("Vertical") * MovementSpeed;
        movementSide = Input.GetAxis("Horizontal") * MovementSpeed;
    }

    private void MoveToDirection()
    {
        Direction = Orientation.forward * movementForward + Orientation.right * movementSide;

        rb.AddForce(Direction.normalized * MovementSpeed, ForceMode.Force);
    }

    private void RotateToDirection()
    {
        transform.rotation = Quaternion.LookRotation(-Camera.transform.forward, Camera.transform.up);
    }

}
