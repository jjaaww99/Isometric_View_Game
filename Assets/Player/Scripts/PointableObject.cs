using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointableObject : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] protected Renderer[] multipleRenderers;

    const int outLineLayer = 7;
    protected int originalLayer;

    protected virtual void OnEnable()
    {
        originalLayer = gameObject.layer;
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
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
