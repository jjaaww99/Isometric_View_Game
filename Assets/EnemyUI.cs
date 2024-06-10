using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    TextMeshProUGUI enemyNameUI;
    Slider slider;
    public JWPlayerController player;

    private void Awake()
    {
        enemyNameUI = GetComponentInChildren<TextMeshProUGUI>();
        slider = GetComponentInChildren<Slider>();
    }

#nullable enable
    MonsterStateManager? monster;
#nullable disable

    private void Update()
    {
        
        if(player.clickedTarget != null)
        {
            monster = player.clickedTarget.GetComponent<MonsterStateManager>();
        }

        slider.value = monster.currentHp;
        slider.maxValue = monster.maxHp;
       
        enemyNameUI.text = monster.name;
    }
}
