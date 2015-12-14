using UnityEngine;
using System.Collections;

public class FearState : IAgentState 
{
	private readonly AgentController agent;
    private Transform hunter;

	public FearState (AgentController agentCtrl)
	{
		agent = agentCtrl;
	}
	
	public void UpdateState()
	{
		agent.nav.Stop();
		agent.meshRendererFlag.material.color = Color.red;

        if(agent.nav.remainingDistance < 2.0f)
        {
            agent.nav.SetDestination(agent.transform.position + 10 * (agent.transform.position - hunter.transform.position).normalized);
        }
    }
	
	public void OnTriggerEnter (Collider other)
	{
		Debug.Log ("Scared Agent entered on something");
	}

    public void OnSee(RaycastHit hit)
    {
        if(hit.collider && hit.transform.tag == "Pickup")
        {
            agent.nav.SetDestination(hit.transform.position);
        }
    }

    public void SetHunter(Transform t)
    {
        hunter = t;
    }

    public void ToIdleState()
	{
		agent.currentState = agent.idleState;
	}
	
	public void ToFearState()
	{
        Debug.Log("Transition forbidden");
    }
	
	public void ToEngageState()
	{
        Debug.Log("Transition forbidden");
    }

    public void ToHuntState()
    {
        Debug.Log("Transition forbidden");
    }

    public void ToCounterState()
    {
        Debug.Log("Transition forbidden");
    }
}