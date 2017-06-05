using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGizmosSphere : MonoBehaviour {
    public float SphereRadium = 20f;
    public GameObject target;
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(target.transform.position, SphereRadium);
    }
}
