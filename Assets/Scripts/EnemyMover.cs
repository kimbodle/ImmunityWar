using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>(); //��������Ʈ�� ����Ʈ�� path. ���� ������ϴ� ���
    [SerializeField] [Range(0f,5f)] float EnemySpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("��ŸƮ ����");
        StartCoroutine(FollowPath());
        //Debug.Log("��ŸƮ ��");

    }

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
                yield return new WaitForEndOfFrame(); //�� ��, ������ �ð����� ��ٸ��� ��� �������� ������ ��ٸ� ���� �ٽ� �ڷ�ƾ ����
            }
        }
    }
}
