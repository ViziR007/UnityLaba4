using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class DragAndDropItem : MonoBehaviour
{
    private Canvas _canvas;
    private CanvasScaler _canvasScaler;
    private RectTransform _rectTransform;

    private Vector2 _position;

    private void Awake()
    {
        _canvasScaler = GetComponentInParent<CanvasScaler>();
        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
    }

    // Update is called once per frame
    private void Update()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, Input.mousePosition, _canvas.worldCamera, out _position);
        transform.position = _canvas.transform.TransformPoint(_position);
    }
}
