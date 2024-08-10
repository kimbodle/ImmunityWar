using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon; //움직이는거
    [SerializeField] Transform target; //바라보는거. 코드에서 해줌
    
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
