using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Slot<TItem> : MonoBehaviour, IPointerClickHandler where TItem : Item
{
    [SerializeField] protected Image _image;
    public bool IsFree => _item == null;
    public TItem Item => _item;

    protected TItem _item;
    protected Inventar _inventar;


    private void Awake()
    {
        _inventar = FindObjectOfType<Inventar>();
    }


    public TItem ChangeItem(TItem item)
    {
        TItem old = _item;
        _item = item;
        ShowNewImage(_item.Sprite);
        return old;
    }

    public  bool TrySetItem(TItem item)
    {
        if (IsFree)
        {
            _item = item;
            ShowNewImage(item.Sprite);
            return true;
        }
        return false;
    }

    public void ShowNewImage(Sprite sprite)
    {
        _image.sprite = sprite;
        _image.color = new Color(1, 1, 1, 1);
    }

    public void ClearSlot()
    {
        _image.color = new Color(1, 1, 1, 0);
        _item = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (IsFree == false)
            {
                TItem item = (TItem)_inventar.QuickSetEquipment(_item);
                if (item != null)
                {
                    _item = item;
                    ShowNewImage(item.Sprite);
                }
                else ClearSlot();
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (_inventar.isDragAndDropState == false)
            {
                _inventar.SetDropAndDragItem(_item);
                ClearSlot();
            }
            else
            {
                Item item = _inventar.GetDragAndDropItem();
                if (item is TItem)
                {
                    _inventar.SetDropAndDragItem(ChangeItem(item as TItem));
                }
                else
                {
                    _inventar.SetDropAndDragItem(item);
                }
            }
        }
    }

}
