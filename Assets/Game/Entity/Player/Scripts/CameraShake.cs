using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float _amount;
    [SerializeField] private float _speed;

    private Vector3 _startPosition;
    private float distance;
    private Vector3 rotation;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        distance += (transform.position - _startPosition).magnitude;

        _startPosition = transform.position;
        rotation.z = Mathf.Sin(distance * _speed) * _amount;
        transform.localEulerAngles = rotation;
    }
}
