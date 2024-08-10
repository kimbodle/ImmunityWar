using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isPlacable;

    public bool IsPlacable { get { return isPlacable; } }

    /*public bool GetIsPlaceable()
    {
        return isPlacable;
    }*/

    private void OnMouseDown()
    {
        if (isPlacable)
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlacable = false;
            //Debug.Log(transform.name);
        }
    }
}
