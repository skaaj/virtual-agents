using UnityEngine;
using System.Collections;

public class EngageState : IAgentState 
	
{
	private readonly AgentController agent;
	
	public EngageState (AgentController agentCtrl)
	{
		agent = agentCtrl;
	}
	
	public void UpdateState()
	{
		agent.nav.destination = Debug_GetRandomDestination ();
	}
	
	public void OnTriggerEnter (Collider other)
	{
		Debug.Log ("Idle Agent entered on something.");
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
	
	private Vector3 Debug_GetRandomDestination()
	{
		return new Vector3(Random.Range (-50, 50), 0, Random.Range (-50, 50));
	}
}