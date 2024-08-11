using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon; //움직이는거
    [SerializeField] Transform target; //바라보는거. 코드에서 해줌
    
    
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
