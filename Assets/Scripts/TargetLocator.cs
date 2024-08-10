using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon; //�����̴°�
    [SerializeField] Transform target; //�ٶ󺸴°�. �ڵ忡�� ����
    
    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }

    
    void Update()
    {
        AimWepon();
    }
    void AimWepon()
    {
        weapon.LookAt(target);
    }
}
