using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSphere : MonoBehaviour {

    //子弹的速度
    public float speed = 500;
    //子弹被销毁之前的存在时间
    public float lifeTime = 6f;

    //子弹发射方向
    [HideInInspector]
    public Vector3 direction;


	// Use this for initialization
	void Start () {
        //在lifeTime之后销毁
        Destroy(gameObject, lifeTime);
	}

    void Update()
    {
        //每帧更新子弹位置
        transform.position += direction * speed * Time.deltaTime;
    }

    //当子弹与其他碰撞体发生碰撞时调用
    void OnTriggerEnter(Collider other)
    {
        //如果另一个碰撞体是玩家
        if(other.tag=="Player")
        {
            //减少玩家的健康值
            PlayerController controller;
            controller = other.GetComponent<PlayerController>();
            controller.health -= 20;
            
            Destroy(gameObject);
        }

        if(other.tag == "Enemy")
        {
            //减少敌方健康值
            EnemyAIController controller;
           controller = other.GetComponent<EnemyAIController>();
            controller.health -= 20;
            Destroy(gameObject);
        

        }
    }

	

}
