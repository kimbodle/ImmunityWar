using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>(); //웨이포인트의 리스트는 path. 적이 따라야하는 경로
    [SerializeField] [Range(0f,5f)] float EnemySpeed = 1f;
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
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercnet = 0f;
            
            transform.LookAt(endPosition);

            while(travelPercnet < 1f) //1은 종료지점
            {
                travelPercnet+= Time.deltaTime * EnemySpeed; //매 프레임 deltaTiem이 travelPercent에 더해짐
                transform.position = Vector3.Lerp(startPosition,endPosition, travelPercnet);
                yield return new WaitForEndOfFrame(); //초 즉, 고정된 시간동안 기다리는 대신 프레임의 끝까지 기다린 다음 다시 코루틴 시작
            }
        }
    }
}
