using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArmorItem : Item
{
    [SerializeField] protected float _defence;
    public float Defence => _defence;
}
