using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject Block;
    [SerializeField] private float SpawnTime;
    
    private float nextSpawnTime;
    private float lastSpawnPoint;
    private float solvingSpawnPoint;
    public float leftBarier;
    public float rightBarier;
    

    void Start()
    {
        nextSpawnTime = Time.time;
    }

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            solvingSpawnPoint = Random.Range(leftBarier, rightBarier);
            

            if (Mathf.Abs(solvingSpawnPoint - lastSpawnPoint) < 0.2)
            {
                solvingSpawnPoint += solvingSpawnPoint > 0 ? 0.2f : -0.2f;
            }
            Mathf.Clamp(solvingSpawnPoint, leftBarier, rightBarier);
            Instantiate(Block, new Vector3(solvingSpawnPoint, transform.position.y, -1), Quaternion.identity);
            nextSpawnTime = Time.time + 1 + SpawnTime;
        }
    }
}
