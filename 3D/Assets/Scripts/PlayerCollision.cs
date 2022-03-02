using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement3d playerMovement;

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.name == "Wall") {
            Debug.Log("Wall hit");
            
        }
    }
}
