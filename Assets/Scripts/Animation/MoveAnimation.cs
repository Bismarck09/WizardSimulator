using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void StartAnimation(Vector3 direction)
    {
        if (direction.z != 0)
            SwitchAllAnimations(new[] { "Running" }, new[] { "RunningRight", "RunningLeft" });
        else if (direction.x > 0)
            SwitchAllAnimations(new[] { "RunningRight" }, new[] { "Running", "RunningLeft" });
        else if (direction.x < 0)
            SwitchAllAnimations(new[] { "RunningLeft" }, new[] { "Running", "RunningRight" });
        else
            SwitchAllAnimations(new[] { "" }, new[] { "Running", "RunningRight", "RunningLeft" });
    }

    private void SwitchAllAnimations(string[] enableAnimations, string[] disableAnimations)
    {
        AnimationsStatesSwitch(enableAnimations, true);
        AnimationsStatesSwitch(disableAnimations, false);
    }

    private void AnimationsStatesSwitch(string[] animation, bool state)
    {
        for (int i = 0; i < animation.Length; i++)
        {
            foreach (var parametr in _animator.parameters)
            {
                if (parametr.name == animation[i])
                {
                    _animator.SetBool(animation[i], state);
                    break;
                }
            }
        }
    }
}
