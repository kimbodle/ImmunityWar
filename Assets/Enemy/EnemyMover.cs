using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>(); //��������Ʈ�� ����Ʈ�� path. ���� ������ϴ� ���
    [SerializeField] [Range(0f,5f)] float EnemySpeed = 1f;

    Enemy enemy;
    void OnEnable()
    {
        //Debug.Log("��ŸƮ ����");
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
        //Debug.Log("��ŸƮ ��");

    }
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        //�̹� ��θ� ã�Ƴ��� Ư����Ȳ���� ��θ� �� ã������ ������ ���� ��� �Ʒ��� �߰��ϰԵ� > ��ΰ� �� �����
        path.Clear(); //���� ����

        //����� �θ� ��ü�� ��ȯ�� �� parent
        GameObject parent  = GameObject.FindGameObjectWithTag("Path");

        //�θ� ��ü�� ã�� �� �ڽ� ��ü�� ������� �ݺ�
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
        FinishPath();
    }
}
