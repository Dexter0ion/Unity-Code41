using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILocomotion : Vehicle {
    //AI角色的控制器
    private CharacterController controller;
    //AI角色的rigidbody
    private Rigidbody theRigidbody;
    //AI角色每次的移动距离
    private Vector3 moveDistance;

    // Use this for initialization
	void start () {
        //获得角色控制器（如果有的话）
        controller = GetComponent<CharacterController>();
        //获得AI角色的rigidbody如果有的话
        theRigidbody = GetComponent<Rigidbody>();
        moveDistance = new Vector3(0, 0, 0);

        base.Start();
        /*
         * 调用基类的Start()函数 进行所需的初始化
         * public class AILocomotion : Vehicle 冒号后面是基类
         */

    }

    //物理相关操作在FixedUpdate()中更新
    void FixedUpdate()
    {
        //计算速度
        velocity += acceleration * Time.fixedDeltaTime;
        //限制速度，要低于最大速度
        if (velocity.sqrMagnitude > sqrMaxSpeed)
            velocity = velocity.normalized * maxSpeed;
        //计算AI角色的移动距离
        moveDistance = velocity * Time.fixedDeltaTime;
        //如果要求ai角色在平面上移动 那么将y设为0
        if(isPlanar)
        {
            velocity.y = 0;
            moveDistance.y = 0;
        }

        //如果已经为AI角色添加了角色控制器 那么利用角色控制器是其移动
        if (controller != null)
            controller.SimpleMove(velocity);
        //如果AI没有角色controller也没有rigidbody
        //或是有rigidbody但是要由动力学的方式控制移动
        else if (theRigidbody == null || theRigidbody.isKinematic)
            transform.position += moveDistance;
        //用rigidbody控制AI角色的运动
        else
            theRigidbody.MovePosition(theRigidbody.position + moveDistance);
        //更新朝向 如果速度大于一个阈值（为了防止抖动)

        if(velocity.sqrMagnitude>0.00001)
        {
            //通过当前朝向与速度方向的插值，计算新的朝向
            Vector3 newForward = Vector3.Slerp(transform.forward, velocity, damping * Time.deltaTime);
            //spherically interpolates球形插值 between 2 vectors

            //将y设为0
            if (isPlanar)
                newForward.y = 0;

            transform.forward = newForward;
        }
        
        //播放角色行走动画
        /*这个不行
        gameObject.animation.Play(“walk");
        */

        }
    }


