using UnityEngine;
using System.Collections;

public class PickupBounce : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Debug.LogError("OHMYGAAAAAD!");
    }

    void OnTriggerStay(Collider other)
    {
        Debug.LogError("IOUGJFEIOZHGLIGKUHE");
        if (other.tag == "PickupSphere")
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * 15.0f, ForceMode.Acceleration);
        }
    }
}
