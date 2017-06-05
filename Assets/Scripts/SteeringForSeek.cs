using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringForSeek :Steering
{
    //需要寻找的目标物体
    public GameObject target;
    //预期速度
    private Vector3 desiredVelocity;
    //获取被操控的AI角色 以便查询信息
    private Vehicle m_vehicle;
    //最大速度
    private float maxspeed;
    //是否在二维平面运动
    private bool isPlanar;
    // Use this for initialization
    void Start()
    {
        //获取被操作的AI角色，并读取角色允许的最大速度及是否在平面上移动
        m_vehicle = GetComponent<Vehicle>();
        maxspeed = m_vehicle.maxSpeed;
        isPlanar = m_vehicle.isPlanar;
    }
    //计算操作向量(操作力)
    public override Vector3 Force()
    {
        //计算预期速度
        desiredVelocity = (target.transform.position - transform.position).normalized * maxspeed;
        if (isPlanar)
            desiredVelocity.y = 0;

        //返回操控向量 预期速度与当前速度的向量差
        return (desiredVelocity - m_vehicle.velocity);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
