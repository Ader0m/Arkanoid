using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject ball;
    public delegate void GameOver();
    public static event GameOver gameOverEvent;

    private void Start()
    {
        Instantiate(platform, new Vector3(0, 1, -1), Quaternion.identity);
        Instantiate(ball, new Vector3(0, 1.484f, -1), Quaternion.identity);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            gameOverEvent();
        }
        else
        {
            Destroy(collision.gameObject);
        }
       
    }
}
