using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private HealthBarView _healthBarView;
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private GameObject _mainBones;
    [SerializeField] private ConfigurableJoint[] _configurableJoints;

    [SerializeField] private float _delayDestroy;

    private Vector3 _force;

    private void Start()
    {
        _healthBarView.DisplayHealths(_health.Healths);
    }

    public void Damage(int healths, Vector3 force)
    {
        Hit(force);
        _health.SetHealths(_health.Healths - healths);
        _healthBarView.DisplayHealths(_health.Healths);
    }

    private void Hit(Vector3 force)
    {
        _rigidbody.AddForce(force, ForceMode.Impulse);
        _force = force;
    }

    private void Died()
    {
        if (_health.IsDied) return;
        foreach (var item in _configurableJoints)
        {
            Destroy(item);
            _force.y = _force.x;
            item.GetComponent<Rigidbody>().AddForce(_force, ForceMode.Impulse);
            item.transform.SetParent(transform, true);
        }
        Destroy(_mainBones);
        StartCoroutine(DelayDestroy());
        OnDied();
    }

    private protected abstract void OnDied();

    private IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(_delayDestroy);
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        _health.OnDied += Died;
    }

    private void OnDisable()
    {
        _health.OnDied -= Died;
    }
}
