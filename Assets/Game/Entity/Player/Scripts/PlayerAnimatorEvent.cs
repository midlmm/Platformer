using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorEvent : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    private void OnEndKick()
    {
        _playerInput.EndKick();
    }

    private void OnStartKick()
    {
        _playerInput.StartKick();
    }
}
