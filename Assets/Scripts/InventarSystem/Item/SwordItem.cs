using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Sword", menuName = "Inventar/Sword", order = 1)]
public class SwordItem : Item
{
    [SerializeField] private float _damage;

    public float Damage => _damage;
}
