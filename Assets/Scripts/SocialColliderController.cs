using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SocialColliderController : MonoBehaviour {

    List<Collider> _colliders = new List<Collider>();

    public int NumFriendsToEngage = 3;
    public string TagFriends = "AgentGood";

    void OnTriggerEnter(Collider other)
    {
        RemoveNullColliders();

        if(!_colliders.Contains(other))
            _colliders.Add(other);

        int nbFriends = 0;
        for (int i = 0; i < _colliders.Count; i++)
        {
            if (_colliders[i] != null && _colliders[i].tag == TagFriends)
                nbFriends++;
        }

        if(nbFriends >= NumFriendsToEngage)
        {
            AgentController self = transform.parent.GetComponentInParent<AgentController>();

            if (self.IsScared())
            {
                FearState fs = self.currentState as FearState;
                Transform hunter = null;
                if (fs != null)
                {
                    hunter = fs.GetHunter();
                }

                foreach (Collider c in _colliders)
                {
                    if(c.tag == TagFriends)
                    {
                        AgentController ac = c.transform.gameObject.GetComponentInParent<AgentController>();
                        if (ac.IsExploring())
                        {
                            IdleState ist = ac.currentState as IdleState;
                            ist.AskCounterStrike(hunter);
                        }
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (_colliders.Contains(other))
        {
            _colliders.Remove(other);
        }
    }

    private void RemoveNullColliders()
    {
        for (int i = 0; i < _colliders.Count; i++)
        {
            if (_colliders[i] == null)
            {
                _colliders.Remove(_colliders[i]);
            }
        }
    }
}
