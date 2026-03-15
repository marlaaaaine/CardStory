using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{   
    /// <summary>
    /// Animator component that plays the set animation
    /// </summary>
    [SerializeField] private Animator _animator;
    /// <summary>
    /// string holding the name of the animation parameter used to change currently playing animations
    /// </summary>
    private string _paramName;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _paramName = "IsRunning";
    }

    /// <summary>
    /// Set the animation currently playing using a bool 
    /// </summary>
    /// <param name="state"></param>
    public void SetAnimation(bool state)
    {
     _animator.SetBool(_paramName, state);   
    }
}
