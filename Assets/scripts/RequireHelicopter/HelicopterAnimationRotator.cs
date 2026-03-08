using UnityEngine;

public class HelicopterAnimationRotator : MonoBehaviour
{
    [SerializeField] private Animator rotorAnimator;
    [SerializeField] private float minSpeed = 0.5f; 
    [SerializeField] private float maxSpeed = 3f;
    
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
        float animSpeed = Mathf.Lerp(minSpeed, maxSpeed, Mathf.Clamp01(magnitude));
        rotorAnimator.SetFloat("speed", animSpeed);
    }
}
