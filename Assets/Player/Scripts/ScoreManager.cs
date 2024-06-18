using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Score currentScore;
    public List<Score> scoreList = new List<Score>();
    public ScoreList saveScore = new ScoreList();
    public string scoreFilePath;

    public int killedEnemyCount;
    public int earnedGold;
    public float surviveTime;
    public int totalScore;

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

        scoreFilePath = Path.Combine(Application.streamingAssetsPath, "scores.json");

        LoadScores();
        ResetScores();
    }

    private void Update()
    {
        if (GameManager.instance.gameState == GameState.Playing)
        {
            surviveTime += Time.deltaTime;
        }
    }

    public void OnGameOver()
    {
        currentScore = new Score(killedEnemyCount, earnedGold, totalScore, surviveTime);
        scoreList.Add(currentScore);
        SaveScores();
        ResetScores();
    }

    private void ResetScores()
    {
        killedEnemyCount = 0;
        earnedGold = 0;
        totalScore = 0;
        surviveTime = 0;
    }

    private void SaveScores()
    {
        scoreList.Sort();

        saveScore.scores = scoreList;

        string json = JsonUtility.ToJson(saveScore);

        File.WriteAllText(scoreFilePath, json);
        Debug.Log("Scores saved to " + scoreFilePath);
    }

    private void LoadScores()
    {
        if (File.Exists(scoreFilePath))
        {
            string json = File.ReadAllText(scoreFilePath);

            scoreList = JsonUtility.FromJson<List<Score>>(json);
            saveScore.scores = scoreList;
        }
        else
        {
            Debug.Log("No scores file found, starting with an empty list.");
        }
    }
}
