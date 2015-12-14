using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {

    // Param initiaux
    public float energy;
    public int cooldown;

    // Param utilises en interne
    private float _initialEnergy;
    private int _initialCooldown;
    private float _timestamp;

	void Start ()
    {
        _initialEnergy = energy;
        _initialCooldown = cooldown;

        Initialize();
        _timestamp = Time.time;
	}

    void Update ()
    {
    }

    public bool CanRespawn ()
    {
        return Time.time >= _timestamp;
    }

    public void Initialize()
    {
        energy = _initialEnergy + Random.Range(-10, 10);
        cooldown = _initialCooldown + Random.Range(-2, 2);

        // Dans ce monde virtuel le temps a une limite
        _timestamp = int.MaxValue;
    }

    void OnDisable ()
    {
        _timestamp = Time.time + cooldown;
    }
}
