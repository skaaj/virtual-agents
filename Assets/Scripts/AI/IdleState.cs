using UnityEngine;
using System.Collections;

public class IdleState : IAgentState 
	
{
	private readonly AgentController agent;
	
	public IdleState (AgentController agentCtrl)
	{
		agent = agentCtrl;
	}
	
	// Interface Agent State Implementation

	public void UpdateState()
	{
		Move ();
	}
	
	public void OnTriggerEnter (Collider other)
	{
		Debug.Log ("Idle Agent entered on something.");

		//ToFearState ();
        other.gameObject.SetActive(false);
        PickupController pc = other.GetComponent<PickupController>();
        agent.health += pc.energy;
	}
	
	public void ToIdleState()
	{
		Debug.LogError ("Can't transition to same state");
	}
	
	public void ToFearState()
	{
		agent.currentState = agent.fearState;
	}
	
	public void ToEngageState()
	{
		agent.currentState = agent.engageState;
	}

	// User methods

	public void Move ()
	{
		if (agent.nav.remainingDistance < 5) {
			agent.nav.destination = Debug_GetRandomDestination ();
			Debug.Log("Yay! I'm now going to " + agent.nav.destination.ToString() + "!");
		}
	}

	private Vector3 Debug_GetRandomDestination()
	{
		return new Vector3(Random.Range (-50, 50), 0, Random.Range (-50, 50));
	}
}