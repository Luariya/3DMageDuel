using Photon.Pun;
using UnityEngine;

public class Jumping : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] float Jumpforce = 5f;
    [SerializeField] float GroundDistance = 1f;
    Rigidbody rb;
    public LayerMask GroundMask;

    private bool isGrounded;
    private string deviceIdentifier;
    private Vector3 networkPosition;
    private Quaternion networkRotation;

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
        {
            transform.position = Vector3.Lerp(transform.position, networkPosition, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, networkRotation, Time.deltaTime * 5);
            return;
        }

        isGrounded = Physics.Raycast(transform.position, Vector3.down, GroundDistance, GroundMask);

        Jump();
    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine)
            return;

        // Update the network position and rotation
        networkPosition = transform.position;
        networkRotation = transform.rotation;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(rb.velocity.x, Jumpforce, rb.velocity.z), ForceMode.Impulse);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Send the local player's position and rotation to the network
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            // Receive the network player's position and rotation and update them
            networkPosition = (Vector3)stream.ReceiveNext();
            networkRotation = (Quaternion)stream.ReceiveNext();
        }
    }
}