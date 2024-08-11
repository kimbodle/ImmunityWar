using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;

    [SerializeField]  int currentBalance;
    //잔액을 위한 프로퍼티. 밖에서 접근할 수 있지만 직접적으로 설정하지 못함
    public int CurrentBalane { get { return currentBalance;  } }

    private void Awake()
    {
        currentBalance = startingBalance;
    }
    public void Deposit(int amount)
    {
        //절댓값을 전달해 출금이 되는 상황 방지
        currentBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        //절댓값을 전달해 예금 되는 상황 방지
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
