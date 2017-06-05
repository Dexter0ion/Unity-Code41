using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringForFlee : Steering {

    public GameObject target;
    //设置使AI角色意识到危险并开始逃跑的范围
    public float fearDistance = 20;
    private Vector3 desiredVelocity;
    private Vehicle m_vehicle;
    private float maxSpeed;

    void Start()
    {
        m_vehicle = GetComponent<Vehicle>();
        maxSpeed = m_vehicle.maxSpeed;   
    }

    public override Vector3 Force()
    {
        Vector3 tmpPos = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 tmpTargetPos = new Vector3(target.transform.position.x, 0, target.transform.position.z);

        //如果大于逃跑距离 则返回0向量 即受力为0
        if (Vector3.Distance(tmpPos, tmpTargetPos) > fearDistance)
            return new Vector3(0, 0, 0);

        //如果在fear范围内 计算逃跑所需操控向量
        desiredVelocity = (target.transform.position - transform.position).normalized * maxSpeed;
        return (m_vehicle.velocity-desiredVelocity);       
    }
}
