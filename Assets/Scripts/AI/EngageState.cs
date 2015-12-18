using UnityEngine;
using System.Collections;

public class EngageState : IAgentState 
{
	private readonly AgentController agent;
    private Transform target;

    private bool onlyOnce = true;

	public EngageState (AgentController agentCtrl)
	{
		agent = agentCtrl;
	}
	
	public void UpdateState()
	{
        if (onlyOnce)
        {
            agent.meshRendererFlag.material.color = Color.cyan;
            onlyOnce = false;
        }

        if (target == null)
        {
            ToHuntState();
            return;
        }

        agent.nav.SetDestination(target.position);

        if (Vector3.Distance(target.position, agent.transform.position) < 2.0f)
        {
            AgentController ac = target.gameObject.GetComponent<AgentController>();
            ac.health -= 10 * Time.deltaTime;
            agent.health += 10 * Time.deltaTime;
        }
        else if (Vector3.Distance(target.position, agent.transform.position) > 20.0f)
        {
            ToHuntState();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Idle Agent entered on something.");
    }

    public void OnSee(RaycastHit hit)
    {
        //
    }

    public void SetTarget(Transform t)
    {
        target = t;
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