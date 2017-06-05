using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float HP;
	// Use this for initialization

    public void Explode()
    {
        Destroy(gameObject);
    }

    void hpCheck()
    {
        if (HP < 0)
            Explode();
    }

    public void Hurt()
    {
        HP -= 1f;
    }
    /*
    void OntriggerEnter2D(Collider2D col)
    {
        if (col.tag == "laser")
            Destroy(gameObject);
    }
    */
    
	void Start () {
        HP = 5f;
	}

    void update()
    {
        hpCheck();
    }
}
