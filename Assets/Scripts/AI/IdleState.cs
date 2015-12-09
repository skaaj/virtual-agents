using UnityEngine;
using System.Collections;

public class IdleState : IAgentState 
{
	private readonly AgentController agent;
	
	public IdleState (AgentController agentCtrl)
	{
		agent = agentCtrl;
	}

    public void UpdateState()
    {
        Move();
    }

    public void Move()
    {
        if (agent.nav.remainingDistance < 5)
        {
            agent.nav.destination = Debug_GetRandomDestination();
        }

        // Bouger consomme de l'energie
        agent.health -= Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        string name = other.gameObject.tag;

        Debug.Log("Exploring Agent entered on " + name);

        switch (name)
        {
            case "Pickup":
                PickupController pc = other.GetComponent<PickupController>();
                other.gameObject.SetActive(false);
                agent.health += pc.energy;
                break;
            case "AgentGood":
                Debug.Log("Hello Mister!");
                break;
            case "AgentBad":
                ToFearState();
                break;
            default:
                break;
        }
    }

    private Vector3 Debug_GetRandomDestination()
    {
        return new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
    }

    // States' transitions Implementations

    public void ToFearState()
    {
        agent.currentState = agent.fearState;
    }

    public void ToCounterState()
    {
        agent.currentState = agent.counterState;
    }

    public void ToIdleState()
    {
        Debug.LogError("Transition to same state forbidden.");
    }

    public void ToEngageState()
	{
        Debug.LogError("Transition forbidden");
	}

    public void ToHuntState()
    {
        Debug.LogError("Transition forbidden");
    }
}