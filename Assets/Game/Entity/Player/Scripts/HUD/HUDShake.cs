using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HUDShake : MonoBehaviour
{
    public float _shakeIntensity = 0.1f;

    private bool _isShake;
    private Vector3 _initialPosition;

    private void Start()
    {
        _initialPosition = transform.localPosition;
    }

    private void Update()
    {
        if (_isShake)
        {
            float offsetY = Random.Range(-_shakeIntensity, _shakeIntensity);

            transform.localPosition = _initialPosition + new Vector3(0, offsetY, 0);
        }
        else
        {
            transform.localPosition = _initialPosition;
        }
    }

    public void OnShake(bool isActive)
    {
        _isShake = isActive; 
    }
}

