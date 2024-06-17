using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public skillData skillData;
    public skillEntity[] skillList;
    public playerStat playerStat;
    public PlayerStatusEntity[] playerStatus;

    public int level;
    public int maxHp;
    public int currentHp;
    public int maxRage;
    public int currentRage;
    public int str;
    public int dex;
    public int maxExp;
    public int currentExp;

    private void Awake()
    {
        skillList = new skillEntity[skillData.SkillList.Count];
        playerStatus = playerStat.playerData.ToArray();

            
        skillList[0] = skillData.SkillList[1];
        skillList[1] = skillData.SkillList[2];
        skillList[2] = skillData.SkillList[2];
        
        level = 1;
        str = playerStatus[level - 1].str;
        dex = playerStatus[level - 1].dex;
        maxHp = playerStatus[level - 1].playerHp;
        currentHp = maxHp;
        maxRage = playerStatus[level - 1].playerRage;
        currentRage = maxRage;
        maxExp = playerStatus[level - 1].maxExp;
        currentExp = 0;
    }

    private void Update()
    {
        if (currentExp <= maxExp)
        {
            LevelUP();
        }
    }

    public void LevelUP()
    {
        level++;
        str = playerStatus[level - 1].str;
        dex = playerStatus[level - 1].dex;
        maxHp = playerStatus[level - 1].playerHp;
        currentHp = maxHp;
        maxRage = playerStatus[level - 1].playerRage;
        currentRage = maxRage;
        maxExp = playerStatus[level - 1].maxExp;
        currentExp = 0;
    }

    public int Damage(int Multiplier)
    {
        int RandomDivider = Random.Range(90, 110);
        return str * Multiplier / RandomDivider;
    }
}
