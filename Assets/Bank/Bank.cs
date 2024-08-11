using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;

    [SerializeField]  int currentBalance;
    //�ܾ��� ���� ������Ƽ. �ۿ��� ������ �� ������ ���������� �������� ����
    public int CurrentBalane { get { return currentBalance;  } }

    private void Awake()
    {
        currentBalance = startingBalance;
    }
    public void Deposit(int amount)
    {
        //������ ������ ����� �Ǵ� ��Ȳ ����
        currentBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        //������ ������ ���� �Ǵ� ��Ȳ ����
        currentBalance -= Mathf.Abs(amount);

        if(currentBalance < 0)
        {
            //Lose the game;
        }
    }
    void ReloadScene()
    {
        UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
