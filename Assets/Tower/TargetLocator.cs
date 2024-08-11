using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon; //움직이는거
    //범위의 기본값. 월드 유닛으로 봤을때 약 타일 한 개 반정도, 타겟을 둘러싼 여덟개 타일 전부 포함
    [SerializeField] float range = 15f;

    Transform target; //바라보는거. 코드에서 해줌

    [SerializeField] ParticleSystem projecttileParticles;
    
    
    void Update()
    {
        FineClosesTarget();
        AimWepon();
    }

    private void FineClosesTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        //아직 찾지 못했으니 기본으로 null
        Transform closesTarget = null;
        //현재 가장 멀리 있는 적 확보
        float maxDistance = Mathf.Infinity;

        //Ene,y 배열에 있는 모든 적 루핑
        foreach (Enemy enemy in enemies)
        {
            //우리 타워와 현재 보고 있는 적 사이의 거리 찾기
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closesTarget = enemy.transform;
                //가장 가까운 타겟을 확보했으니 maxDistance를 이 적의 현재 거리로 함
                maxDistance = targetDistance;
            }
        }
        target = closesTarget;
    }

    void AimWepon()
    {
        //타워의 위치와 적의 위치 거리 확인
        float targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        //공격할 적이 있다면 파티클 시스템 활성화
        if(targetDistance < range)
        {
            Attact(true);
        }
        else
        {
            Attact(false);
        }
    }

    //파티클 제어
    void Attact(bool isActive)
    {
        var emmissiomModule = projecttileParticles.emission;
        emmissiomModule.enabled = isActive;
    }
}
