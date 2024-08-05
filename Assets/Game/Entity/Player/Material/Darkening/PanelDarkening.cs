using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDarkening : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void OnDark(bool isActive)
    {
        _animator.SetBool("IsDark", isActive);
    }
}
