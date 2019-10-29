using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEnemy : MonoBehaviour {
    public int health = 5;
    //float curHealth;
	// Use this for initialization
	void Start () {
        //curHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            //iTween.RotateTo(gameObject, new Vector3(0, transform.position.y, 0), 2);
            Destroy(gameObject);
            Messenger.Broadcast(GameEvent.TURRELS_NUMBER_CHANGED);
        }
	}
}
