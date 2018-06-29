using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnObject : MonoBehaviour {
	
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Reactable")) {
            Destroy(other.gameObject);
        }
    }
}
