using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RamkaInWorld : MonoBehaviour
{
    public Rigidbody _rb;
    public float forceValue;
    public Transform downWall;
    public Transform upWall;
    public Transform leftWall;
    public Transform rightWall;

    private void Start()
    {
        _rb = FindObjectOfType<HelicopterMover>().GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RAMKA"))
        {
            Debug.Log("Граница");
        }
    }
}
