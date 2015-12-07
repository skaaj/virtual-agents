using UnityEngine;

public interface IAgentState
{
	void UpdateState();
	
	void OnTriggerEnter (Collider other);
	
	void ToIdleState();
	
	void ToHuntState();

    void ToFearState();
    
    void ToEngageState();

	void ToCounterState();
}