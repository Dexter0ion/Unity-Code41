using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLaser : MonoBehaviour {

    public Rigidbody2D laser;
    public float speed = 20f;
	// Use this for initialization
	void Start () {
		
	}

    void shot()
    {
        if (Input.GetMouseButton(1))
        {
            Rigidbody2D laserInstance = Instantiate(laser, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            laserInstance.velocity = new Vector2(0,speed);
        }
    }
	// Update is called once per frame
	void Update () {

        shot();
	}
}
