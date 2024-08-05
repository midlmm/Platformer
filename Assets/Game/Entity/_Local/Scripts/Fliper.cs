using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fliper : MonoBehaviour
{
    //False = right, True = left
    public Action<bool> OnFlip;
    public bool IsFlip { get; private set; }

    public void SetFlip(bool direction)
    { 
        OnFlip?.Invoke(direction);
        IsFlip = direction;
    }
}
