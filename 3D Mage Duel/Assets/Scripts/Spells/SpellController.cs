using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    public SpellBehaviour SpellPrefab;
    public Transform SpellOffset;
    private float SpellCooldown = 0.1f;
    private float SpellCooldown2 = 0.3f;
    
    private bool SpellReady = true;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && SpellReady)
        {
            Instantiate(SpellPrefab, SpellOffset.transform.position, SpellOffset.transform.rotation);

            Invoke("SpellTimer", SpellCooldown);
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
