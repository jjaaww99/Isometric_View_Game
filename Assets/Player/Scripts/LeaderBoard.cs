using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using TMPro;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

[System.Serializable]
public class LeaderBoard : MonoBehaviour
{
    public List<Score> scores;
    public ScoreDisplay[] display;

    private void Start()
    {
        display = GetComponentsInChildren<ScoreDisplay>();
    }

    private void Update()
    {
        scores = ScoreManager.instance.scoreList;
        ShowScore();
    }

    public void ShowScore()
    {
        int maxLength = Mathf.Min(scores.Count, display.Length);

        for (int i = 0; i < maxLength; i++)
        {
            display[i].scoreTexts[0].text = scores[i].killedEnemyCount.ToString();
            display[i].scoreTexts[1].text = scores[i].earnedGold.ToString();
            display[i].scoreTexts[2].text = scores[i].surviveTime.ToString();
            display[i].scoreTexts[3].text = scores[i].totalScore.ToString();
        }
    }
}
