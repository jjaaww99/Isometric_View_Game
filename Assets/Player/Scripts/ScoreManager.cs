using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Score resultScore;
    public int killedEnemyCount;
    public int earnedGold;
    public int totalScore;
    public float surviveTime;
    public string scoreFilePath;
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
        }

        OnGameOver();

        scoreFilePath = Path.Combine(Application.streamingAssetsPath, "score.json");
    }

    private void Update()
    {
        if(GameManager.instance.gameState == GameState.Playing )
        {
            surviveTime += Time.deltaTime;
        }
    }

    private void ResetScores()
    {
        killedEnemyCount = 0;
        earnedGold = 0;
        totalScore = 0;
        surviveTime = 0;
    }

    public void OnGameOver()
    {
        resultScore = new Score(killedEnemyCount, earnedGold, totalScore, surviveTime);
        ResetScores();   
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(resultScore);
        File.WriteAllText(scoreFilePath, json);
        Debug.Log("Score saved to " + scoreFilePath);
    }
}
