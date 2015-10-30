using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour {
	
	public Transform goal;
	private NavMeshAgent agent;
	public float hp;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		ChangeGoal ();
	}

	void Update() {
		if (agent.remainingDistance < 1.0f) {
			ChangeGoal();
		}

		hp += Time.deltaTime;
	}

	void ChangeGoal() {
		agent.destination = new Vector3 (Random.Range (0, 50), Random.Range (0, 50), Random.Range (0, 50));
	}
}