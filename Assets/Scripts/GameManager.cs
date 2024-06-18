using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState { Playing, Idle }

public class GameManager : MonoBehaviour
{
    public GameState gameState;

    public static GameManager instance;
    public JWPlayerController playerController;
    public PlayerStatus player;
    public PoolManager pool;
    public GameObject coin;

    void Awake()
    {
        gameState = new GameState();
        gameState = GameState.Idle;
        instance = this;
        DontDestroyOnLoad(this);
    }

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
