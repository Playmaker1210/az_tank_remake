using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3d : MonoBehaviour
{
    public float movespeed = 15f;

    public Rigidbody rb;
    public Vector3 movement;
    public Vector3 rotation;
    private float x, y;

    void Update() {
        //Input
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        movement = new Vector3(0f, 0f, y);
        rotation = new Vector3(0f, x, 0f);
    }

    void FixedUpdate() {
        //Movement
        rb.MovePosition(rb.position + movement * movespeed * Time.deltaTime);
        //rb.AddForce(rb.position + movement * movespeed * Time.deltaTime);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, rotation.y, 0f));
    }
}
