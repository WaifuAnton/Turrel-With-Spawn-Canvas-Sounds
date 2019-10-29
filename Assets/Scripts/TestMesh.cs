using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestMesh : MonoBehaviour {
    [SerializeField] Transform target;
    Transform[] wayPoints;
    NavMeshAgent agent;
    public float timeWait;
    float curTimeWait = 0;
    int i;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        wayPoints = new Transform[target.childCount];
        for (i = 0; i < wayPoints.Length; i++)
            wayPoints[i] = target.GetChild(i);
        i = 0;
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(wayPoints[i].position);
        if(!agent.hasPath)
        {
            curTimeWait += Time.deltaTime;
            if (curTimeWait > timeWait)
            {
                curTimeWait = 0;
                if (i == wayPoints.Length - 1)
                    i = 0;
                else
                    i++;
            }
        }
	}
}
