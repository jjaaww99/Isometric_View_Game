using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerStatus : MonoBehaviour
{
    public skillData skillData;
    public skillEntity[] skillList;
    public playerStat playerStat;
    public PlayerStatusEntity[] playerStatus;

    public Volume volume;
    private VolumeProfile profile;
    private Vignette vignette;
    private float vignetteintensity;
    Color originalColor;
    float originalIntensity;

    public int level;
    public int maxHp;
    public int currentHp;
    public int maxRage;
    public int currentRage;
    public int str;
    public int dex;
    public int maxExp;
    public int currentExp;



    private void Awake()
    {
        skillList = new skillEntity[6];
        playerStatus = playerStat.playerData.ToArray();

        volume = FindAnyObjectByType<Volume>(); 

        skillList[0] = skillData.SkillList[1];
        skillList[1] = skillData.SkillList[2];
        skillList[5] = skillData.SkillList[0];
        
        level = 1;
        str = playerStatus[level - 1].str;
        dex = playerStatus[level - 1].dex;
        maxHp = playerStatus[level - 1].playerHp;
        currentHp = maxHp;
        maxRage = playerStatus[level - 1].playerRage;
        currentRage = maxRage;
        maxExp = playerStatus[level - 1].maxExp;
        currentExp = 0;
    }


    private void Start()
    {
        volume.profile.TryGet(out vignette);

        originalColor = vignette.color.value;
        originalIntensity = vignette.intensity.value;
    }

    private void Update()
    {
        if (currentExp >= maxExp)
        {
            LevelUP();
        }

        float healthPercentage = (float)currentHp / (float)maxHp;
        if (healthPercentage <= 0.5)
        {
            float bogan = Mathf.Lerp(0, 0.673f, healthPercentage * 2);
            vignette.intensity.value = 1 - bogan;
        }
    }

    public void LevelUP()
    {
        if(level < 5)
        {
            level++;
            str = playerStatus[level - 1].str;
            dex = playerStatus[level - 1].dex;
            maxHp = playerStatus[level - 1].playerHp;
            currentHp = maxHp;
            maxRage = playerStatus[level - 1].playerRage;
            currentRage = maxRage;
            maxExp = playerStatus[level - 1].maxExp;
            currentExp = 0;
        }
    }

    public int Damage(int Multiplier)
    {
        int RandomDivider = Random.Range(90, 110);
        return str * Multiplier / RandomDivider;
    }

    public void TakeDamage(int damageTaken)
    {
        currentHp -= damageTaken;

        if(currentHp > 0)
        {
            StartCoroutine(ScreenBlinkRed());
        }
    }
    private IEnumerator ScreenBlinkRed()
    {
        float duration = 0.3f;
        float blinkDuration = 0.2f; // 빨간색으로 변하는 시간
        float elapsedTime = 0f;
        Color targetColor = Color.red; // 원하는 붉은색으로 설정

        while (elapsedTime < blinkDuration)
        {
            elapsedTime += Time.deltaTime;
            vignette.color.value = Color.Lerp(originalColor, targetColor, elapsedTime / blinkDuration);
            yield return null;
        }

        float restoreTime = duration - blinkDuration;
        elapsedTime = 0f;
        while (elapsedTime < restoreTime)
        {
            elapsedTime += Time.deltaTime;
            vignette.color.value = Color.Lerp(targetColor, originalColor, elapsedTime / restoreTime);
            yield return null;
        }

        vignette.color.value = originalColor;
    }


}
