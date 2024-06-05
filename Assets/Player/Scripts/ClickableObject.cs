using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    Renderer[] ren;
    Color[] originalColor;
    
    private void Awake()
    {
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        //ren.material.color = Color.red;
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //ren.material.color = originalColor;
    }
        
}
