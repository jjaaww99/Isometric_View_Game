using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] protected Renderer[] multipleRenderers;

    const int outLineLayer = 7;
    protected int originalLayer;

    protected virtual void OnEnable()
    {
        originalLayer = gameObject.layer;
    }

    //protected virtual void SetRenderer(Renderer renderer)
    //{

    //}

    //protected virtual void SetRenderer(Renderer[] renderers)
    //{

    //}

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(multipleRenderers != null)
        {
            foreach(var ren in multipleRenderers)
            {
                ren.gameObject.layer = outLineLayer;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (multipleRenderers != null)
        {
            foreach (var ren in multipleRenderers)
            {
                ren.gameObject.layer = originalLayer;
            }
        }
    }

}
