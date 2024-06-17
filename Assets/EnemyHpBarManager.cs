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
        monsterHpSliders = GetComponentsInChildren<Slider>();

        monsters = new MonsterStateManager[hpBarCount];
        
        foreach (var slider in monsterHpSliders)
        {
            slider.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        for (int i = 0; i < player.targetsInAttackRange.Length; i++)
        {
            player.targetsInAttackRange[i].TryGetComponent<MonsterStateManager>(out MonsterStateManager monster);

            monsters[i] = monster;

            if (monsters[i] != null)
            {
                monsterHpSliders[i].gameObject.SetActive(true);

                monsterHpSliders[i].transform.position = monsters[i].transform.position;

                monsterHpSliders[i].maxValue = monsters[i].maxHp;
                monsterHpSliders[i].value = monsters[i].currentHp;
            }
        }
    }

}
