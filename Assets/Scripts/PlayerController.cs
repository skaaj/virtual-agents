using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float velocity;
	public float _jumpForce = 100.0f;
	public float _gravity = 10.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;
		float dx = Input.GetAxis ("Horizontal");
		float dy = 0.0f;
		float dz = Input.GetAxis ("Vertical");

		CharacterController cc = GetComponent<CharacterController>();

		if (Input.GetButton ("Jump") && cc.isGrounded)
			dy = _jumpForce;

		cc.Move (new Vector3 (dx, (dy - _gravity), dz) * velocity * dt);
	}
}
