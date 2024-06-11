using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrops : MonoBehaviour
{
    public static ItemDrops instance;
    public GameObject coin;

    int percent;

    public void CoinSpawn(Transform spawntransform)
    {
        percent = Random.Range(1, 101);

        if(percent <= 50)
        {
            Instantiate(coin, spawntransform);
        }
    }






}
