using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    //子弹预置体
    public GameObject bulletPrefabs;
    //子弹的生成位置
    public Transform bulletSpawnPoint;

    //开火的声音
    public AudioClip fireSound;
    //加子弹的声音
    public AudioClip reloadSound;

    //两发子弹之间的时间间隔
    public float fireInterval;

    //子弹的发散量
    public float spread = 0.5f;
    //子弹的方向
    private Vector3 bulletDirection;
    //子弹的旋转
    private Quaternion bulletRotation;
    //上次子弹发射的时间
    private float lastFireTime = -1;
    //是否正在开火
    private bool isFiring = false;

    //枪的控制者
    [HideInInspector]
    public GameObject controller;

	// Use this for initialization
	void Start () {
	if(bulletSpawnPoint == null)
        {
            bulletSpawnPoint = transform;
        }	
	}
	
    public void Fire()
    {
        isFiring = true;
    }

    public void StopFire()
    {
        isFiring = false;
    }
	// Update is called once per frame
	void Update () {
        if (controller != null)
        {
            //根据子弹的发散量，计算子弹的发射方向
            Quaternion spreadRot = Quaternion.Euler(0, (Random.value - .5f) * 2 * spread, 0);
            bulletRotation = Quaternion.LookRotation(spreadRot * controller.transform.forward);
            bulletDirection = bulletRotation * Vector3.forward;
        }
            //如果正在开火
            if(isFiring)
            {
                //距离上次发射子弹的间隔时间大于两次发射子弹的时间间隔；
                if(Time.time-lastFireTime>fireInterval)
                {
                    Shoot();
                    lastFireTime = Time.time;
                }
            }
        }

    void Shoot()
    {
        //如果枪没有控制者 直接返回
        if (controller == null)
            return;

        //实例化子弹预置体
        GameObject bulletObj = Instantiate(bulletPrefabs, bulletSpawnPoint.position, bulletRotation) as GameObject;
        bulletObj.GetComponent<BulletSphere>().direction = bulletDirection;

    }
	
}
