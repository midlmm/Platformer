using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private PlayerMovementsData _startMovementsData;
    [SerializeField] private Fliper _playerFliper;
    [SerializeField] private Transform _playerModel;
    [SerializeField] private float _delay;
    [SerializeField] private GameObject _smokeEffect;
    [SerializeField] private Vector3 _offset;

    private PlayerMovementsData _currentMovementsData;
    private Rigidbody _rigidbody;
    private Vector2 _direction;

    private float _currentDelay;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentMovementsData = _startMovementsData;
    }

    public void Walking(float value)
    {
        _rigidbody.velocity = new Vector3(value * _currentMovementsData.Speed, _rigidbody.velocity.y, _rigidbody.velocity.z);
        if(value != 0)
        {
            if (_currentDelay <= 0)
            {
                Instantiate(_smokeEffect, transform.position + _offset, Quaternion.identity);
                _currentDelay = _delay;
            }
            else _currentDelay -= Time.deltaTime;
        }
    }

    private void Flip(bool direction)
    {
        int angle = 0;

        angle = direction ? -90 : 90;
        
        _playerModel.rotation = Quaternion.Euler(_playerModel.eulerAngles.x, angle, _playerModel.eulerAngles.z);
    }

    private void OnEnable()
    {
        _playerFliper.OnFlip += Flip;
    }

    private void OnDisable()
    {
        _playerFliper.OnFlip -= Flip;
    }
}
