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


    public void isTargeted()
    {
        ren.material.color = Color.red;
    }

    public void isUntargeted()
    {
        ren.material.color = originalColor;
    }

}
