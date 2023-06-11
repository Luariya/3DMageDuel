using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Damage : MonoBehaviour
{
    private HealthManager healthManager;

    private void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }

 /*   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            healthManager.DecreaseHearts();
            healthManager.DestroyHearts( 1);
            Debug.Log("-1 Heart");
        }
    } */
}
