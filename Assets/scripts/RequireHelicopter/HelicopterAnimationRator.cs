using UnityEngine;


public class HelicopterAnimationRator : MonoBehaviour
{
    [SerializeField] private Animator rotorAnimator;
    [SerializeField] private string speedParameterName = "speed";
    [SerializeField] private float minSpeed = 0.5f; 
    [SerializeField] private float maxSpeed = 10f;
    
    private HelicopterMover _helicopterMover;

    private void Awake()
    {
        _helicopterMover = GetComponent<HelicopterMover>();
        
        if (rotorAnimator == null)
        {
            rotorAnimator = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        if (rotorAnimator == null || _helicopterMover == null) return;
        
        float magnitude = _helicopterMover.GetMagnitude();
        float animSpeed = Mathf.Lerp(minSpeed, maxSpeed, magnitude);
        
        rotorAnimator.SetFloat(speedParameterName, animSpeed);
    }
}
