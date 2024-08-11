using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>(); //��������Ʈ�� ����Ʈ�� path. ���� ������ϴ� ���
    [SerializeField] [Range(0f,5f)] float EnemySpeed = 1f;
    // Start is called before the first frame update

    void OnEnable()
    {
        //Debug.Log("��ŸƮ ����");
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
        //Debug.Log("��ŸƮ ��");

    }

    void FindPath()
    {
        //�̹� ��θ� ã�Ƴ��� Ư����Ȳ���� ��θ� �� ã������ ������ ���� ��� �Ʒ��� �߰��ϰԵ� > ��ΰ� �� �����
        path.Clear(); //���� ����
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        //�迭�� �־�� ��������Ʈ���� ����Ʈ�� �ֱ�
        foreach (GameObject waypoint in waypoints)
        { 
            path.Add(waypoint.GetComponent<Waypoint>());
        }
    }

    private void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    //���� ��ο� ���� �̵�
    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercnet = 0f;
            
            transform.LookAt(endPosition);

            while(travelPercnet < 1f) //1�� ��������
            {
                travelPercnet+= Time.deltaTime * EnemySpeed; //�� ������ deltaTiem�� travelPercent�� ������
                transform.position = Vector3.Lerp(startPosition,endPosition, travelPercnet);

                //�� ��, ������ �ð����� ��ٸ��� ��� �������� ������ ��ٸ� ���� �ٽ� �ڷ�ƾ ����
                yield return new WaitForEndOfFrame(); 
            }
        }

        //Destroy(gameObject); //���� ����� ���� �����ϸ� ����
        gameObject.SetActive(false);
    }
}
