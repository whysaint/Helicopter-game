using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamkaInWorld : MonoBehaviour
{
    public Rigidbody _rb;
    public float forceValue;

    private void Start()
    {
        _rb = FindObjectOfType<HelicopterMover>().GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_rb.position.y <= -5)
        {
            _rb.AddForce(Vector3.up * forceValue);
        }
    }
}
