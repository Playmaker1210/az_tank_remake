using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    private void Update() {
        if (Input.GetKey("escape")) {
            Debug.Log("Application is quitting!!");
            Application.Quit();
        }
    }
}
