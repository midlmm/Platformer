using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RecoilShake : MonoBehaviour
{
    [SerializeField] private CinemachineImpulseSource _impulseSource;

    public void ScreenShake()
    {
        _impulseSource.GenerateImpulse();
    }

}
