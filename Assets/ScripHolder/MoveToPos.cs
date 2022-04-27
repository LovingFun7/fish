using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPos : MonoBehaviour
{
    public Vector3 target; //���ڷ�Χ�ڽ����ƶ��ĵ�
    public float speed = 2; //�ƶ����ٶ�
    public float angleSpeed = 0.01f; //����ת���ٶ�  ��Ϊ����Ŀ���
    public bool isRotate = true;//�Ƿ���ת������Ŀ���
    private void Start()
    {
        //Ϊ���������һ��Ŀ��
        SetTarget();
    }
    private void Update()
    {
        //ת��
        if (isRotate)
        {
            Vector3 vec = (target - transform.position);
            Quaternion rotate = Quaternion.LookRotation(vec);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, rotate, angleSpeed);
            if (Vector3.Angle(vec, transform.forward) < 0.1f)
            {
                isRotate = false;
            }
        }
        Move();
    }
    void SetTarget()
    {
        //�����x,y,z�Ƕ�����ĳ����Χ���޶�  ���Ը����Լ��������
        float x = -10;
        float y = Random.Range(-3, 4);
        float z = 0;
        target = new Vector3(x, y, z);
        isRotate = true;
    }

    void Move()
    {
        //�����ƶ������ɵ�Ŀ���
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

        if (Vector3.Distance(transform.position, target) == 0)
        {
            SetTarget();
        }
    }

}
