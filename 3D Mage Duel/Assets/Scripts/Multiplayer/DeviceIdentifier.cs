using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceIdentifier : MonoBehaviour
{
    private string deviceID;

    private void Awake()
    {
        deviceID = SystemInfo.deviceUniqueIdentifier;
    }

    private void Update()
    {
        if (IsCurrentDevice())
        {
            ProcessInput();
        }
    }

    private bool IsCurrentDevice()
    {
        return SystemInfo.deviceUniqueIdentifier == deviceID;
    }

    private void ProcessInput()
    {
        Input.GetAxis("Horizontal");
        Input.GetAxis("Vertical");
        Input.GetAxisRaw("Mouse X");
        Input.GetAxisRaw("Mouse Y");
        Input.GetButton("Fire1");
        Input.GetKey(KeyCode.Space);
    }
}
