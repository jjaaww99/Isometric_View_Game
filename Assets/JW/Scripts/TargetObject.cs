using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    Renderer renderer;
    Color originalColor;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
    }


    public void Highlight()
    {
        if(renderer.material.color == originalColor)
        {
            renderer.material.color = Color.red;
        }
        else
        {
            renderer.material.color = originalColor;
        }
    }

}
