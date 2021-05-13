using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventar : MonoBehaviour
{
    [SerializeField] private GameObject _invetarUI;
    [SerializeField] private KeyCode _key;

    [SerializeField] private ItemSlot[] _itemSlots;
    [SerializeField] private HeadSlot _headSlot;
    [SerializeField] private FootSlot _footSlot;
    [SerializeField] private BodySlot _bodySlot;
    [SerializeField] private SwordSlot _swordSlot;

    [SerializeField] private Image _dragEndDropItemImage;

    public event Action<Item> DragEndDropItemReleased;

    public bool isDragAndDropState => _dragEndDropItem != null; 

    private bool _isInventarShowing = false;

    private Item _dragEndDropItem = null;
    private CanvasScaler _canvasScaler;

    private void Awake()
    {
        _canvasScaler = GetComponentInParent<CanvasScaler>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            _isInventarShowing = !_isInventarShowing;
            if (_isInventarShowing)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }
        
    }

    public Item GetDragAndDropItem()
    {
        Item temp = _dragEndDropItem;
        ClearDragAndDropItem();
        return temp;
    }
    public void SetDropAndDragItem(Item item)
    {
        if (item != null)
        {
            _dragEndDropItem = item;
            _dragEndDropItemImage.sprite = item.Sprite;
            _dragEndDropItemImage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            ClearDragAndDropItem();
        }
    }

    public Item QuickSetEquipment(Item item)
    {
        if (item is HeadItem)
        {
            HeadItem head = item as HeadItem;
            HeadItem old = _headSlot.ChangeItem(head);
            return old;
        }
        else if(item is FootItem)
        {
            FootItem foot = item as FootItem;
            FootItem old = _footSlot.ChangeItem(foot);
            return old;
        }
        else if (item is BodyItem)
        {
            BodyItem body = item as BodyItem;
            BodyItem old = _bodySlot.ChangeItem(body);
            return old;
        }
        else if(item is SwordItem)
        {
            SwordItem sword = item as SwordItem;
            return _swordSlot.ChangeItem(sword);
        }
        return item;
    }
    
    public bool TryAddItem(Item item)
    {
        if (item is BodyItem)
        {
           if(_bodySlot.TrySetItem(item as BodyItem))
            {
                return true;
            }
        }

        if (item is HeadItem)
        {
            if (_headSlot.TrySetItem(item as HeadItem))
            {
                return true;
            }
        }

        if (item is FootItem)
        {
           if(_footSlot.TrySetItem(item as FootItem))
            {
                return true;
            }
        }

        else if (item is SwordItem)
        {
            if (_swordSlot.TrySetItem(item as SwordItem) == true)
            {
                return true;
            }
        }

        for (int i = 0; i < _itemSlots.Length; i++)
        {
            if (_itemSlots[i].TrySetItem(item) == true)
            {
                return true;
            }
        }

        return false;
    }

    private void ClearDragAndDropItem()
    {
        _dragEndDropItem = null;
        _dragEndDropItemImage.color = new Color(1, 1, 1, 0);
    }

    private void Show()
    {
        _invetarUI.gameObject.SetActive(true);
    }
    private void Hide()
    {
        _invetarUI.gameObject.SetActive(false);
    }


}
