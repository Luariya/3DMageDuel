using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private HealthManager healthManager;

    private void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            healthManager.DecreaseHearts();
            Debug.Log("-1 Heart");
        }
        if (other.CompareTag("Player2"))
        {
            healthManager.DecreaseHearts2();
            Debug.Log("-1 Heart");
        }
    }
}
