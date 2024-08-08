using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>(); //��������Ʈ�� ����Ʈ�� path. ���� ������ϴ� ���
    [SerializeField] float waitTime = 1f;
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
            //Debug.Log(waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
