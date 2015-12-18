using UnityEngine;
using System.Collections;

public class CounterState : IAgentState 
	
{
	private readonly AgentController agent;

    private Transform hunter;

	public CounterState (AgentController agentCtrl)
	{
		agent = agentCtrl;
	}

	public void UpdateState()
	{
        if (hunter == null)
        {
            ToIdleState();
            return;
        }
        agent.nav.SetDestination(hunter.position);

        if(Vector3.Distance(agent.transform.position, hunter.position) < 5.0f)
        {
            AgentController ac = hunter.gameObject.GetComponent<AgentController>();
            ac.health -= 5 * Time.deltaTime;
            agent.health += 5 * Time.deltaTime;
        }

        agent.meshRendererFlag.material.color = Color.green;
    }
	
    public void SetTarget(Transform target)
    {
        hunter = target;
    }

	public void OnTriggerEnter (Collider other)
	{
	}

    public void OnSee(RaycastHit hit)
    {
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