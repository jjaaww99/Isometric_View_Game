using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class HpBar : MonoBehaviour
{
    private UnityEngine.GameObject targetObject;

    private Camera _MainCamera;

    private IObjectPool<HpBar> _ManagedPool;

    private void Awake()
    {
        _MainCamera = Camera.main;
    }
    private void Update()
    {
        transform.position = _MainCamera.WorldToScreenPoint(targetObject.transform.position + new Vector3(0, 1.5f, 0));
    }

    public void SetManagePool(IObjectPool<HpBar> pool)
    {
        _ManagedPool = pool;
    }

    public void OnTarget(UnityEngine.GameObject target)
    {
        targetObject = target;

        Invoke("OnDestroyBar", 5f);
    }

    public void OnDestroyBar()
    {
        _ManagedPool.Release(this);
    }

}
