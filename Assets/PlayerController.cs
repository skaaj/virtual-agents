using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float velocity;

    private float rotationX;
    private float rotationY;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        rotationX += Input.GetAxis("Mouse X") * Time.deltaTime * 100;
        rotationY += Input.GetAxis("Mouse Y") * Time.deltaTime * 100;
        rotationY = Mathf.Clamp(rotationY, -90, 90);

        transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

        Vector3 dv = new Vector3(Input.GetAxis("Horizontal") * velocity, 0, Input.GetAxis("Vertical") * velocity);
        transform.position += dv;
	}
}
