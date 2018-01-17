using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDrag : MonoBehaviour {
    public static Rigidbody rb;
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.drag = 20;
	}
	
    public static void reduceTheDrag()
    {
        rb.drag = rb.drag - 3;

    }

	// Update is called once per frame
	void Update () {
		
	}
}
