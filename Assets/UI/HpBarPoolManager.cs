using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class HpBarPoolManager : MonoBehaviour
{
    [SerializeField]
    private GameObject hpBarPrefab;

    [SerializeField]
    private Transform parentTransform;

    private IObjectPool<HpBar> pool;

    List<GameObject> targetObject = new List<GameObject>();

    private void Awake()
    {
        pool = new ObjectPool<HpBar>(CreateHpBar, OnGetHpBar, OnReleaseHpBar, OnDestroyHpBar, maxSize: 20);
    }

    private void Start()
    {
        GameObject[] tObjects = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < tObjects.Length; i++)
        {
            targetObject.Add(tObjects[i]);
            var hpBar = pool.Get();
            hpBar.OnTarget(tObjects[i]);
            hpBar.transform.SetParent(parentTransform, false);
        }
    }

    private HpBar CreateHpBar()
    {
        HpBar hpBar = Instantiate(hpBarPrefab).GetComponent<HpBar>();
        hpBar.SetManagePool(pool);
        return hpBar;
    }
    void OnGetHpBar(HpBar hpBar)
    {
        hpBar.gameObject.SetActive(true);
    }
    void OnReleaseHpBar(HpBar hpBar)
    {
        hpBar.gameObject.SetActive(false);
    }
    void OnDestroyHpBar(HpBar hpBar)
    {
        Destroy(hpBar.gameObject);
    }
}
