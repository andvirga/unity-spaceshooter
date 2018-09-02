using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble;

	// Use this for initialization
	public void Start ()
    {
        var rigidBody = GetComponent<Rigidbody>();

        rigidBody.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
