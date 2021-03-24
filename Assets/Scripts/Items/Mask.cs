using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PickUpItems>().ShowMask(true);
            Destroy(gameObject);
        }
    }
}
