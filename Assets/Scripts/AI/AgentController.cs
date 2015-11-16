using UnityEngine;
using System.Collections;

public class AgentController : MonoBehaviour {

	public MeshRenderer meshRendererFlag;
    public float health;

	[HideInInspector] public IAgentState currentState;
	[HideInInspector] public IdleState idleState;
	[HideInInspector] public FearState fearState;
	[HideInInspector] public EngageState engageState;
	[HideInInspector] public NavMeshAgent nav;
	
	private void Awake()
	{
		idleState  = new IdleState (this);
		fearState  = new FearState (this);
		engageState = new EngageState (this);
		
		nav = GetComponent<NavMeshAgent> ();
        health = 100;
	}
	
	// Use this for initialization
	void Start () 
	{
		currentState = idleState;
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentState.UpdateState ();
	}
	
	private void OnTriggerEnter(Collider other)
	{
		currentState.OnTriggerEnter (other);
	}
}