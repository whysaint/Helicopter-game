using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

    [Header("Input")]
    public float touchSensitivity = 0.18f;

    [Header("Horizontal Limits")]
    public float minRotY = -60f;
    public float maxRotY = 60f;
    public bool useRotationLimits = true;

    [Header("Inertia")]
    public float inertiaDecay = 5f;
    public float inertiaScale = 0.4f;

    [Header("Camera Animation")]
    public bool autoRotate = true;
    public float autoRotateSpeed = 1f;

    private float _rotY;
    private float _velocity;
    private float _autoDirection = 1f;
    private Vector3 _offset;
    private bool _isDragging;
    private float _lastInputDelta;

    private void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target not assigned.");
            enabled = false;
            return;
        }

        _offset = target.position - transform.position;
        _rotY = transform.eulerAngles.y;
    }

    private void LateUpdate()
    {
        float inputDelta = 0f;
        _isDragging = false;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                _isDragging = true;
                
                inputDelta = touch.deltaPosition.x * touchSensitivity;

                _rotY += inputDelta;
                _lastInputDelta = inputDelta;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                _velocity = _lastInputDelta * inertiaScale;
            }
        }

        if (!_isDragging && Mathf.Abs(_velocity) > 0.001f)
        {
            _rotY += _velocity;
            _velocity = Mathf.Lerp(_velocity, 0f, inertiaDecay * Time.deltaTime);
        }
        
        if (!_isDragging && autoRotate)
        {
            _rotY += autoRotateSpeed * _autoDirection * Time.deltaTime;

            if (useRotationLimits)
            {
                if (_rotY >= maxRotY)
                {
                    _rotY = maxRotY;
                    _autoDirection = -1f;
                    _velocity = 0f;
                }
                else if (_rotY <= minRotY)
                {
                    _rotY = minRotY;
                    _autoDirection = 1f;
                    _velocity = 0f;
                }
            }
        }

        if (useRotationLimits)
        {
            float clamped = Mathf.Clamp(_rotY, minRotY, maxRotY);
            if (clamped != _rotY) _velocity = 0f;
            _rotY = clamped;
        }

        Quaternion rotation = Quaternion.Euler(0, _rotY, 0);
        transform.position = target.position - (rotation * _offset);
        transform.LookAt(target);
    }
}