using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] [Range(0, 50)] int poolsize = 5;
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 1f;

    GameObject[] pool;

    //Pool 채우기, start에서도 할 수 있지만 Awake 선호
    private void Awake()
    {
        PopulatePool();
    }
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    void PopulatePool()
    {
        pool = new GameObject[poolsize];

        //풀 채우기. 인스턴스
        for(int i = 0; i < pool.Length; i++)
        {
            //gameobject, parent. 부모는 하이라키의 오브젝트 풀인 {transform} = ObjectPool이 개체 부모
            pool[i]= Instantiate(EnemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    private void EnableObjectInPool()
    {
        for(int i=0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
}
