using System.Collections;
using UnityEngine;

public class SteeringForArrive : Steering {

    public bool isPlanar = true;
    public float arrivalDistance = 0.3f;
    public float characerRadius = 1.2f;

    //当目标小于这个距离时 开始减速

    public float slowDownDistance;
    public GameObject target;
    private Vector3 desiredVelocity;
    private Vehicle m_vehicle;
    private float maxSpeed;

    void OnDrawGizmos()
    {
        //显示减速范围
        Gizmos.DrawWireSphere(target.transform.position, slowDownDistance);
    }
    
    void Start()
    {
        m_vehicle = GetComponent<Vehicle>();
        maxSpeed = m_vehicle.maxSpeed;
        isPlanar = m_vehicle.isPlanar;
    }

    public override Vector3 Force()
    {
        //计算AI角色与目标之间的距离
        Vector3 toTarget = target.transform.position - transform.position;
        //预期速度
        Vector3 desiredVelocity;
        //返回的操作向量
        Vector3 returnForce;

        if (isPlanar)
        {
            toTarget.y = 0;
        }
        float distance = toTarget.magnitude;
        //如果与目标之间的距离大于所设置的减速半径
        if (distance > slowDownDistance)
        {
            //预期速度时AI角色与目标点之间的距离
            desiredVelocity = toTarget.normalized * maxSpeed;
            //返回预期速度与当前速度的差
            returnForce = desiredVelocity - m_vehicle.velocity;
        }

        else
        {
            //计算预期速度 并返回预期速度与当前速度的差
            desiredVelocity = toTarget - m_vehicle.velocity;
            //返回预期速度与当前速度的差
            returnForce = desiredVelocity - m_vehicle.velocity;
        }

        return returnForce;
        

    }
    
}

