using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public JWPlayerController playerController;
    public PlayerStatus player;
    public MonsterStateManager monster;
    public PoolManager pool;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
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

    public void DamageToPlayer(int damage)
    {
        player.currentHp -= damage;
    }

    public void DamageToEnemy(MonsterStateManager _monster, int damage)
    {
        MonsterStateManager monster = _monster;

        monster.currentHp -= damage;
    }
}
