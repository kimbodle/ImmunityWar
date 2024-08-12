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

    //Pool ä���, start������ �� �� ������ Awake ��ȣ
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

        //Ǯ ä���. �ν��Ͻ�
        for(int i = 0; i < pool.Length; i++)
        {
            //gameobject, parent. �θ�� ���̶�Ű�� ������Ʈ Ǯ�� {transform} = ObjectPool�� ��ü �θ�
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
