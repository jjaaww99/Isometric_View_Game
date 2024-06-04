using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    Camera mainCam;

    public Vector3 pointedPosition;

#nullable enable
    public GameObject? pointedObject;
    public GameObject? clickedObject;
#nullable disable

    public bool isPointerOnTarget = false;

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

            pointedPosition = transform.position;

            isPointerOnTarget = false;
        }

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Enemy")))
        {
            Vector3 mouseWorldPos = hit.point;

            transform.position = mouseWorldPos;

            pointedObject = hit.transform.gameObject;

            isPointerOnTarget = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);
    }
}
