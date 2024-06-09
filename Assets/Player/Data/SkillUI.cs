using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    public PlayerEquipedSkills skillData;
    public skillEntity[] equpiedSkills;
    public Image[] skillIcons;

    private void Start()
    {
        equpiedSkills = skillData.skillList;

        skillIcons = new Image[6];



        for(int i = 0; i < equpiedSkills.Length; i++)
        {
            skillIcons[i] = transform.GetChild(i).GetChild(0).GetComponent<Image>();
        
            if(equpiedSkills[i].skillIcon != null)
            {
                skillIcons[i].sprite = Resources.Load<Sprite>(equpiedSkills[i].skillIcon);
            }
        }
    }
}
