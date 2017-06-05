using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public float speed = 3f;
    public GameObject Shuttle;
    private Rigidbody2D myRigidbody2d;
    private Rigidbody myRigidbody;

    //time control
    private float launchRate = 0.5f;
    private float nextLaunch = 0f;
	// Use this for initialization

    void LaunchShip()
    {
       // if (Time.time > nextLaunch)
       // {
           // nextLaunch += launchRate;
        if (Input.GetMouseButton(0))
            {
                Instantiate(Shuttle, this.transform.localPosition, this.transform.localRotation);
            }
        //}
    }

    void moveObejct()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        float moveAltitude=0.0f;


        if (Input.GetKey(KeyCode.Q)||Input.GetKey(KeyCode.Joystick1Button5))
            this.transform.rotation *= Quaternion.Euler(0,1,0);
        if (Input.GetKey(KeyCode.E)||Input.GetKey(KeyCode.Joystick1Button4))
            this.transform.rotation *= Quaternion.Euler(0,-1, 0);
        if (Input.GetKey(KeyCode.P))
            moveAltitude = 1;
        if (Input.GetKey(KeyCode.L))
            moveAltitude = -1;
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        myRigidbody.velocity = movement * speed;
    }

	void Start() {
        myRigidbody2d = GetComponent<Rigidbody2D>();
        myRigidbody = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
        moveObejct();
	}
}
