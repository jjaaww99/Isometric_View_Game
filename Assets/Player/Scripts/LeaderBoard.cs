using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class LeaderBoard : MonoBehaviour
{
    public List<Score> scores = new List<Score>();

    private string leaderboardFilePath;

    private void Awake()
    {
        leaderboardFilePath = Path.Combine(Application.streamingAssetsPath, "leaderboard.json");
    }
}
