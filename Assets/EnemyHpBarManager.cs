using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBarManager : MonoBehaviour
{
    public JWPlayerController player;
    public MonsterStateManager[] monsters;
    public Slider[] monsterHpSliders;
    public const int hpBarCount = 20;

    private void Awake()
    {
        monsters = new MonsterStateManager[hpBarCount];
        monsterHpSliders = new Slider[hpBarCount];

        monsterHpSliders = GetComponentsInChildren<Slider>();


        foreach (var slider in monsterHpSliders)
        {
            slider.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        for (int i = 0; i < monsters.Length; i++)
        {
            if (i >= hpBarCount) break;

            if (player.targetsInDetectRange[i] != null)
            {
                player.targetsInDetectRange[i].TryGetComponent<MonsterStateManager>(out MonsterStateManager monster);
                monsters[i] = monster;

                if (monsters[i] != null)
                {
                    monsterHpSliders[i].gameObject.SetActive(true);

                    Vector3 worldPosition = monsters[i].transform.position + Vector3.up * 2;
                    Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
                    monsterHpSliders[i].transform.position = screenPosition;

                    monsterHpSliders[i].maxValue = monsters[i].maxHp;
                    monsterHpSliders[i].value = monsters[i].currentHp;
                }
            }

            if (monsterHpSliders[i].value <= 0 || monsters[i] == null)
            {
                monsterHpSliders[i].gameObject.SetActive(false);
            }
        }

        //for (int i = 0; i < player.targetsInAttackRange.Length; i++)
        //{
        //    if (i >= hpBarCount) break;

        //    player.targetsInAttackRange[i].TryGetComponent<MonsterStateManager>(out MonsterStateManager monster);

        //    monsters[i] = monster;

        //monsterHpSliders[i].gameObject.SetActive(true);

        //Vector3 worldPosition = monsters[i].transform.position + Vector3.up * 2;
        //Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
        //monsterHpSliders[i].transform.position = screenPosition;

        //monsterHpSliders[i].maxValue = monster.maxHp;
        //monsterHpSliders[i].value = monster.currentHp;


        //    if (monsterHpSliders[i].value <= 0 || monsters[i] == null)
        //    {
        //        monsterHpSliders[i].gameObject.SetActive(false);
        //    }
        //}

    }
}
