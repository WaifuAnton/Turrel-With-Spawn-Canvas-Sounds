using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastFire : MonoBehaviour {
    public int damage = 5;
    Camera playerCamera;
	// Use this for initialization
	void Start () {
        playerCamera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(playerCamera.pixelWidth / 2, playerCamera.pixelHeight / 2);
            Ray ray = playerCamera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                ActiveEnemy enemy = hit.transform.gameObject.GetComponent<ActiveEnemy>();
                if (enemy != null)
                    enemy.health -= damage;                    
            }
        }
	}
}
