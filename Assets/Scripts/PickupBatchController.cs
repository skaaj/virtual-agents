using UnityEngine;
using System.Collections;

public class PickupBatchController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        foreach (Transform child in this.transform)
        {
            PickupController pc = child.GetComponent<PickupController>();
            if(pc.CanRespawn())
                pc.gameObject.SetActive(true);
        }
    }
}
