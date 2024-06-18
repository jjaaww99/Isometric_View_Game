using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState { Idle, Playing }

public class GameManager : MonoBehaviour
{
    public GameState gameState;

    public static GameManager instance;
    public JWPlayerController playerController;
    public PlayerStatus player;
    public PoolManager pool;
    public CoinPool coinPool;
    public Spawner spawner;
    void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<JWPlayerController>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        pool = GameObject.FindGameObjectWithTag("PoolManager").GetComponent<PoolManager>();
        coinPool = GameObject.FindGameObjectWithTag("CoinPool").GetComponent<CoinPool>();
        spawner =  GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();

        if (instance == null)
        {
            instance = this;
        }
    }

    int percent;

    public void CoinSpawn(Vector3 position)
    {
        percent = Random.Range(1, 101);
        if (percent <= 80)
        {
            coinPool.ActivateCoin(position);
        }
    }

    private bool playerInitialized = false;

    private void Update()
    {
        if (gameState == GameState.Playing)
        { 
            ScoreManager.instance.surviveTime += Time.deltaTime;
            
            if(!playerInitialized)
            {
                InitializePlayer();
                playerInitialized = true;
            }
        }

        Debug.Log(gameState.ToString());
    }

    private void InitializePlayer()
    {
        playerController = FindObjectOfType<JWPlayerController>();
        if (playerController != null)
        {
            player = playerController.GetComponent<PlayerStatus>();
        }
    }
}
