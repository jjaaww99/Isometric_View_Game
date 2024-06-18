using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingHammer : MonoBehaviour
{
    public float rotateSpeed;
    public Mesh[] meshs;


    private void Awake()
    {
        int randomIndex = Random.Range(0, meshs.Length - 1);
        MeshFilter filter = GetComponent<MeshFilter>();
        filter.mesh = meshs[randomIndex];
        
    }
    private void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
