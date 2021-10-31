using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovableHor : MonoBehaviour {

    private float speed = 0.08f;
    private bool isMovingToRight;  //true == from left to right, false = from right to left
    private float Xcoords;

    void Start() {
        if(tag == "MovableRight") {
            isMovingToRight = true;
        } else if(tag == "MovableLeft") {
            isMovingToRight = false;
        }
    }

    void Update() {
        Xcoords = transform.position.x;
        //determine movement direction
        if(Xcoords > 4) {
            isMovingToRight = false;
        } else if(Xcoords < -4) {
            isMovingToRight = true;
        }
        //move the ground
        if(isMovingToRight) {
            transform.Translate(speed, 0, 0);
        } else {
            transform.Translate(-speed, 0, 0);
        }
    }

}
