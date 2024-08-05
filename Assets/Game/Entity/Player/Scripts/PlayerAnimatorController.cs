using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void OnWalking(bool isActive)
    {
        _animator.SetBool("IsWalking", isActive);
    }

    public void OnHit()
    {
        _animator.SetTrigger("Hit");
    }

    public void OnKick()
    {
        _animator.SetTrigger("Kick");
    }
}
