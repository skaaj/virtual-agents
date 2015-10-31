using UnityEngine;
using System.Collections;

public class FearState : IAgentState 
	
{
	private readonly AgentController agent;
	
	public FearState (AgentController agentCtrl)
	{
		agent = agentCtrl;
	}
	
	public void UpdateState()
	{
		agent.nav.Stop ();
		agent.meshRendererFlag.material.color = Color.red;
	}
	
	public void OnTriggerEnter (Collider other)
	{
		Debug.Log ("Scared Agent entered on something.");
	}
	
	public void ToIdleState()
	{
		agent.currentState = agent.idleState;
	}
	
	public void ToFearState()
	{
		agent.currentState = agent.fearState;
	}
	
	public void ToEngageState()
	{
		agent.currentState = agent.engageState;
	}
}