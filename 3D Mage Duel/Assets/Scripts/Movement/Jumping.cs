using Photon.Pun;
using Photon.Realtime;
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
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, new Vector3(0, -1, 0), GroundDistance, GroundMask);

        Jump();

        if (!photonView.IsMine)
        {
            return;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        { 
            rb.AddForce(new Vector3(rb.velocity.x, Jumpforce, rb.velocity.z), ForceMode.Impulse);
        }
    }
}
