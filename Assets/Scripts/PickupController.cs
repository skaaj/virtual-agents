using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {

    public float energy;
    public int cooldown;

    private float _timestamp;

	void Start () {
        energy += Random.Range(-10, 10);
        cooldown += Random.Range(-2, 2);
	}

    void Update ()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        if (mr.material.color.a < 1)
        {
            Color color = mr.material.color;
            color.a += (Time.deltaTime / 50.0f);
            mr.material.color = color;
        }
    }

    public bool CanRespawn ()
    {
        return Time.time >= _timestamp;
    }

    void OnDisable ()
    {
        print("Disabled!");
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Color color = mr.material.color;
        color.a = 0.0f;
        mr.material.color = color;
        _timestamp = Time.time + cooldown;
    }
}
