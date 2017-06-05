using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 2);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy"||col.tag== "Unit")
        {
            col.gameObject.GetComponent<Enemy>().Explode();
            Destroy(gameObject);
        }

        /*
        if (col.tag == "Unit")
        {
            Destroy(col.transform.root.gameObject);
            Destroy(gameObject);
        }
         */
    }
}
