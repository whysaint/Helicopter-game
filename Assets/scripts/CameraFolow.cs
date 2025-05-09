using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    public Transform target;
    public Vector3 camera = new Vector3(0f, 1f, -10f);
    public float speed;
    
    void LateUpdate()
    {
        Vector3 FactOffset = target.position + camera;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, FactOffset, speed * Time.deltaTime);

        transform.position = smoothedPosition;
        transform.LookAt(target.position + Vector3.forward * 10f);
    }
}
