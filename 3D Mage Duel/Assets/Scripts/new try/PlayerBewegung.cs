using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class PlayerBewegung : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private Transform cameraTransform;

    private CharacterController characterController;
    private float verticalVelocity;
    public GameObject cameraObject;

    private PhotonView view;
    
    private HealthManager healthManager;

    public SpellBehaviour SpellPrefab;
    public Transform SpellOffset;
    private float SpellCooldown = 0.1f;
    private float SpellCooldown2 = 0.3f;

    private bool SpellReady = true;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        view = GetComponent<PhotonView>();
        if (!view.IsMine)
        {
            // Disable the camera if this is not the local player
            cameraObject.SetActive(false);
        }

        healthManager = FindObjectOfType<HealthManager>();
    }

    private void Update()
    {
        if (view.IsMine)
        {
            Debug.Log("isMineWorking");
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
            Debug.Log("isMineWorkingStill");

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
            Debug.Log("isMineworksfully");

            if (Input.GetButtonDown("Fire1") && SpellReady)
            {
                PhotonNetwork.Instantiate(SpellPrefab.name, SpellOffset.transform.position, SpellOffset.transform.rotation);

                Invoke("SpellTimer", SpellCooldown);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
               Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }    

    void CursorState()
    {
        if (healthManager.gameOver == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (!view.IsMine && healthManager.gameOver == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void SpellTimer()
    {
        SpellReady = false;

        Invoke("SpellTimer2", SpellCooldown2);
    }

    void SpellTimer2()
    {
        SpellReady = true;
    }
}