using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour {
    Collision col;
    
	// Use this for initialization
	void start () {

	}


    // Update is called once per frame
    void OnCollisionEnter (Collision col) {
        if (col.gameObject.name == "Cube")
        {
            Application.Quit();
        }

	}
}
