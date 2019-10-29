using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
    public enum Mouse { X, Y }
    public Mouse MouseAxis;
    public float minRotation = -45, maxRotation = 45;
    public float rotationSpeed = 9;
    float rotation = 0;
    float rotY;
	// Use this for initialization
	void Start () {
        rotY = transform.localRotation.y;
    }
	
	// Update is called once per frame
	void Update () {
		switch(MouseAxis)
        {
            case (Mouse.X):
                transform.Rotate(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);
                break;
            case (Mouse.Y):
                rotation -= Input.GetAxis("Mouse Y") * rotationSpeed;                
                rotation = Mathf.Clamp(rotation, minRotation, maxRotation);
                transform.localRotation = Quaternion.Euler(rotation, rotY, 0);
                break;
        }
	}
}
