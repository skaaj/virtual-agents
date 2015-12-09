using UnityEngine;
using System.Collections;

public class AgentControllerHunter : AgentController {

    void Start()
    {
        currentState = huntState;
    }

	private new void Awake()
	{
        base.Awake();

        health = 200;
	}

}