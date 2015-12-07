using UnityEngine;
using System.Collections;

public class CounterState : IAgentState 
	
{
	private readonly AgentController agent;
	
	public CounterState (AgentController agentCtrl)
	{
		agent = agentCtrl;
	}
	
	// Interface Agent State Implementation

	public void UpdateState()
	{
		Move ();
	}
	
	public void OnTriggerEnter (Collider other)
	{
        string name = other.gameObject.tag;

        Debug.Log("Idle Agent entered on " + name);

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
                Debug.Log("GTFO!");
                break;
            default:
                break;
        }
	}


    public void ToIdleState()
    {
        agent.currentState = agent.idleState;
    }

	public void ToCounterState()
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

	// User methods

	public void Move ()
	{
		if (agent.nav.remainingDistance < 5) {
			agent.nav.destination = Debug_GetRandomDestination ();
			//Debug.Log("Yay! I'm now going to " + agent.nav.destination.ToString() + "!");
		}

        // Bouger consomme de l'energie
        agent.health -= Time.deltaTime;
	}

	private Vector3 Debug_GetRandomDestination()
	{
		return new Vector3(Random.Range (-50, 50), 0, Random.Range (-50, 50));
	}
}