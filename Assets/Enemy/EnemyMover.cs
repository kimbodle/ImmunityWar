using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>(); //웨이포인트의 리스트는 path. 적이 따라야하는 경로
    [SerializeField] [Range(0f,5f)] float EnemySpeed = 1f;

    Enemy enemy;
    void OnEnable()
    {
        //Debug.Log("스타트 시작");
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
        //Debug.Log("스타트 끝");

    }
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        //이미 경로를 찾아놓고 특정상황에서 경로를 또 찾았을때 새것을 기존 경로 아래에 추가하게됨 > 경로가 더 길어짐
        path.Clear(); //위에 방지

        //경로의 부모 개체를 반환한 값 parent
        GameObject parent  = GameObject.FindGameObjectWithTag("Path");

        //부모 객체를 찾은 뒤 자식 객체를 순서대로 반복
        foreach (Transform child in parent.transform)
        { 
            Waypoint waypoint = child.GetComponent<Waypoint>();
            if(waypoint != null)
            {
                path.Add(waypoint);
            }
        }
    }

    private void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }
    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    //적이 경로에 따라 이동
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

                //초 즉, 고정된 시간동안 기다리는 대신 프레임의 끝까지 기다린 다음 다시 코루틴 시작
                yield return new WaitForEndOfFrame(); 
            }
        }
        FinishPath();
    }
}
