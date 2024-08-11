using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 적이 죽을 때 떨어트릴 amount
    [SerializeField] int goldReward = 25;
    //적이 경로 끝에 이렀을 때 훔칠 amount
    [SerializeField] int goldPenalty = 25;

    Bank bank;
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    //플레이어에게 금화를 줌
    public void RewardGold()
    {
        //back 스크립트가 꼭 있도록 보호장치
        if(bank == null) {  return; }
        bank.Deposit(goldReward);
    }

    //플레이어로부터 금화를 뻇음
    public void StealGold()
    {
        //back 스크립트가 꼭 있도록 보호장치
        if (bank == null) { return; }
        bank.Withdraw(goldPenalty);
    }
}
