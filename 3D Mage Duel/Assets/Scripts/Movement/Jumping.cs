using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jumping : MonoBehaviour
{
    [SerializeField] float Jumpforce = 5f;
    [SerializeField] float GroundDistance = 1f;
    Rigidbody rb;
    public LayerMask GroundMask;

    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, new Vector3(0, -1, 0), GroundDistance, GroundMask);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        { 
            rb.velocity = Vector3.zero;

            rb.AddForce(new Vector3(rb.velocity.x, Jumpforce, rb.velocity.z), ForceMode.Impulse);
        }
    }
}
