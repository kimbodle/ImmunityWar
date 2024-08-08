using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>(); //웨이포인트의 리스트는 path. 적이 따라야하는 경로
    [SerializeField] float waitTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("스타트 시작");
        StartCoroutine(FollowPath());
        //Debug.Log("스타트 끈");

    }

    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path)
        {
            //Debug.Log(waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
