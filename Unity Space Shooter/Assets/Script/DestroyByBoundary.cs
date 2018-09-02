using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    //--This method is executed when the collider exits the trigger
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
