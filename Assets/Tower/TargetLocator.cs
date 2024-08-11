using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon; //�����̴°�
    //������ �⺻��. ���� �������� ������ �� Ÿ�� �� �� ������, Ÿ���� �ѷ��� ������ Ÿ�� ���� ����
    [SerializeField] float range = 15f;

    Transform target; //�ٶ󺸴°�. �ڵ忡�� ����

    [SerializeField] ParticleSystem projecttileParticles;
    
    
    void Update()
    {
        FineClosesTarget();
        AimWepon();
    }

    private void FineClosesTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        //���� ã�� �������� �⺻���� null
        Transform closesTarget = null;
        //���� ���� �ָ� �ִ� �� Ȯ��
        float maxDistance = Mathf.Infinity;

        //Ene,y �迭�� �ִ� ��� �� ����
        foreach (Enemy enemy in enemies)
        {
            //�츮 Ÿ���� ���� ���� �ִ� �� ������ �Ÿ� ã��
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closesTarget = enemy.transform;
                //���� ����� Ÿ���� Ȯ�������� maxDistance�� �� ���� ���� �Ÿ��� ��
                maxDistance = targetDistance;
            }
        }
        target = closesTarget;
    }

    void AimWepon()
    {
        //Ÿ���� ��ġ�� ���� ��ġ �Ÿ� Ȯ��
        float targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        //������ ���� �ִٸ� ��ƼŬ �ý��� Ȱ��ȭ
        if(targetDistance < range)
        {
            Attact(true);
        }
        else
        {
            Attact(false);
        }
    }

    //��ƼŬ ����
    void Attact(bool isActive)
    {
        var emmissiomModule = projecttileParticles.emission;
        emmissiomModule.enabled = isActive;
    }
}
