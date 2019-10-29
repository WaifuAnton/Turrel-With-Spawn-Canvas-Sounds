using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    CharacterController character;
    public float speed;
	// Use this for initialization
	void Start () {
        character = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movement;
        float deltaX = Input.GetAxis("Horizontal") * speed,
            deltaZ = Input.GetAxis("Vertical") * speed;
        movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        character.Move(movement);
	}
}
