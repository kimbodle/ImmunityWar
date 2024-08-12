using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;

    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if(bank ==null)
        {
            return false;
        }
        //현재 금액이 cost 이상일때만 타워 설치
        if (bank.CurrentBalane >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }
        return false;
    }
}
