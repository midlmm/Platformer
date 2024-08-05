using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animated : MonoBehaviour
{
    [SerializeField] private PhysicMaterial _zeroFriction;
    [SerializeField] private PhysicMaterial _defaultFriction;

    [SerializeField] private Collider _leftCollider;
    [SerializeField] private Collider _rightCollider;

    public void SetLeftFriction()
    {
        _leftCollider.material = _defaultFriction;
        _rightCollider.material = _zeroFriction;
    }

    public void SetRightFriction()
    {
        _rightCollider.material = _defaultFriction;
        _leftCollider.material = _zeroFriction;
    }
}
