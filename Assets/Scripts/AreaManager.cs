using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public BoxCollider area;
    public Spawner spawner;

    public int areapoint;

    private void Awake()
    {
        area = GetComponent<BoxCollider>();
        spawner = GetComponent<Spawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            spawner.spawnStartPoint = spawner.spawnPointenable;
            spawner.spawnPointenable = areapoint;
        }
    }

}
