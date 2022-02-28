using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3d : MonoBehaviour
{
    public float movespeed = 15f;

    public Rigidbody rb;
    Vector3 movement;
    Vector3 rotation;
    float x, y;

    void Update() {
        //Input
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        movement = new Vector3(0f, 0f, y).normalized;
        rotation = new Vector3(0f, x, 0f);
    }

    void FixedUpdate() {
        //Movement
        rb.MovePosition(rb.position + movement * movespeed * Time.deltaTime);
        transform.Rotate(rotation);


        /*float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
        transform.Rotate = Quaternion.Euler(0f, targetAngle, 0f);*/
         
        
    }
}
