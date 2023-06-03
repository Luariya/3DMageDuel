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
        // Process the input commands for the current device
        // Your code here...
    }
}
