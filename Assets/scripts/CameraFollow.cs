using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 cameraPosition = new Vector3(0f, 1f, -10f);
    [SerializeField] private float cameraSpeed = 3f;
    [SerializeField] private float maxWorldBoundY;
    [SerializeField] private float minWorldBoundY;
    [SerializeField] private List<Transform> allHelicopters = new List<Transform>();

    private void Start()
    {
        GetTarget();
    }

    private void LateUpdate()
    {
        if (target == null)
        {
            GetTarget();
            return;
        }
        
        Vector3 targetPosition = target.position + cameraPosition;

        if (target.position.y > maxWorldBoundY || target.position.y < minWorldBoundY)
        {
            targetPosition.y = transform.position.y;
        }
        
        Vector3 finalPosition = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
        transform.position = finalPosition;

        Vector3 lookAtTarget  = target.position;
        if (lookAtTarget .y > maxWorldBoundY)
        {
            lookAtTarget .y = target.position.y;
        }

        transform.LookAt(lookAtTarget  + Vector3.forward * 10f);
    }

    private void GetTarget()
    {
        for (int i = 0; i < allHelicopters.Count; i++)
        {
            if (allHelicopters[i].gameObject.activeSelf)
            {
                target = allHelicopters[i].gameObject.transform;
                return;
            }
        }
    }
}


