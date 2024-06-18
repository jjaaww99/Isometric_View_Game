using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score 
{
    public Score(int _killedEnemyCount, int _earnedGold, int _totalScore, float _surviveTime)
    {
        killedEnemyCount = _killedEnemyCount;
        earnedGold = _earnedGold;
        totalScore = _totalScore;
        surviveTime = _surviveTime;
    }

    public int killedEnemyCount;
    public int earnedGold;
    public int totalScore;
    public float surviveTime;
}
