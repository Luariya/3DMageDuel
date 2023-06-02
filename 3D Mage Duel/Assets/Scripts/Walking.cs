using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 10f;
    Rigidbody rb;

    private float movementForward;
    private float movementSide;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movement();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(movementSide, rb.velocity.y, movementForward);
    }

    void Movement()
    {
        movementForward = Input.GetAxis("Vertical") * MovementSpeed;
        movementSide = Input.GetAxis("Horizontal") * MovementSpeed;
    }

}
