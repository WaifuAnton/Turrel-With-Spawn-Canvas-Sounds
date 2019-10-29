using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurrelFire : MonoBehaviour {    
    public float fireRate = 1;
    public float timeWait = 1;
    [SerializeField] GameObject bulletPrefab;
    GameObject bullet;
    public Transform target;
    Transform[] wayPoints;
    [SerializeField] Transform rayPoint;
    [SerializeField] Transform[] bulletPositions;
    LineRenderer lineRenderer;
    AudioSource[] source;
    AudioSource laserSource;
    NavMeshAgent agent;
    int i = 0;
    int j = 0;
    float curRate = 0.00001f;
    float curTimeWait;
    float rot;
	// Use this for initialization
	void Start () {
        lineRenderer = rayPoint.GetComponent<LineRenderer>();
        laserSource = rayPoint.GetComponent<AudioSource>();
        source = new AudioSource[bulletPositions.Length];
        for (int j = 0; j < bulletPositions.Length; j++)
        {
            source[j] = bulletPositions[j].parent.GetComponent<AudioSource>();
            source[j].Stop();
        }
        agent = GetComponent<NavMeshAgent>();
        wayPoints = new Transform[target.childCount];
        for (int j = 0; j < target.childCount; j++)
            wayPoints[j] = target.GetChild(j);
    }

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        if (Physics.Raycast(rayPoint.position, transform.forward, out hit))
        {
            MainCharacter character = hit.transform.gameObject.GetComponent<MainCharacter>();
            if (character != null && character.health != 0)
            {
                agent.isStopped = true;
                //transform.LookAt(character.transform);
                //transform.rotation = Quaternion.Euler(transform.eulerAngles.x, rot, transform.eulerAngles.z);
                laserSource.PlayOneShot(laserSource.clip);
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, rayPoint.position);
                lineRenderer.SetPosition(1, hit.point);
                if (curRate > fireRate)
                {
                    source[i].PlayOneShot(source[i].clip);
                    curRate = 0;
                    if (i == bulletPositions.Length - 1)
                        i = 0;
                    else
                        i++;
                    bullet = Instantiate(bulletPrefab);
                    bullet.transform.position = bulletPositions[i].position;
                    bullet.transform.rotation = bulletPositions[i].rotation;
                }
                curRate += Time.deltaTime;
            }
            else
            {
                lineRenderer.positionCount = 0;
                Move();
            }
        }
        else
            Move();
    }

    void Move()
    {
        agent.isStopped = false;
        agent.SetDestination(wayPoints[j].position);
        if (!agent.hasPath)
        {
            curTimeWait += Time.deltaTime;
            if (curTimeWait > timeWait)
            {
                curTimeWait = 0;
                if (j == wayPoints.Length - 1)
                    j = 0;
                else
                    j++;
            }
        }
    }
}
