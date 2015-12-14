using UnityEngine;
using System.Collections;

public abstract class AgentController : MonoBehaviour {

	public MeshRenderer meshRendererFlag;
    public float health;

	[HideInInspector] public IAgentState currentState;
	[HideInInspector] public NavMeshAgent nav;
    [HideInInspector] public IdleState idleState;
    [HideInInspector] public HuntState huntState;
    [HideInInspector] public FearState fearState;
    [HideInInspector] public CounterState counterState;
    [HideInInspector] public EngageState engageState;

	protected void Awake()
	{
        idleState = new IdleState(this);
        huntState = new HuntState(this);
        fearState = new FearState(this);
        engageState = new EngageState(this);
        counterState = new CounterState(this);

		nav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	private void Update () 
	{
		currentState.UpdateState ();
	}
	
	private void OnTriggerEnter(Collider other)
	{
		currentState.OnTriggerEnter (other);
	}

    public void OnSee(RaycastHit hit)
    {
        currentState.OnSee(hit);
    }
}