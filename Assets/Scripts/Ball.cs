using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float maxVelocity;
    [SerializeField] private float sideForce;
    private GameObject platform;
    private Rigidbody2D _rb;
    private bool dontShoot;
    private Vector3 platformPosition;
    public float ShootForce;
    

    void Start()
    {
        platform = GameObject.FindObjectOfType<Platform>().gameObject;
        dontShoot = true;
        StartButton.ShootEvent += ShootMe;
        _rb = GetComponent<Rigidbody2D>();
    }

    void ShootMe()
    {
        dontShoot = false;
        _rb.AddForce(new Vector2(0, ShootForce));
    }
    
    void FixedUpdate()
    {        
        if (dontShoot)
        {
            platformPosition = new Vector3(platform.transform.position.x, platform.transform.position.y + 0.437f, -1);
            this.transform.position = platformPosition;
        }
        if (_rb.velocity.magnitude >= maxVelocity)
        {
            _rb.velocity = maxVelocity * _rb.velocity.normalized;
        }
    }

    private void OnDestroy()
    {
        StartButton.ShootEvent -= ShootMe;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Vector2 ballPosition = this.transform.position;
            Vector2 platformPosition = collision.gameObject.transform.position;

            Vector2 point = ballPosition - platformPosition;

            _rb.AddForce(new Vector2(point.x * sideForce, 0));
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") && dontShoot)
        {
            
            
        }
    }
}
