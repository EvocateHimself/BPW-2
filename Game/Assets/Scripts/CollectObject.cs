using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectObject : MonoBehaviour {

    public string ingredientName;
    public Transform player;
    public Text collectWarn;

    void Start ()
    {
        collectWarn.enabled = false;
    }
    
    void OnMouseDown()
    {
        float dist = Vector3.Distance(player.position, transform.position);

        if (dist < 5)
        {
            if (ingredientName == "Ingredient1") {
                PersistentManagerScript.Instance.Ingredient1 = true; //Set bool to true
            }

            if (ingredientName == "Ingredient2")
            {
                PersistentManagerScript.Instance.Ingredient2 = true; //Set bool to true
            }

            if (ingredientName == "Ingredient3")
            {
                PersistentManagerScript.Instance.Ingredient3 = true; //Set bool to true
            }
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            StartCoroutine(TimedWarn(4));
        }
    }

    private IEnumerator TimedWarn(float duration)
    {
        collectWarn.enabled = true;
        gameObject.GetComponentInChildren<Renderer>().enabled = false;
        gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
        collectWarn.text = "You picked up a " + (name) + "!";
        yield return new WaitForSeconds(duration);
        collectWarn.enabled = false;
        Destroy(gameObject);
    }
}
