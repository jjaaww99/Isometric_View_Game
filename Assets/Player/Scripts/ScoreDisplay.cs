using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI[] scoreTexts;

    private void Awake()
    {
        scoreTexts = GetComponentsInChildren<TextMeshProUGUI>();
    }
}
