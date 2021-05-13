using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu( fileName ="New item", menuName = "Inventar/Item", order = 1)]
public class Item : ScriptableObject
{
    [SerializeField] private Sprite _sprite;

    public Sprite Sprite => _sprite;
}
