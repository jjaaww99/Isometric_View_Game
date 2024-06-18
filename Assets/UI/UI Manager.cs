using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public PlayerStatus playerStat;
    public JWPlayerController player;

    public Slider hpSlider;
    public Slider rageSlider;
    public Slider expSlider;

    public GameObject coinUI;
    public TextMeshProUGUI coinText;

    public GameObject enemyUI;
    public TextMeshProUGUI enemyName;
    public Slider enemyHpSlider;

    public TextMeshProUGUI strText;
    public TextMeshProUGUI dexText;

    public TextMeshProUGUI levelText;

    public Canvas deadUI;
    public Button toMainButton;

    private void Awake()
    {
        deadUI.gameObject.SetActive(false);
        toMainButton.onClick.AddListener(SceneController.Instance.ToStartScene);
    }

    void Update()
    {
        UpdateSlider();
        DisplayEnemyUI();
        DisplayCoinUI();

        strText.text = playerStat.str.ToString();
        dexText.text = playerStat.dex.ToString();
        levelText.text = playerStat.level.ToString();

        if(GameManager.instance.playerController.stateMachine.GetState() == GameManager.instance.playerController.dead)
        {
            Invoke(nameof(ShowDeadUI), 1f);
        }
    }

    void ShowDeadUI()
    {
        deadUI.gameObject.SetActive(true);
    }

    void UpdateSlider()
    {
        hpSlider.maxValue = playerStat.maxHp;
        rageSlider.maxValue = playerStat.maxRage;
        expSlider.maxValue = playerStat.maxExp;
        hpSlider.value = playerStat.currentHp;
        rageSlider.value = playerStat.currentRage;
        expSlider.value = playerStat.currentExp;
    }


    public MonsterStateManager monster;

    void DisplayEnemyUI()
    {
        if (player.clickedTarget != null && player.clickedTarget.TryGetComponent<MonsterStateManager>(out MonsterStateManager _monster))
        {
            enemyUI.SetActive(true);

            monster = _monster;

            enemyHpSlider.value = _monster.currentHp;
            enemyHpSlider.maxValue = _monster.maxHp;

            enemyName.text = _monster.monsterName;
        }

        else
        {
            enemyUI.SetActive(false);
        }
    }

    void DisplayCoinUI()
    {
        if (player.clickedTarget != null && player.clickedTarget.TryGetComponent<Coin>(out Coin coin))
        {
            coinUI.SetActive(true);
            coinText.text = $"{coin.coinValue} gold";

            Vector3 mousePos = Input.mousePosition;

            coinUI.transform.position = mousePos + new Vector3(0, 10, 0);
        }

        else
        {
            coinUI.SetActive(false);
        }
    }
}
