using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    JWPlayerController player;
    MonsterStateManager monster;
    public PoolManager pool;

    void Awake()
    {
        instance = this;
    }


    public GameObject coin;

    int percent;

    public void CoinSpawn(Vector3 position)
    {
        percent = Random.Range(1, 101);
        if (percent <= 80)
        {
            Instantiate(coin, position, Quaternion.identity);
        }

    }





}
