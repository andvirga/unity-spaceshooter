using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    //Public variable
    public float speed;

	// Use this for initialization
	public void Start ()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = transform.forward * speed;
    }
	
}
