using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //--Public variable visible from Unity Editor
    public float speed;
    public float tilt;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire = 0.0f;

    //--Executing the code just before updating the frame
    public void Update()
    {
        if ((Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space)) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            var audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Rigidbody rigidbody = GetComponent<Rigidbody>();

        var movement = new Vector3(moveHorizontal, 0, moveVertical);
        rigidbody.velocity = movement * speed;
        rigidbody.position = new Vector3
        {   x = Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            y = 0,
            z = Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
        };
        rigidbody.rotation = Quaternion.Euler(0, 0, rigidbody.velocity.x * -tilt);
    }
}

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}