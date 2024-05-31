using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Transform pos;
    public float speed = 3.0f;

    private void Awake()
    {
        pos = GetComponent<Transform>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hori, 0, verti) * speed * Time.deltaTime;
        transform.Translate(movement);
    }



}
