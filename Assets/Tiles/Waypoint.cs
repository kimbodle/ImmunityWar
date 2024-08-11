using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    //GameObject ���� Ÿ���������� Tower������ ��ȯ
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlacable;
    
    //������Ƽ
    public bool IsPlacable { get { return isPlacable; } }

    /*public bool GetIsPlaceable()
    {
        return isPlacable;
    }*/

    private void OnMouseDown()
    {
        if (isPlacable)
        {
            //Instantiate(towerPrefab, transform.position, Quaternion.identity);
            //waypoint�� ������ Tower�����հ� ��ġ�� ����
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);

            
            isPlacable = !isPlacable;
            //Debug.Log(transform.name);
        }
    }
}
