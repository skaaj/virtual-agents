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

	}

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Idle Agent entered on something.");
    }

    public void ToHuntState()
    {
        agent.currentState = agent.huntState;
    }

    public void ToEngageState()
    {
        Debug.LogError("Transition to same state forbidden");
    }

    public void ToIdleState()
	{
		Debug.LogError("Transition forbidden");
	}
	
	public void ToFearState()
	{
        Debug.LogError("Transition forbidden: Agent engaged until death");
    }

    public void ToCounterState()
    {
        Debug.LogError("Transition forbidden");
    }
}