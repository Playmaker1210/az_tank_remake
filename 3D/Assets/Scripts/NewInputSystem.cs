using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputSystem : MonoBehaviour
{
    InputMaster controls;

    void Awake() {
        controls = new InputMaster();
        controls.Player.Shoot.performed += _ => Shoot();
        controls.Player.Movement.performed += context => Move(context.ReadValue<Vector2>());
    }

    void Shoot() {
        Debug.Log("Shoot");
    }

    void Move(Vector2 direction) {
        Debug.Log("Move" + direction);
    }

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }

}
