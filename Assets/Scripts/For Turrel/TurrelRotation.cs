using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrelRotation : MonoBehaviour {
    public float minAngle = -90, 
        maxAngle = 90,
        rotationSpeed = 5;
    float curRotation = 0;

    void Start()
    {      
        //Debug.Log(curRotation);
        minAngle += curRotation;
        maxAngle += curRotation;
        if (minAngle > 180)
            minAngle -= 360;
        if (maxAngle > 180)
            maxAngle -= 360;
        //Debug.Log(minAngle);
        //Debug.Log(maxAngle);
    }

    void Update()
    {
        //curRotation = transform.eulerAngles.y;
        if (curRotation > 180)
            curRotation -= 360;
        //curRotation = Mathf.Clamp(curRotation, minAngle, maxAngle);
            //Debug.Log(curRotation);
            curRotation += rotationSpeed;
            transform.rotation = Quaternion.Euler(0, curRotation, 0);
        //Debug.Log(curRotation);
    }

}
