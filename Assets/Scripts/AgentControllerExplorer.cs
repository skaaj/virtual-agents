using UnityEngine;
using System.Collections;

public class AgentControllerExplorer : AgentController {

    // Use this for initialization
    void Start()
    {
        currentState = idleState;
    }

	private new void Awake()
	{
        base.Awake();

        health = 500;
	}
}