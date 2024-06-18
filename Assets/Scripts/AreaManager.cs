using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public BoxCollider area;

    public int startpoint;
    public int endpoint;

    private void Awake()
    {
        area = GetComponent<BoxCollider>();
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.instance.spawner.SpawnPointChange(startpoint, endpoint);
        }

    }

}
