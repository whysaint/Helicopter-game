using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RamkaInWorld : MonoBehaviour
{
    public Rigidbody _rb;
    public float forceValue = 5f;
    public Transform centreMap;

    private void Start()
    {
        _rb = FindObjectOfType<HelicopterMover>().GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("RAMKA"))
        {
            Vector3 pushDirection = (transform.position - other.ClosestPoint(transform.position));
            
            Debug.Log("Игрок задел границу! Отталкиваем в сторону: " + pushDirection);

            _rb.velocity = pushDirection * forceValue;
        }
    }
}
