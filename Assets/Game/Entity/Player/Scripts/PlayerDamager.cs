using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamager : MonoBehaviour
{
    [SerializeField] private Fliper _playerFliper;
    [SerializeField] private Vector2 _colliderOffset;
    [SerializeField] private float _colliderRadius;

    [SerializeField] private GameObject _prefabFireball;

    [SerializeField] private float _fireballSpeed;

    [SerializeField] private int _hitDamage;
    [SerializeField] private int _kickDamage;
    [SerializeField] private int _fireballDamage;

    [SerializeField] private float _hitForce;
    [SerializeField] private float _kickForce;
    [SerializeField] private float _fireballForce;

    [SerializeField] private GameObject _damageEffect;

    [SerializeField] RecoilShake _recoilShake;

    public void Hit()
    {
        Vector3 newForce = new Vector3();
        newForce.x = _playerFliper.IsFlip ? -_hitForce : _hitForce;
        Hit(newForce, _hitDamage);
    }

    public void Kick()
    {
        Vector3 newForce = new Vector3();
        newForce.x = _playerFliper.IsFlip ? -_kickForce : _kickForce;
        Hit(newForce, _kickDamage);
    }

    public void Fireball()
    {
        Vector3 newForce = new Vector3();
        newForce.x = _playerFliper.IsFlip ? -_fireballForce : _fireballForce;

        Vector2 newOffset = new Vector2(transform.position.x, transform.position.y);
        newOffset.x = _playerFliper.IsFlip ? newOffset.x + _colliderOffset.x : newOffset.x - _colliderOffset.x;
        newOffset.y = _colliderOffset.y + transform.position.y;

        var fireball = Instantiate(_prefabFireball);
        fireball.transform.position = newOffset;
        fireball.GetComponent<Fireball>().Initialized(newForce, _fireballDamage, _fireballSpeed, _playerFliper.IsFlip);

        _recoilShake.ScreenShake();
    }

    private void Hit(Vector3 force, int damage)
    {
        Vector2 newOffset = new Vector2(transform.position.x, transform.position.y);
        newOffset.x = _playerFliper.IsFlip ? newOffset.x + _colliderOffset.x : newOffset.x - _colliderOffset.x;
        newOffset.y = _colliderOffset.y + transform.position.y;

        Collider[] colliders = Physics.OverlapSphere(newOffset, _colliderRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.GetType() != typeof(SphereCollider) && collider.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.Damage(damage, force);
                Instantiate(_damageEffect, newOffset, Quaternion.identity);
            }
        }
        _recoilShake.ScreenShake();
        
    }

    //private void OnDrawGizmos()
    //{
    //    Vector2 newOffset = new Vector2(transform.position.x, transform.position.y);
    //    newOffset.x = _playerFliper.IsFlip ? newOffset.x + _colliderOffset.x : newOffset.x - _colliderOffset.x;
    //    newOffset.y = _colliderOffset.y + transform.position.y;

    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(newOffset, _colliderRadius);
    //}
}
