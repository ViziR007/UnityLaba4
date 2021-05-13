using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Inventar _inventar;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left && _inventar.isDragAndDropState)
        {
            _inventar.GetDragAndDropItem();
            Debug.Log("Drop");
        }

    }
}
