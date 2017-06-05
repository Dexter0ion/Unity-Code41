using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
 void EnemyDetect(Collider other)
    {
        if((other.tag == "Enemy"))
        {

        }

        //碰撞
        Vector3 direction = other.transform.position - transform.position;
    }

}
