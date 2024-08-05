using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void OnWalking(bool isActive)
    {
        _animator.SetBool("IsWalk", isActive);
    }
}
