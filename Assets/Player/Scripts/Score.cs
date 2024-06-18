using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Score : IComparable<Score>
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
    public float surviveTime;
    public int totalScore;

    public int CompareTo(Score other)
    {
        return other.totalScore.CompareTo(totalScore);
    }
}
