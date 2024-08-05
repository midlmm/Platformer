using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Datas/Player Movements Data")]
public class PlayerMovementsData : ScriptableObject
{
    public float Speed => _speed;

    [SerializeField] private float _speed;
}
