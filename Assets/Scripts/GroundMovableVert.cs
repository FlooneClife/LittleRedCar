using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovableVert : MonoBehaviour {

    private float speed = 0.10f;
    private bool isRising;  //true == up, false = down
    private float Ycoords;

    void Start() {
        if(tag == "MovableUp") {
            isRising = true;
        } else if(tag == "MovableDown") {
            isRising = false;
        }
    }

    void Update() {
        Ycoords = transform.position.y;
        //determine movement direction
        if(Ycoords > 4) {
            isRising = false;
        } else if(Ycoords < -4) {
            isRising = true;
        }
        //move the ground
        if(isRising) {
            transform.Translate(0, speed, 0);
        } else {
            transform.Translate(0, -speed, 0);
        }
    }

}
