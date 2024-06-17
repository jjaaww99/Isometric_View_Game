using DamageNumbersPro;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDamage : MonoBehaviour
{
    public DamageNumber damageNumber;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 mousePos = Input.mousePosition;

            Debug.Log("Active");

            DamageNumber damage = damageNumber.Spawn(transform.position, Random.Range(1, 100));
        }
    }
}
