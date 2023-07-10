using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class NPC : MonoBehaviour
{
    private NavMeshAgent _NPC;
    public Transform _PLAYER;
    public List<Transform> _points = new List<Transform>();

    public string targetTag = "Player";
    public int rays = 8;
    public int distance = 33;
    public float angle = 40;
    public Vector3 offset;
    public Transform target;


    private bool _Pogona = false;
    float _chaseRange = 10f;

    bool GetRaycast(Vector3 dir)
    {
        bool result = false;
        RaycastHit hit = new RaycastHit();
        Vector3 pos = transform.position + offset;
        if (Physics.Raycast(pos, dir, out hit, distance))
        {
            if (hit.transform == target)
            {
                result = true;
                Debug.DrawLine(pos, hit.point, Color.green);
            }
            else
            {
                Debug.DrawLine(pos, hit.point, Color.blue);
            }
        }
        else
        {
            Debug.DrawRay(pos, dir * distance, Color.red);
        }
        return result;
    }

    bool RayToScan()
    {
        bool result = false;
        bool a = false;
        bool b = false;
        float j = 0;
        for (int i = 0; i < rays; i++)
        {
            var x = Mathf.Sin(j);
            var y = Mathf.Cos(j);

            j += angle * Mathf.Deg2Rad / rays;

            Vector3 dir = transform.TransformDirection(new Vector3(x, 0, y));
            if (GetRaycast(dir)) a = true;

            if (x != 0)
            {
                dir = transform.TransformDirection(new Vector3(-x, 0, y));
                if (GetRaycast(dir)) b = true;
            }
        }

        if (a || b) result = true;
        return result;
    }
    void Start()
    {
        _NPC = GetComponent<NavMeshAgent>();
        _NPC.SetDestination(_points[Random.Range(0, _points.Count)].position);
    }
    
    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.forward);
        if(_NPC.remainingDistance <= _NPC.stoppingDistance)
            _NPC.SetDestination(_points[Random.Range(0,_points.Count)].position);
        float dist = Vector3.Distance(transform.position, _PLAYER.position);
        if (RayToScan()) _Pogona = true;
        if (_Pogona) _NPC.SetDestination(_PLAYER.position);
        if (!RayToScan()) _Pogona = false;
    }

}
