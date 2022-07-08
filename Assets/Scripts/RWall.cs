using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RWall : MonoBehaviour
{
    private GameObject ball;
    public float Force;
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * Force);
    }
}
