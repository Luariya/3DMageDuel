using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerCamera : MonoBehaviour
{
    private float MouseX = 100f;
    private float MouseY = 100f;

    public Transform CamRotation;

    private float yRotation;
    private float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Camera();
    }

    void Camera()
    {
        float sensX = Input.GetAxisRaw("Mouse X") * MouseX * Time.fixedDeltaTime;
        float sensY = Input.GetAxisRaw("Mouse Y") * MouseY * Time.fixedDeltaTime;

        xRotation -= sensY;
        yRotation += sensX;
        
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        CamRotation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
