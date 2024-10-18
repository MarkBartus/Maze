using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pathfinding : MonoBehaviour
{
    public Transform[] points;
    private NavMeshAgent path;
    private int destPoint;

    // Start is called before the first frame update
    void Start()
    {
        path = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!path.pathPending && path.remainingDistance < 0.5f)
            GoToNextPoint();
    }


    void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        path.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

}
