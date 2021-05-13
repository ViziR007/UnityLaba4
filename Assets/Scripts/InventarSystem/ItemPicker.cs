using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    [SerializeField] private Inventar _inventar;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.TryGetComponent(out Pickable pickable))
        {
            _inventar.TryAddItem(pickable.Item);
            Destroy(collider.gameObject);
        }
    }
}
