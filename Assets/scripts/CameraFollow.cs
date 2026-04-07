using System;
using UnityEngine;

public static class HelicopterEvents
{
    public static Action<Transform> OnActiveHelicopterChanged;
}

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 cameraPosition = new Vector3(0f, 1f, -10f);
    [SerializeField] private float cameraSpeed = 3f;
    [SerializeField] private float maxWorldBoundY;
    [SerializeField] private float minWorldBoundY;

    private void OnEnable()
    {
        HelicopterEvents.OnActiveHelicopterChanged += SetTarget;
    }

    private void OnDisable()
    {
        HelicopterEvents.OnActiveHelicopterChanged -= SetTarget;
    }

    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }
        
        Vector3 targetPosition = target.position + cameraPosition;

        if (target.position.y > maxWorldBoundY || target.position.y < minWorldBoundY)
        {
            targetPosition.y = transform.position.y;
        }
        
        Vector3 finalPosition = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
        transform.position = finalPosition;

        Vector3 lookAtTarget = target.position;
        if (lookAtTarget.y > maxWorldBoundY)
        {
            lookAtTarget.y = target.position.y;
        }

        transform.LookAt(lookAtTarget + Vector3.forward * 10f);
    }

    private void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}


