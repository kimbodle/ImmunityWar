using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;
    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        //label.enabled = true;
        label.enabled = false;

        waypoint = GetComponentInParent<Waypoint>();//�� ��ũ��Ʈ�� Text��, waypoint�� tile��
        DisplayCoordinates();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying) //���� ��忡���� ����
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
        SetLabelColor();
        ToggleLabels();
        //label.enabled = true;
    }
    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive(); //IsActive�� !enable�� �Ȱ���.
        }
    }

    private void SetLabelColor()
    {
        if(waypoint.IsPlacable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x/UnityEditor.EditorSnapSettings.move.x); //�� ��ũ��Ʈ�� ��ϵǴ°� Ÿ�� ��ü�̱� ����(�θ�)
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z/ UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinates.x.ToString()+","+coordinates.y.ToString();
    }

    private void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
