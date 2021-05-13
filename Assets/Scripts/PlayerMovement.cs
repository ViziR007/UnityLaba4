using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _force = 1f;

    private Rigidbody2D _rigibody;

    private float _horizontalAxis;

    private const string HorizontalAxisName = "Horizontal";

    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalAxis = Input.GetAxisRaw(HorizontalAxisName);
    }

    private void FixedUpdate()
    {
        _rigibody.AddForce(new Vector2(_force * _horizontalAxis, 0));   
    }

}
