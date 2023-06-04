using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerController : MonoBehaviourPunCallbacks
{
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float groundDistance = 1f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Camera camera;

    private Rigidbody rb;
    private bool isGrounded;
    private string deviceIdentifier;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (photonView.IsMine)
        {
            deviceIdentifier = PhotonNetwork.LocalPlayer.UserId;
        }
        else
        {
            rb.isKinematic = true;
        }
    }

    private void Update()
    {
        if (!photonView.IsMine)
            return;

        // Handle movement input for the local player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * movementSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundDistance, groundMask);

        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(rb.velocity.x, jumpForce, rb.velocity.z), ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine)
            return;

        RotateToDirection();
    }

    private void RotateToDirection()
    {
        transform.rotation = Quaternion.LookRotation(-camera.transform.forward, camera.transform.up);
    }
}