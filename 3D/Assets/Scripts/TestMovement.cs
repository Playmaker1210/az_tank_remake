using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public CharacterController controller;
    //public Transform gameobject;

    public float speed = 15f;
    public float turnSmoothness = 0.1f;
    public float targetAngle, angle;
    float turnSmoothVelocity;
    float x, y;
    public Vector3 direction;
    
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");   
        y = Input.GetAxisRaw("Vertical");
        direction = new Vector3(x, 0f, y).normalized;

        if (direction.magnitude >= 0.1f) {
            targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg; //+ gameobject.eulerAngles.y
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothness);
            transform.rotation = Quaternion.Euler(-90f, angle, 0f);

            //Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(direction * speed * Time.deltaTime);
        }
    }
}
