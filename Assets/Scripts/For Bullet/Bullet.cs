using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public int damage = 10;
    public float speed = 100;
    public float radius = 300;
    Vector3 pos;
	// Use this for initialization
	void Start () {
        pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, speed * Time.deltaTime);
        if (Vector3.Distance(pos, transform.position) > radius)
            Destroy(gameObject);
	}

    void OnTriggerEnter(Collider other)
    {
        MainCharacter character = other.GetComponent<MainCharacter>();
        //TurrelRotation turrel = other.GetComponent<TurrelRotation>();
        if (character != null)
            character.ChangeHealth(-damage);
        Destroy(gameObject);
    }
}
