﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EyeController : MonoBehaviour {

    private Vector3 direction;
    private RaycastHit hit;
    private List<RaycastHit> hits;


    public LayerMask cullingMask;
    public int fov;
    public int numRays;

    // Use this for initialization
    void Start () {
        InvokeRepeating("CastRays", 0f, 0.1f);
	}

    void Awake()
    {
        hits = new List<RaycastHit>();
    }
	
	// Update is called once per frame
	void Update () {
        //CastRays();
	}

    void CastRays()
    {
        int currentAngle = fov / -2;
        int offsetRays = fov / numRays;

        hits.Clear();

        for (int i = 0; i < numRays; i++)
        {
            direction = Quaternion.AngleAxis(currentAngle, transform.up) * transform.forward;
            hit = new RaycastHit();

            if (Physics.Raycast(transform.position, direction, out hit, 15, cullingMask) == false)
            {
                hit.point = transform.position + (direction * 15);
            }

            hits.Add(hit);

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
