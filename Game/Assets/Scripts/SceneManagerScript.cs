using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour {

    [Header("Fire Potion")]
    public GameObject screenTaskUI;
    public GameObject fireSpell;
    public Image IngredientUnlock1;
    public Image IngredientUnlock2;
    public Image IngredientUnlock3;
    public Text requirementsText;

    public void Update()
    {
        // Fire Potion
        if (PersistentManagerScript.Instance.firePotion == true)
        {
            screenTaskUI.SetActive(true);
        }
        else
        {
            screenTaskUI.SetActive(false);
        }
        if (PersistentManagerScript.Instance.Ingredient1 == true) {
            IngredientUnlock1.color = new Color(255.0F, 255.0F, 255.0F, 255.0F);
        } else {
            IngredientUnlock1.color = new Color(0.0F, 0.0F, 0.0F, 255.0F);
        }

        if (PersistentManagerScript.Instance.Ingredient2 == true)
        {
            IngredientUnlock2.color = new Color(255.0F, 255.0F, 255.0F, 255.0F);
        }
        else
        {
            IngredientUnlock2.color = new Color(0.0F, 0.0F, 0.0F, 255.0F);
        }

        if (PersistentManagerScript.Instance.Ingredient3 == true)
        {
            IngredientUnlock3.color = new Color(255.0F, 255.0F, 255.0F, 255.0F);
        }
        else
        {
            IngredientUnlock3.color = new Color(0.0F, 0.0F, 0.0F, 255.0F);
        }

        if((PersistentManagerScript.Instance.Ingredient1 == true) && 
            (PersistentManagerScript.Instance.Ingredient2 == true) && 
            (PersistentManagerScript.Instance.Ingredient3 == true))
        {
            requirementsText.text = "Collected all ingredients! Go to the Cauldron to brew your potion!";
        }
        else
        {
            requirementsText.text = "You need to collect the following ingredients:";
        }
        if (PersistentManagerScript.Instance.fireSpell == true)
        {
            fireSpell.SetActive(true); //Use fire spell
        }
    }

    public void GoToFirstScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void GoToSecondScene()
    {
        SceneManager.LoadScene("Test2");
    }
}
