using UnityEngine;
using System.Collections;

public class SunController : MonoBehaviour {

    void Start()
    {
        transform.eulerAngles = new Vector3(Time.deltaTime, 0, 0);
    }

	void Update () {
        float angle = transform.rotation.eulerAngles.x;

        if(angle > 10 && angle < 170)
        {
            transform.Rotate(new Vector3(Time.deltaTime * 10, 0, 0));
        }
        else if(angle >= 170 && angle < 195 || angle < 10 || angle >= 350)
        {
            transform.Rotate(new Vector3(Time.deltaTime / 10, 0, 0));
        }
        else if(angle >= 195 && angle < 350)
        {
            transform.Rotate(new Vector3(Time.deltaTime * 40, 0, 0));
        }
    }
}
