using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBehaviour : MonoBehaviour
{
    [SerializeField] float SpellSpeed = 50f;
    [SerializeField] Transform Orientation;
    Rigidbody rb;

    private float SpellGone = 2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        Invoke("SpellDestroy", SpellGone);
    }

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * SpellSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    void SpellDestroy()
    {
        Destroy(this.gameObject);
    }
}