using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    public JWPlayer player;
    Camera mainCam;
    public bool isOnEnemy = false;
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

            isOnEnemy = false;
        }

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Enemy")))
        {
            Vector3 mouseWorldPos = hit.point;

            transform.position = mouseWorldPos;

            isOnEnemy = true;

            player.pointedTarget = hit.transform.gameObject;

            if(Input.GetMouseButtonDown(1))
            {
                player.clickedTarget = hit.transform.gameObject;
            }
        }
    }


}
