using DamageNumbersPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class MousePointer : MonoBehaviour
{
    Camera mainCam;

    public Vector3 pointerPosition;
    public VisualEffect clickEffect;
#nullable enable
    public GameObject? pointedObject;
    public GameObject? clickedObject;
#nullable disable

    public bool isPointerOnObject = false;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        int combinedLayerMask = LayerMask.GetMask("Ground", "Enemy", "Item");

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, combinedLayerMask))
        {
            Vector3 mouseWorldPos = hit.point;
            transform.position = mouseWorldPos;
            pointerPosition = transform.position;

            int groundLayer = LayerMask.NameToLayer("Ground");
            int enemyLayer = LayerMask.NameToLayer("Enemy");
            int itemLayer = LayerMask.NameToLayer("Item");

            if (hit.transform.gameObject.layer == groundLayer)
            {
                isPointerOnObject = false;
                pointedObject = null;

                if (Input.GetMouseButtonDown(1))
                {
                    clickEffect.transform.position = transform.position + new Vector3(0, 0.2f, 0);
                    clickEffect.Play();
                }
            }

            else if (hit.transform.gameObject.layer == enemyLayer || hit.transform.gameObject.layer == itemLayer)
            {
                pointedObject = hit.transform.gameObject;
                isPointerOnObject = true;
            }
        }
    }
}
