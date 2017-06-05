using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Move3D : MonoBehaviour
{
    public float speed = 3f;
    public Rigidbody rb;
    // Use this for initialization
    void randomWalk()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 a = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
        //rb2D.AddForce(a * speed);
        rb.velocity = a * speed;

        
        /*if (rb2d.velocity.magnitude >= MaxSpeed)
            rb2d.velocity = new Vector2(0, 0);*/
    }
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        randomWalk();
    }
}