using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    private bool shoot;

    private void Update() {
        shoot = Input.GetButtonDown("Fire1");
    }

    private void FixedUpdate() {
        if (shoot) {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
