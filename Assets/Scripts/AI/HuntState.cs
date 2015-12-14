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
        agent.meshRendererFlag.material.color = Color.magenta;

        if (agent.nav.remainingDistance < 5)
        {
            agent.nav.destination = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
        }

        // Bouger consomme de l'energie
        agent.health -= Time.deltaTime;
    }
	
	public void OnTriggerEnter (Collider other)
	{
        // some code here
	}

    public void OnSee(RaycastHit hit)
    {
        if (hit.collider && hit.collider.gameObject.tag == "AgentGood")
        {
            agent.engageState.SetTarget(hit.collider.transform);
            ToEngageState();
        }
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