using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;

    [SerializeField]  int currentBalance;
    //�ܾ��� ���� ������Ƽ. �ۿ��� ������ �� ������ ���������� �������� ����
    public int CurrentBalane { get { return currentBalance;  } }

    //TextMeshPro ��ҿ� ����
    [SerializeField] TextMeshProUGUI displayBalance;

    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }
    public void Deposit(int amount)
    {
        //������ ������ ����� �Ǵ� ��Ȳ ����
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();

    }

    public void Withdraw(int amount)
    {
        //������ ������ ���� �Ǵ� ��Ȳ ����
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();


        if (currentBalance < 0)
        {
            ReloadScene();
            //Lose the game;
        }
    }
    void ReloadScene()
    {
        UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
