using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
        if (agent.nav.remainingDistance < 2.0f || agent.nav.pathStatus == NavMeshPathStatus.PathPartial)
        {
            agent.nav.destination = GetRandomDestination();
        }

        // Bouger consomme de l'energie
        agent.health -= Time.deltaTime;

        if(agent.health < 50)
        {
            bool exit = false;
            int i = 0;
            List<Transform> knownPlaces = agent.GetPlaces();
            while (i < knownPlaces.Count && !exit)
            {
                if (Vector3.Distance(knownPlaces[i].position, agent.transform.position) < 75)
                {
                    agent.nav.SetDestination(knownPlaces[i].position);
                    exit = true;
                }
                i++;
            }
        }

        agent.meshRendererFlag.material.color = Color.white;
    }

    public void AskCounterStrike(Transform hunter)
    {
        if(hunter != null)
        {
            agent.counterState.SetTarget(hunter);
            ToCounterState();
        }
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
                agent.SavePlace(other.transform);
                break;
            case "AgentGood":
                Debug.Log("Hello Mister!");
                break;
            case "AgentBad":
                agent.fearState.SetHunter(other.transform);
                ToFearState();
                break;
            default:
                break;
        }
    }

    public void OnSee(RaycastHit hit)
    {
        if (hit.collider && hit.collider.gameObject.tag == "Pickup")
        {
            agent.nav.destination = hit.collider.transform.position;
        }
    }

    private Vector3 GetRandomDestination()
    {
        return new Vector3(Random.Range(-250, 250), 0, Random.Range(-250, 250));
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