using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float maxX;
    [SerializeField] private float minX;
    private Rigidbody2D _rb;
    private Vector2 lastMove = Vector2.zero;


    void Start()
    {
        SwipeDetection.SwipeEvent += OnSwipe;
        _rb = GetComponent<Rigidbody2D>();       
    }

    void FixedUpdate()
    {       
        if (transform.position.x > maxX || transform.position.x < minX)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), 1, -1);
        }
    }

    private void OnSwipe(Vector2 position)
    {                                            
        if (lastMove != position)
        {
            _rb.velocity = new Vector2(0f, 0f);
        }
        lastMove = position;
        transform.Translate(position * speed);               
    }

    private void OnDestroy()
    {
        SwipeDetection.SwipeEvent -= OnSwipe;
    }
}
