using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    public Color[] originalColors;
    public Material[] materials;
    private void Start()
    {

        originalColors = new Color[materials.Length];

        for (int i = 0; i < materials.Length; i++)
        {
            originalColors[i] = materials[i].color;
        }

    }

    protected virtual void HighlightRed(Material[] _materials)
    {
        materials = new Material[_materials.Length];
        originalColors = new Color[_materials.Length];

        for (int i = 0; i < _materials.Length; i++)
        {
            originalColors[i] = _materials[i].color;
            _materials[i].color = Color.green;
        }
    }

    protected virtual void ReturnOriginalColor(Material[] _materials)
    {
        for (int i = 0; i < _materials.Length; ++i)
        {
            _materials[i].color = originalColors[i];
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        HighlightRed(materials);
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ReturnOriginalColor(materials);
    }

}
