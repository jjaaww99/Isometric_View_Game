using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            Vector3 mouseWorldPos = hit.point;

            transform.position = mouseWorldPos;
        }
    }

    public bool isOnEnemy;

    public ClickableObject target;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isOnEnemy = true;
            target = other.GetComponent<ClickableObject>();
            target.Highlight();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isOnEnemy = false;
            target.Highlight();
        }
    }
}
