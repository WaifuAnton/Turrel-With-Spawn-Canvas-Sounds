using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float speed = 300;
    public int damage = 5;
    public float maxDistance = 300;
    Vector3 startPos, curPos;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        curPos = transform.position;
        if (Vector3.Distance(startPos, curPos) > maxDistance)
            Destroy(gameObject);
	}

    void OnTriggerEnter(Collider other)
    {
        ActiveEnemy enemy = other.GetComponent<ActiveEnemy>();
        if (enemy != null)
        {
            enemy.health -= damage;
            Debug.Log(enemy.health);
        }
        else
            Debug.Log(false);
        Destroy(gameObject);
    }
}
