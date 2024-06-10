using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;
    public List<GameObject>[] pools;
    public int maxPoolSize = 20;
    int Active = 0;
    public int maxActive = 50;
    public int prefablength;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        prefablength = pools.Length;
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                Active++;
                select = item;
                select.SetActive(true);
                return select;
            }

            if (Active >= maxActive)
            {
                break;
            }
        }

        if (pools[index].Count < maxPoolSize)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
