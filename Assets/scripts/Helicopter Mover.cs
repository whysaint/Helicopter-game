using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterMover : MonoBehaviour
{
    public float SpeedMove;
    public float SpeedRotate;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _rb.AddRelativeForce(0f, Input.GetAxis("Vertical") * SpeedMove, 0f);
        _rb.AddTorque(0f, 0f, -Input.GetAxis("Horizontal") * SpeedRotate );
    }
}
