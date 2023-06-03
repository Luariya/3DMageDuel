using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 100f;
    [SerializeField] float GroundDrag = 1f;
    [SerializeField] Transform Orientation;
    [SerializeField] LayerMask GroundMask;
    Rigidbody rb;

    private float movementForward;
    private float movementSide;

    private bool isGrounded;
    private float GroundDistance = 5f;

    Vector3 Direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
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

}
