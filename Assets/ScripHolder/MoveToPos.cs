using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPos : MonoBehaviour
{
    public Vector3 target; //鱼在范围内进行移动的点
    public float speed = 2; //移动的速度
    public float angleSpeed = 0.01f; //鱼旋转的速度  因为面向目标点
    public bool isRotate = true;//是否旋转到面向目标点
    private void Start()
    {
        //为鱼随机产生一个目标
        SetTarget();
    }
    private void Update()
    {
        //转向
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
        //这里的x,y,z是对鱼在某个范围的限定  可以根据自己的情况定
        float x = -10;
        float y = Random.Range(-3, 4);
        float z = 0;
        target = new Vector3(x, y, z);
        isRotate = true;
    }

    void Move()
    {
        //进行移动到生成的目标点
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

        if (Vector3.Distance(transform.position, target) == 0)
        {
            SetTarget();
        }
    }

}
