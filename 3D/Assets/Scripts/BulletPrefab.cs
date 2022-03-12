using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPrefab : MonoBehaviour
{
    public float xForce;
    public float yForce;
    public float zForce = 30f;
    public float destroyTime = 5f;

    private void Start() {
        xForce = 0;
        yForce = 0;
        zForce = 30;

        Vector3 force = new Vector3(xForce, yForce, zForce);
        GetComponent<Rigidbody>().velocity = force;

        Destroy(gameObject, destroyTime);    //Destroy after specified time
    }
}
