using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon; //�����̴°�
    [SerializeField] Transform target; //�ٶ󺸴°�. �ڵ忡�� ����
    
    
    void Update()
    {
        FineClosesTarget();
        AimWepon();
    }

    private void FineClosesTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closesTarget = null;
        float mixDistance = Mathf.Infinity;
    }

    void AimWepon()
    {
        weapon.LookAt(target);
    }
}
