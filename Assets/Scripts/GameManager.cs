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
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
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
