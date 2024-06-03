using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    Renderer ren;
    Color originalColor;
    
    private void Awake()
    {
        //ren = GetComponent<Renderer>();
        //originalColor = ren.material.color;
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
