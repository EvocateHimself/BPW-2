using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenScreen : MonoBehaviour {

    //[SerializeField]
    public GameObject bookUI;
    public Transform player;
    public string potionName;

    void Start() {
        bookUI.SetActive(false);
    }

    void Update() {
        float dist = Vector3.Distance(player.position, transform.position);

        if (dist > 5) {
            bookUI.SetActive(false);
        }
    }

    void OnMouseDown() {
        float dist = Vector3.Distance(player.position, transform.position);

        if (dist < 5)
        {
            if (potionName == "FirePotion")
            {
                PersistentManagerScript.Instance.firePotion = true; //Set bool to true
                bookUI.SetActive(true);
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
            }
        }
    }
}
