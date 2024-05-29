using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //..프리팹들을 보관할 변수 (프리팹종류만큼 리스트 필요)
    public GameObject[] prefabs;

    //..풀을 담당할 리스트들
    public List<GameObject>[] pools;

    public void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        //풀을 담을 리스트 초기화
        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
            //풀안에 프리팹 초기화
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;
        // ... 선택한 풀의 놀고 있는 게임오브젝트 접근
        //... 발견하면 select변수에 할당
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }
        //... 모두 쓰고있으면 새로 생성
        if (!select)
        {
            //...새롭게 생성하고 select 변수에 할당
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }
        return select;
    }

}
