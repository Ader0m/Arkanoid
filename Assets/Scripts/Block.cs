using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private float maxVelocity;
    private Rigidbody2D _rb;
    

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_rb.velocity.magnitude >= maxVelocity)
        {
            _rb.velocity = maxVelocity * _rb.velocity.normalized;
        }
        
    }   

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ball"))
        {
            Score.AddScore(1);
            Destroy(this.gameObject);
        }
    }


}
