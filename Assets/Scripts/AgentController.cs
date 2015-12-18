using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AgentController : MonoBehaviour {

	public MeshRenderer meshRendererFlag;
    public float health;

    private List<Transform> _positivePlaces = new List<Transform>();

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

        health -= Time.deltaTime;

        if(health <= 0)
        {
            Destroy(transform.gameObject);
        }
	}
	
	private void OnTriggerEnter(Collider other)
	{
		currentState.OnTriggerEnter (other);
	}

    public void OnSee(RaycastHit hit)
    {
        currentState.OnSee(hit);
    }

    public void SavePlace(Transform t)
    {
        _positivePlaces.Add(t);
    }

    public List<Transform> GetPlaces()
    {
        return _positivePlaces;
    }

    public bool IsScared()
    {
        return ReferenceEquals(currentState.GetType(), fearState.GetType());
    }

    public bool IsExploring()
    {
        return ReferenceEquals(currentState.GetType(), idleState.GetType());
    }
}