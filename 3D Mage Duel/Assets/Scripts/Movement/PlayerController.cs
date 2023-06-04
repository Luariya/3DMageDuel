using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Transform cameraTransform;

    [SerializeField] private float movementSpeed = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cameraTransform = transform.GetChild(0).GetChild(0).transform; // Assuming the camera is the second child of the player prefab
    }

    private void FixedUpdate()
    {
        // Perform player movement logic here using the rb Rigidbody component
        // Use the cameraTransform to determine the movement direction or rotation
    }
}