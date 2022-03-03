using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 15f;
    public float turnSmoothness = 0.1f;
    float turnSmoothVelocity;
    float x, y;
    Vector3 direction;
    
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");   
        y = Input.GetAxisRaw("Vertical");
        direction = new Vector3(x, 0f, y).normalized;

        if (direction.magnitude >= 0.1f) {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetAngle, ref turnSmoothVelocity, turnSmoothness);
            transform.rotation = Quaternion.Euler(-90f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
        }
    }
}
