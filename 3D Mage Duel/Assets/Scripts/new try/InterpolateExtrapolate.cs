using UnityEngine;
using Photon.Pun;

public class InterpolateExtrapolate : MonoBehaviour, IPunObservable
{
    private PhotonView photonView;
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Send the transform data of the local player
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            // Receive the transform data of the remote player
            targetPosition = (Vector3)stream.ReceiveNext();
            targetRotation = (Quaternion)stream.ReceiveNext();
        }
    }

    private void Update()
    {
        if (!photonView.IsMine)
        {
            // Interpolate position and rotation of the remote player
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
}