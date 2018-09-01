using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //--Public variable visible from Unity Editor
    public float speed;
    public float tilt;
    public Boundary boundary;

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