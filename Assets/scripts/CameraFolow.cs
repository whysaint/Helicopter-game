using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    public Transform target;
    public Vector3 cameraPosition = new Vector3(0f, 1f, -10f);
    public float cameraSpeed = 3f;
    
    public float maxWolrdGranzaY;
    public float minWorldGranzaY;
    private bool isFolowing;

    public List<Transform> AllHelicopters = new List<Transform>();

    private void Start()
    {
        GetTarget();
    }

    void LateUpdate()
    {
        Vector3 derectivePosition = target.position + cameraPosition;

        if (target.position.y > maxWolrdGranzaY || target.position.y < minWorldGranzaY)
        {
            derectivePosition.y = transform.position.y;
        }
        
        Vector3 finalPosition = Vector3.Lerp(transform.position, derectivePosition, cameraSpeed * Time.deltaTime);
        transform.position = finalPosition;

        Vector3 LookAtTarget = target.position;
        if (LookAtTarget.y > maxWolrdGranzaY)
        {
            LookAtTarget.y = target.position.y;
        }

        transform.LookAt(LookAtTarget + Vector3.forward * 10f);
    }

    void GetTarget()
    {
        for (int i = 0; i < AllHelicopters.Count; i++)
        {
            if (AllHelicopters[i].gameObject.activeSelf)
            {
                target = AllHelicopters[i].gameObject.transform;
                return;
            }
        }
    }
}


