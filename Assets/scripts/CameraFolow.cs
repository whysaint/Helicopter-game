using System;
using System.Transactions;
using UnityEngine;

public class CameraFollowWithSelfBounds : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 1f, -10f);
    public float speedZoom;

    private void LateUpdate()
    {
        Vector3 derectiveTarget = target.position + offset;
        Vector3 finalCameraPosition = Vector3.Lerp(transform.position, derectiveTarget, speedZoom * Time.deltaTime);
        transform.position = finalCameraPosition;
        
        transform.LookAt(target.position + Vector3.forward * 3f);
    }
}