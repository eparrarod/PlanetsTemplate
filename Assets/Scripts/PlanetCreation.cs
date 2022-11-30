using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCreation : MonoBehaviour {

    public static PlanetCreation instance; // Ensures that there is only one object of this type at runtime
    public GameObject restartPanel;
    private GameObject[] planets;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    // Awake is called 
    void Awake() {
        instance = this;
        // Loop to create n planets
            // Use Istantiate
            // set the reset panel

    }

    public void pause() {
        Debug.Log("Pause");
        foreach (GameObject p in planets) {
            Debug.Log("p: -> " + p);
            Drag dragScript = p.GetComponent<Drag>();
            Debug.Log("ds-> " + dragScript);
        }
    }
}
