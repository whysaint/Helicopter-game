using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class upRamka : MonoBehaviour
{
    public float forceBackInMap = 5f;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = FindObjectOfType<HelicopterMover>().GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        _rb.AddForce(Vector3.down * forceBackInMap);
    }
}
