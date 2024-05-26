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


    public skillDataEntity Qskill;
    public skillDataEntity Wskill;
    public skillDataEntity Eskill;

    private void Awake()
    {
        Qskill = skilldata.SkillList[0];
        Wskill = skilldata.SkillList[1];
        Eskill = skilldata.SkillList[2];
    
        skills[1] = Qskill;
        skills[0] = Wskill;
        skills[2] = Eskill;
        
    }


    private void Start()
    {
        
    }
    private void Update()
    {
        for(int i = 0; i < 3; i++)
        {
            images[i] = transform.GetChild(i).GetComponent<Image>();

            images[i].sprite = Resources.Load<Sprite>(skills[i].skillIcon);
        }
        
    }
}
