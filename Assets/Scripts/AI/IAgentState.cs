using UnityEngine;

public interface IAgentState
{
	void UpdateState();
	
	void OnTriggerEnter (Collider other);

    void OnSee(RaycastHit hit);
	
	void ToIdleState();
	
	void ToHuntState();

    void ToFearState();
    
    void ToEngageState();

	void ToCounterState();
}