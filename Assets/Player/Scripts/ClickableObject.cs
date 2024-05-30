using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    Renderer ren;
    Color originalColor;

    private void Awake()
    {
        ren = GetComponent<Renderer>();
        originalColor = ren.material.color;
    }


    public void Highlight()
    {
        if(ren.material.color == originalColor)
        {
            ren.material.color = Color.red;
        }
        else
        {
            ren.material.color = originalColor;
        }
    }

}
