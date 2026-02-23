using System;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform startPos;

    public float rotSpeedKeyboard = 90f;
    public float rotSpeedMouse = 270f;
    public float rotSpeedTouch = 270f;
    
    public float minRotY = -30f;
    public float maxRotY = 60f;
    public bool useRotationLimits = true;

    private float _rotY;
    private Vector3 _offset;

    private void Start()
    {
        _rotY = transform.eulerAngles.y;
        _offset = target.position - transform.position;
        transform.position = startPos.position;
    }

    private void LateUpdate()
    {
        float horInput = Input.GetAxis("Horizontal");
        float mouseX = Input.GetAxis("Mouse X");
        float touchDeltaX = 0f;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                touchDeltaX = touch.deltaPosition.x;
            }
        }

        _rotY += (horInput * rotSpeedKeyboard + mouseX * rotSpeedMouse * 3 + touchDeltaX * rotSpeedTouch * Time.deltaTime) * Time.deltaTime;

        if (useRotationLimits)
        {
            _rotY = Mathf.Clamp(_rotY, minRotY, maxRotY);
        }

        Quaternion rotation = Quaternion.Euler(0, _rotY, 0);
        transform.position = target.position - (rotation * _offset);
        transform.LookAt(target);
    }
}