using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDoll : MonoBehaviour
{
    public Rigidbody[] rigids;
    public Collider[] colliders;

    private void Awake()
    {
        rigids = GetComponentsInChildren<Rigidbody>();
        colliders = GetComponentsInChildren<Collider>();
    }

    private void OnEnable()
    {
        foreach (var rigid in rigids)
        {
            rigid.isKinematic = true;
        }

        foreach (var collider in colliders)
        {
            collider.enabled = false;
        }
    }

    public void SetRagdollActive(bool active)
    {
        foreach (var rigid in rigids)
        {
            rigid.isKinematic = !active;
        }

        foreach (var collider in colliders)
        {
            collider.enabled = active;
        }
    }

    public void DamagetoPlayer()
    {
        GameManager.instance.player.TakeDamage(5);
    }

}
