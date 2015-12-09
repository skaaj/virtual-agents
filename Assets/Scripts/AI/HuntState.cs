using UnityEngine;
using System.Collections;

public class HuntState : IAgentState 
{
	private readonly AgentController agent;
	
	public HuntState (AgentController agentCtrl)
	{
		agent = agentCtrl;
	}

	public void UpdateState()
	{
        agent.nav.SetDestination(Vector3.zero);
	}
	
	public void OnTriggerEnter (Collider other)
	{
        // some code here
	}

    public void ToEngageState()
    {
        agent.currentState = agent.engageState;
    }

    public void ToHuntState()
	{
		Debug.LogError ("Transition to same state forbidden");
	}
	
	public void ToFearState()
	{
        Debug.LogError("Hunters are never scared!");
    }

    public void ToIdleState()
    {
        Debug.LogError("Transition forbidden");
    }

    public void ToCounterState()
    {
        Debug.LogError("Transition forbidden");
    }
}