using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    public SpellBehaviour SpellPrefab;
    public Transform SpellOffset;
    private float SpellCooldown;


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))

        {
            Instantiate(SpellPrefab, SpellOffset.position, transform.rotation);
        }
    }
}
