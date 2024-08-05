using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private GameObject _boomEffect;

    private Vector3 _force;
    private int _damage;
    private float _speed;
    private bool _direction;

    public void Initialized(Vector3 force, int damage, float speed, bool direction)
    {
        _force = force;
        _damage = damage;
        _speed = speed;
        _direction = direction;
    }

    private void Update()
    {
        _speed = _direction ? -Mathf.Abs(_speed) : Mathf.Abs(_speed);
        transform.position = new Vector2(transform.position.x + _speed * Time.deltaTime, transform.position.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetType() != typeof(SphereCollider) && other.transform.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.Damage(_damage, _force);
            var effect = Instantiate(_boomEffect, transform.position, Quaternion.identity, null);

            Destroy(gameObject);
        }
    }
}
