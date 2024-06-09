using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    public SkinnedMeshRenderer[] SkinnedMeshRenderers;
    
    void Start()
    {
        SkinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach(var ren in SkinnedMeshRenderers)
        {
            ren.gameObject.layer = 7;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (var ren in SkinnedMeshRenderers)
        {
            ren.gameObject.layer = 0;
        }
    }

}
