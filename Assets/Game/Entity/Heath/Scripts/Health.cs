using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Action OnDied;
    public int Healths { get; private set; }
    public int MaxHealths => _maxHealths;

    public bool IsDied { get; private set; }

    [SerializeField] private int _maxHealths;

    private void Awake()
    {
        SetHealths(MaxHealths);
    }

    public void SetHealths(int Value)
    {
        Healths = Value;
        ChekingHealths();
    }

    private void ChekingHealths()
    {
        if (Healths > 0) return;

        Healths = 0;
        OnDied?.Invoke();
        IsDied = true;
    }
}
