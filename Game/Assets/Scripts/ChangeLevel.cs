using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {

    public GameObject sceneManager;
    public string scene;
    public Color loadToColor = Color.white;
    public float speed;

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            if(tag == "Forest")
            {
                GoFade();
                //sceneManager.GetComponent<SceneManagerScript>().GoToSecondScene(); //Switch scene
            }
            else if (tag == "Home")
            {
                GoFade();
                //sceneManager.GetComponent<SceneManagerScript>().GoToFirstScene(); //Switch scene
            }

        }
    }

    public void GoFade()
    {
        Initiate.Fade(scene, loadToColor, speed);
    }
}
