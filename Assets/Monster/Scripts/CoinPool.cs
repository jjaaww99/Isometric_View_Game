using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    public List<GameObject> coinPool;
    public GameObject coinPrefab;


    public GameObject GetCoin()
    {
        // 비활성화된 코인 중 하나를 찾아서 반환
        for (int i = 0; i < coinPool.Count; i++)
        {
            if (!coinPool[i].activeInHierarchy)
            {
                return coinPool[i];
            }
        }

        // 만약 풀에 사용 가능한 코인이 없으면 새로 생성해서 반환
        GameObject newCoin = Instantiate(coinPrefab, Vector3.zero, Quaternion.identity, transform);
        newCoin.SetActive(false);
        coinPool.Add(newCoin);
        return newCoin;
    }

    public void ActivateCoin(Vector3 position)
    {
        GameObject coin = GetCoin();
        coin.transform.position = position;
        coin.SetActive(true);
    }

}
