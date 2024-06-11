using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager01 : MonoBehaviour
{
    public static GameManager01 instance;
    JWPlayerController player;
    MonsterStateManager monster;

    public GameObject coinPrefab;

    public PoolManager pool;

    void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
    }
}
