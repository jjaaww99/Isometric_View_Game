using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    private float spawnTimer;

    public int startspawn = 1;
    public int endspawn = 7;

    int num;
    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    

    private void Start()
    {
        num = GameManager.instance.pool.prefablength;
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > 1f)
        {
            spawnTimer = 0;
            Spawn();
        }
    }

    

    private void Spawn()
    {
        UnityEngine.GameObject enemy = GameManager.instance.pool.Get(Random.Range(0, num));
        if (enemy != null)
        {
            enemy.transform.position = spawnPoint[Random.Range(startspawn, endspawn)].position;
        }
    }

    public void SpawnPointChange(int start, int end)
    {
        startspawn = start;
        endspawn = end;
    }

}
