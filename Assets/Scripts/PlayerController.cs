using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float velocity;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;
		float dx = Input.GetAxis ("Horizontal") * velocity * dt;
		float dz = Input.GetAxis ("Vertical") * velocity * dt;

		transform.Translate(new Vector3 (dx, 0.0f, dz));
	}
}
