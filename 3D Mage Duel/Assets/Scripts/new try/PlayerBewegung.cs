using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Photon.Pun;


public class PlayerBewegung : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private Transform cameraTransform;

    private CharacterController characterController;
    private float verticalVelocity;

    PhotonView view; 

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (view.IsMine)
        {
            // Rotation
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            transform.Rotate(Vector3.up, mouseX);

            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
            float newCameraRotationX = cameraTransform.localEulerAngles.x - mouseY;

            if (newCameraRotationX > 180f)
                newCameraRotationX -= 360f;

            newCameraRotationX = Mathf.Clamp(newCameraRotationX, -90f, 90f);

            cameraTransform.localEulerAngles = new Vector3(newCameraRotationX, 0f, 0f);

            // Movement
            float moveX = Input.GetAxis("Horizontal") * movementSpeed;
            float moveZ = Input.GetAxis("Vertical") * movementSpeed;

            Vector3 movement = transform.right * moveX + transform.forward * moveZ;

            // Apply gravity
            if (!characterController.isGrounded)
            {
                verticalVelocity += Physics.gravity.y * Time.deltaTime;
            }
            else
            {
                // Reset vertical velocity when grounded
                verticalVelocity = -0.5f;

                // Jumping
                if (Input.GetButtonDown("Jump"))
                {
                    verticalVelocity = jumpForce;
                }
            }

            movement.y = verticalVelocity;
            characterController.Move(movement * Time.deltaTime);
        }
    }
      
}