using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimCon : MonoBehaviour
{
    public skillData skillData;

    public skillDataEntity[] EquipedSkills = new skillDataEntity[4];

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        for (int i = 0; i < EquipedSkills.Length; i++)
        {
            EquipedSkills[i] = skillData.SkillList[i];
        }
    }

    private void Update()
    {

        if(Input.GetKey(KeyCode.Q)) 
        {
            anim.SetTrigger(EquipedSkills[0].skillName);

            Debug.Log(EquipedSkills[0].skillName);
        }

    }
}
