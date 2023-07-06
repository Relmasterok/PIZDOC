using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPC : MonoBehaviour
{
    private NavMeshAgent _NPC;
    public Transform _PLAYER;
    void Start()
    {
        _NPC = GetComponent<NavMeshAgent>();
    }
    
    void FixedUpdate()
    {
        _NPC.SetDestination(_PLAYER.position);
    }
}
