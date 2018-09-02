using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContect : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    //--This method is executed when the collider enters into the trigger
    private void OnTriggerEnter(Collider other)
    {
        //--Ignoring the collisions with boundary
        if (other.tag == "Boundary")
            return;

        //--Instantiates asteroid explosion
        Instantiate(explosion, this.transform.position, this.transform.rotation);

        //--Instantiates player explosion (if collides with the asteroid)
        if (other.tag == "Player")
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

        Destroy(other.gameObject); //--destroy the collider
        Destroy(this.gameObject);  //--destroy the asteroid
    }
}
