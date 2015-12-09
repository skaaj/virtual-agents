using UnityEngine;
using System.Collections;

public class CounterState : IAgentState 
	
{
	private readonly AgentController agent;
	
	public CounterState (AgentController agentCtrl)
	{
		agent = agentCtrl;
	}

	public void UpdateState()
	{
		// do stuff
	}
	
	public void OnTriggerEnter (Collider other)
	{
        // do stuff
	}

    public void ToIdleState()
    {
        agent.currentState = agent.idleState;
    }

	public void ToFearState()
	{
		agent.currentState = agent.fearState;
	}

    public void ToCounterState()
    {
        Debug.LogError("Transition to same state forbidden");
    }

    public void ToEngageState()
	{
        Debug.Log("Transition forbidden");
    }

    public void ToHuntState()
    {
        Debug.Log("Transition forbidden");
    }
}