using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    //GameObject 였던 타워프리팹을 Tower형으로 변환
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlacable;
    
    //프로퍼티
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
            //waypoint에 부착된 Tower프리팹과 위치를 전달
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);

            
            isPlacable = !isPlacable;
            //Debug.Log(transform.name);
        }
    }
}
