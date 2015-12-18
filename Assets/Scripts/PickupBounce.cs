using UnityEngine;
using System.Collections;

public class PickupBounce : MonoBehaviour {
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "PickupSphere")
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * 15.0f, ForceMode.Acceleration);
        }
    }
}
