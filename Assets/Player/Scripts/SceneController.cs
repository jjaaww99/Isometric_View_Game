using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneController instance;

    const int startSceneIndex = 0;
    const int recordSceneIndex = 1;
    const int gameSceneIndex = 2;

    public static SceneController Instance
    { get { return instance; } }

    private void Awake()
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
    }

    public void ToPlayScene()
    {
        GameManager.instance.gameState = GameState.Playing;
        SceneManager.LoadScene(2);
    }

    public void ToRecordRoomScene()
    {
        GameManager.instance.gameState = GameState.Idle;
        SceneManager.LoadScene(1);
    }
    public void ToStartScene()
    {
        GameManager.instance.gameState = GameState.Idle;
        SceneManager.LoadScene(0);
    }

}
