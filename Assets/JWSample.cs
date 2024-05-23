using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class JWSample : MonoBehaviour
{
    public skillData skilldata;

    skillDataEntity[] skills = new skillDataEntity[3];

    Image[] images = new Image[3];

    private void Awake()
    {
        skillDataEntity Qskill = skilldata.SkillList[0];
        skillDataEntity Wskill = skilldata.SkillList[1];
        skillDataEntity Eskill = skilldata.SkillList[2];
    
        skills[1] = Qskill;
        skills[0] = Wskill;
        skills[2] = Eskill;
        
        for(int i = 0; i < 3; i++)
        {
            images[i] = transform.GetChild(i).GetComponent<Image>();

            images[i].sprite = Resources.Load<Sprite>(skills[i].skillIcon);
        }
    }


    private void Start()
    {
        
    }

}
