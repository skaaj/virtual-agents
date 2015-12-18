using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EyeController : MonoBehaviour {

    private Vector3 direction;
    private RaycastHit hit;
    private List<RaycastHit> hits = new List<RaycastHit>();

    public LayerMask cullingMask;
    public int fov;
    public int numRays;
    public int viewingDistance;

    private int currentAngle;
    private int offsetRays;

    public NavMeshAgent agent;

    // Use this for initialization
    void Start () {
        //InvokeRepeating("CastRays", 0f, 0.05f);
	}

    void Awake()
    {
        offsetRays = fov / numRays;

        if (viewingDistance == 0)
            viewingDistance = 15;
    }

    // Update is called once per frame
    void Update () {
        CastRays();
	}

    void CastRays()
    {
        currentAngle = fov / -2;
        hits.Clear();

        for (int i = 0; i < numRays; i++)
        {
            direction = Quaternion.AngleAxis(currentAngle, transform.up) * transform.forward;
            hit = new RaycastHit();

            if (Physics.Raycast(transform.position, direction, out hit, viewingDistance, cullingMask) == false)
            {
                hit.point = transform.position + (direction * viewingDistance);
            }

            hits.Add(hit);

            AgentController ac = GetComponentInParent<AgentController>();
            if(ac != null)
            {
                ac.OnSee(hit);
            }

            currentAngle += offsetRays;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;

        if (hits.Count > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                Gizmos.DrawSphere(hit.point, 0.04f);
                Gizmos.DrawLine(transform.position, hit.point);
            }
        }
    }
}
