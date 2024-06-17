//using System;
//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using Unity.Mathematics;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.UI;

//public class YGPlayerStat : MonoBehaviour
//{
//    [Header("플레이어 스탯")]
//    [SerializeField] playerStatKYG playerStatKYG;
//    [SerializeField] List<PlayerStatData> playerData;
//    [SerializeField] int maxlevel;
//    [SerializeField] int level;
//    [SerializeField] int max_Hp;
//    [SerializeField] float hp;
//    [SerializeField] int str;
//    [SerializeField] int dex;
//    [SerializeField] int max_rage;
//    [SerializeField] float rage;
//    [SerializeField] int max_Exp;
//    [SerializeField] int exp;

//    [Header("UI")]
//    [SerializeField] Image hp_Liquid;
//    [SerializeField] Image range_Liquid;
//    [SerializeField] Slider exp_Bar;
//    [SerializeField] TextMeshProUGUI strIndex;
//    [SerializeField] TextMeshProUGUI dexIndex;
//    [SerializeField] TextMeshProUGUI levelIndex;

//    [Header("Bool")]
//    bool isDead = false;
//    private void Awake()
//    {
//        playerData = playerStatKYG.playerData;
//        maxlevel = playerData[0].maxLv;
//        level = 0;
//        max_Hp = playerData[level].playerHp;
//        hp = max_Hp;
//        str = playerData[level].str;
//        dex = playerData[level].dex;
//        max_rage = playerData[level].playerRage;
//        rage = max_rage;
//        max_Exp = playerData[level].maxExp;
//        exp = 0;
//        exp_Bar.maxValue = max_Exp;
//        exp_Bar.value = exp;
//    }
//    private void Start()
//    { 
//        ShowUi();
//        StatsUi();
//        levelIndex.text = (level + 1).ToString();
//    }
//    private void Update()
//    {

//    }
//    private void ShowUi()
//    {
//        hp_Liquid.material.SetFloat("_FillLevel", hp/max_Hp); 
//        range_Liquid.material.SetFloat("_FillLevel", rage / max_rage);
//    }
//    private void StatsUi()
//    {
//        strIndex.text = str.ToString();
//        dexIndex.text = dex.ToString();
//    }
//    public void ExpUp(int enemy_exp)
//    {
//        if(level >= maxlevel)
//            return;
//        exp += enemy_exp;
//        exp_Bar.value = exp;
//        if (exp >= max_Exp)
//            LevelUp();
//    }
//    private void LevelUp()
//    {
//        level++;
//        max_Hp = playerData[level].playerHp;
//        hp = max_Hp;
//        str = playerData[level].str;
//        dex = playerData[level].dex;
//        max_rage = playerData[level].playerRage;
//        rage = max_rage;
//        exp -= max_Exp;
//        max_Exp = playerData[level].maxExp;
//        exp_Bar.maxValue = max_Exp;
//        exp_Bar.value = exp;
//        levelIndex.text = (level + 1).ToString();
//        StatsUi();
//    }
//    public void Hit(int damage)
//    {
//        if(isDead) 
//            return;
//        hp -= damage; 
//        ShowUi();
//        if (hp <= 0)
//            Dead();
//    }
//    public void Heal(int healPoint)
//    {
//        hp += healPoint;
//        ShowUi();
//    }
//    public void UseRage(int usePoint)
//    {
//        rage -= usePoint;
//        ShowUi();
//    }
//    public void HealRage(int healPoint)
//    {
//        rage += healPoint;
//        ShowUi();
//    }
//    private void Dead()
//    {

//    }
//}
