using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // ���� ���� �� ����Ʈ�� amount
    [SerializeField] int goldReward = 25;
    //���� ��� ���� �̷��� �� ��ĥ amount
    [SerializeField] int goldPenalty = 25;

    Bank bank;
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    //�÷��̾�� ��ȭ�� ��
    public void RewardGold()
    {
        //back ��ũ��Ʈ�� �� �ֵ��� ��ȣ��ġ
        if(bank == null) {  return; }
        bank.Deposit(goldReward);
    }

    //�÷��̾�κ��� ��ȭ�� �P��
    public void StealGold()
    {
        //back ��ũ��Ʈ�� �� �ֵ��� ��ȣ��ġ
        if (bank == null) { return; }
        bank.Withdraw(goldPenalty);
    }
}
