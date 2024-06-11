using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;

    private void Start()
    {
        Transform cameraTransform = VirtualCamera.transform;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad8))
        {

        }
        if(Input.GetKeyDown(KeyCode.Keypad2))
        {

        }
    }






}
