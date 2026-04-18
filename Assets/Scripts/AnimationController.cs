using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    /// <summary> Animator component that plays the set animation  </summary>
    [SerializeField] private Animator _animator;
    /// <summary> string for the current animation state of the player </summary>
    private PlayerStateTypes _currentState;

    /// <summary> the types of player animations </summary>
    public enum PlayerStateTypes
    {
        None,
        Run,
        Idle
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Set the animation currently playing using the enum with the types
    /// of player animations only if the _currentState is different from the passed in one 
    /// </summary>
    /// <param name="state"> the animation state we want to set </param>
    public void SetAnimation(PlayerStateTypes playerState)
    {
        if (_currentState == playerState) return;
        _currentState = playerState;
        _animator.SetTrigger(playerState.ToString());
    }
}
