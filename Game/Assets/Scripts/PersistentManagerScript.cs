using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentManagerScript : MonoBehaviour {

    public static PersistentManagerScript Instance { get; private set; }

    //public int Value;

    // Variables that need to be saved between scenes
    [Header("Fire Potion")]
    public bool fireSpell;
    public bool firePotion;
    public bool Ingredient1;
    public bool Ingredient2;
    public bool Ingredient3;

    // Set all variables to 0 or false
    void Start() {
        Ingredient1 = false;
        Ingredient2 = false;
        Ingredient3 = false;
        firePotion = false;
        fireSpell = false;
}

    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
