using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class skillDataEntity 
{
    public int skillId;
    public string skillName;
    public int skillType;
    public int targetingType;
    public int hitType;
    public int rageUseType;
    public int rageAmount;
    public int useType;
    public string skillIcon;
    public GameObject effect;
    public string skillDesc;
}
