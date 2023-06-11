using UnityEngine;
using Photon.Pun;

public class SpellBehaviour : MonoBehaviourPunCallbacks
{
    [SerializeField] float SpellSpeed = 30f;
    [SerializeField] Transform Orientation;
    Rigidbody rb;

    private float SpellGone = 2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        Invoke("SpellDestroy", SpellGone);
    }

    [PunRPC]
    private void Update()
    {
            transform.position += transform.forward * Time.deltaTime * SpellSpeed;      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (photonView.IsMine)
        {
            // Destroy the spell locally
            Destroy(gameObject);

            // Send collision RPC to other players
            photonView.RPC("SyncCollision", RpcTarget.Others);
        }
    }

    [PunRPC]
    private void SyncCollision()
    {
        // Process collision on other players
        Destroy(gameObject);
    }

    void SpellDestroy()
    {
        if (photonView.IsMine)
        {
            // Destroy the spell locally
            Destroy(this.gameObject);

            // Send destruction RPC to other players
            photonView.RPC("SyncSpellDestroy", RpcTarget.Others);
        }
    }

    [PunRPC]
    private void SyncSpellDestroy()
    {
        // Process destruction on other players
        Destroy(gameObject);
    }
}