using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour {

    private const float originalSpeed = 0.16f;
    private float carSpeed = originalSpeed;
    
    void Start() {
    }

    void Update() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            //move car when long pressed
            if(touch.phase == TouchPhase.Stationary) {
                transform.Translate(0, 0, carSpeed);
            }
        }
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "MovableLeft" || collision.gameObject.tag == "MovableRight") {
        }
        //slow down car
        if(collision.gameObject.tag == "Slow") {
            carSpeed = originalSpeed * 0.5f;
        }
        //speed up car
        if(collision.gameObject.tag == "SpeedUp") {
            carSpeed = originalSpeed * 2;
        }
        //reaffect original car speed
        if(collision.gameObject.tag == "NormalGround" || collision.gameObject.tag == "Respawn") {
            carSpeed = originalSpeed;
        }
    }
    
    void OnCollisionStay(Collision collision) {
        //follow movement of ground
        transform.SetParent(collision.collider.transform);
    }
    
    void OnCollisionExit(Collision collision) {
        //follow movement of ground
        transform.SetParent(null);
    }

}
