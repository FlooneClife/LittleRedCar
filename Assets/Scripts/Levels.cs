using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Levels : MonoBehaviour {
    public GameObject car;
    public GameObject finishZone;
    public ParticleSystem confettis;

    private string levelName;
    private string nextLevelName;
    private int levelNumber;
    private TextMeshProUGUI textLevelNumber;
    private GameObject canvas;
    private Transform child;
    
    void Start() {
        canvas = GameObject.Find("Canvas");
        child = canvas.transform.Find("Level");
        levelName = SceneManager.GetActiveScene().name.ToString();
        textLevelNumber = child.GetComponent<TextMeshProUGUI>();
        levelNumber = int.Parse(levelName.Substring(5));
        textLevelNumber.text = "Level " + levelNumber;
        nextLevelName = "Level" + (levelNumber + 1);
        if(levelNumber != 1) {
            confettis.Play();
        }
    }

    void Update() {
        //if the car has reached the finish zone
        if((car.transform.position.z >= finishZone.transform.position.z - 1) &&
           ((car.transform.position.y > 1.10f) && (car.transform.position.y < 1.40f))) {
            SceneManager.LoadScene(nextLevelName);
            confettis.Play();
        }
        //if the car has fallen off
        if(car.transform.position.y < -5.0f) {
            car.transform.position = new Vector3(0.0f, 1.25f, -0.5f); //respawn
        }
    }

}
