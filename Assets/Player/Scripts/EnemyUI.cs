using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI enemyNameUI;
    [SerializeField] Slider slider;
    public JWPlayerController player;
    public GameObject[] UIs;
    private void Awake()
    {
        enemyNameUI = GetComponentInChildren<TextMeshProUGUI>();
        slider = GetComponentInChildren<Slider>();
    }

#nullable enable
    [SerializeField] MonsterStateManager? monster;
#nullable disable

    private void Update()
    {

        if (player.clickedTarget != null &&  player.clickedTarget.TryGetComponent<MonsterStateManager>(out MonsterStateManager monster))
        {
            foreach (var UI in UIs)
            {
                UI.SetActive(true);
            }

            monster = player.clickedTarget.GetComponent<MonsterStateManager>();

            slider.value = monster.currentHp;
            slider.maxValue = monster.maxHp;
       
            enemyNameUI.text = monster.monsterName;
        }

        else
        {
            foreach(var UI in UIs)
            {
                UI.SetActive(false);
            }
        }
    }
}
