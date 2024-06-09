using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipedSkills : MonoBehaviour
{
    public skillData skillData;
    public skillEntity[] skillList;

    private void Awake()
    {
        skillList = new skillEntity[6];

        skillList[0] = skillData.SkillList[1];
        skillList[1] = skillData.SkillList[2];
        skillList[5] = skillData.SkillList[0];

        //for (int i = 0; i < skillData.SkillList.Count; i++) 
        //{
        //    skillList[i] = skillData.SkillList[i];
        //}
    }

    public skillEntity Qskill()
    {
        return skillList[1];
    }

    public skillEntity Wskill()
    {
        return skillList[2];
    }

    public skillEntity Eskill()
    {
        return skillList[2];
    }

    public skillEntity Rskill()
    {
        return skillList[2];
    }

    public skillEntity LMouseSkill()
    {
        return skillList[2];
    }

    public skillEntity RMouseSkill()
    {
        return skillList[0];
    }
}
