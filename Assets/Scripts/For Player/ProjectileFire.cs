using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFire : MonoBehaviour {
    [SerializeField] Transform firePoint;
    [SerializeField] Projectile projectile;
    GameObject projectileOb;
	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            // = new Vector3(playerCamera.pixelWidth / 2, playerCamera.pixelHeight / 2);
            projectileOb = Instantiate(projectile.gameObject, firePoint.position, transform.rotation);
        }
	}
}
