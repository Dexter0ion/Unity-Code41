using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringHomingMissile :Steering {
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

    //子弹的速度
    public float speed = 500;
    //子弹被销毁之前的存在时间
    public float lifeTime = 6f;
    public float attackTime = 3;

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Enemy");
        target = go;
        //获取被操作的AI角色，并读取角色允许的最大速度及是否在平面上移动
        m_vehicle = GetComponent<Vehicle>();
        maxspeed = m_vehicle.maxSpeed;
        isPlanar = m_vehicle.isPlanar;
        Destroy(gameObject, lifeTime);

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
    void Update()
    {

    }



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //减少敌方健康值
            EnemyAIController controller;
            controller = other.GetComponent<EnemyAIController>();
            controller.health -= 20;
            Destroy(gameObject);
        }

    }
}
