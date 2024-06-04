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
        ren = GetComponentsInChildren<Renderer>();

    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        //ren.material.color = Color.red;
        foreach(var r in ren)
        {
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //ren.material.color = originalColor;
    }
        
}
