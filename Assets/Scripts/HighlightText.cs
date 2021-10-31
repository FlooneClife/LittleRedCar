using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighlightText : MonoBehaviour {

    public TextMeshProUGUI text;

    private bool increase;
    private float speed = 1.5f;
    private float alphaValue = 150.0f;

    void Start() {
        increase = true;
    }

    void Update() {
        if(increase) {
            alphaValue += speed;
            if(alphaValue >= 220.0f) {
                increase = false;
            }
        } else {
            alphaValue -= speed;
            if(alphaValue <= 50.0f) {
                increase = true;
            }
        }
        text.color = new Color32(200, 200, 200, (byte)alphaValue);
    }

    public void RemoveText() {
        if (Input.touchCount > 0) {
            text.gameObject.SetActive(false);
        }
    }

}
