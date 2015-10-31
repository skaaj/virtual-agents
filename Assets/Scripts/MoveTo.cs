using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour {
	
public Vector3 goal;
	private NavMeshAgent agent;
	public float hp;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		ChangeGoal ();
	}

	void Update() {
		if (agent.remainingDistance < 1.0f) {
			ChangeGoal();
			agent.destination = goal;
		}

		hp -= Time.deltaTime;
	}

	void ChangeGoal() {
		//goal = new Vector3 (Random.Range (-50, 50), Random.Range (-50, 50), Random.Range (-50, 50));
		goal = new Vector3 (0, 0, 45);
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("We entered on something");

		if (other.gameObject.CompareTag ("Pickup"))
		{
			other.gameObject.SetActive (false);
			hp += 100;
		}
	}
}