using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : BaseEnemy
{
    [SerializeField] private ZombieAnimatorController _animatorController;

    [SerializeField] private Transform _model;
    [SerializeField] private Fliper _zomdieFliper;
    [SerializeField] private Transform _healthBar;

    [SerializeField] private GameObject _diedEffect;

    private void OnTriggerStay(Collider other)
    {
        Transform target;
        if (other.TryGetComponent<Player>(out var player)) target = other.transform;
        else return;
        

        if (_healthBar == null) return;

        var toTarget = target.position - _model.position;

        var healthBarScale = _healthBar.localScale;

        if (toTarget.x > _model.position.x)
        {
            _model.rotation = Quaternion.Euler(0, 180, 0);
            _zomdieFliper.SetFlip(false);
            healthBarScale.x = -Mathf.Abs(healthBarScale.x);
        }
        else if (toTarget.x < _model.position.x) 
        {
            _model.rotation = Quaternion.Euler(0, 0, 0);
            _zomdieFliper.SetFlip(true);
            _healthBar.localScale = new Vector3(-_healthBar.localScale.x, _healthBar.localScale.y, _healthBar.localScale.z);
            healthBarScale.x = Mathf.Abs(healthBarScale.x);
        }

        _healthBar.localScale = healthBarScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player)) _animatorController.OnWalking(true);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player)) _animatorController.OnWalking(false);
    }

    private protected override void OnDied()
    {
        Instantiate(_diedEffect, transform.position, Quaternion.identity);
    }
}
