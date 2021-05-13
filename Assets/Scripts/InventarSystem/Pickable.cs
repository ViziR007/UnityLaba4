using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Pickable : MonoBehaviour
{
    [SerializeField] private Item _item;

    public Item Item => _item;

    private SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _sprite.sprite = _item.Sprite;
    }
}
