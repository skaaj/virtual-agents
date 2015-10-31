using UnityEngine;

public interface IAgentState
{
	
	void UpdateState();
	
	void OnTriggerEnter (Collider other);
	
	void ToIdleState();
	
	void ToFearState();

	void ToEngageState();
}