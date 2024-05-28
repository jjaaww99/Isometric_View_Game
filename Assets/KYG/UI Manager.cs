using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [Header("¿ÃπÃ¡ˆ")]
    [SerializeField]
    private Slider expSlider;
    [SerializeField]
    private Image hp_bar;
    [SerializeField]
    private Image stamina_bar;

    private void Awake()
    {
        hp_bar = GetComponent<Image>();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

}
