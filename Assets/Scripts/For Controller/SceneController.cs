using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
    [SerializeField] TurrelFire turrel;
    TurrelFire[] turrelOb;
    public int turrelsNumber = 3;
    int curTurrelsNumber = 0;
    [SerializeField] Transform turrelTarget;
    Transform targ;

    void Awake()
    {
        Messenger.AddListener(GameEvent.TURRELS_NUMBER_CHANGED, OnTurrelsNumberChanged);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.TURRELS_NUMBER_CHANGED, OnTurrelsNumberChanged);
    }
	// Use this for initialization
	void Start () {
        turrel.target = turrelTarget;
        targ = turrel.target;
        //Debug.Log(targ.position);
        turrelOb = new TurrelFire[turrelsNumber];
	}
	
	// Update is called once per frame
	void Update () {
        if (curTurrelsNumber == 0)
            while (curTurrelsNumber < turrelsNumber)
            {
                turrelOb[curTurrelsNumber] = Instantiate(turrel);
                turrelOb[curTurrelsNumber].transform.position = Vector3.left * curTurrelsNumber;
                turrelOb[curTurrelsNumber].target.position = targ.position * (curTurrelsNumber + 1);
                //Debug.Log(turrelOb[curTurrelsNumber].target.position);
                curTurrelsNumber++;
            }            
	}

    void OnTurrelsNumberChanged()
    {
        curTurrelsNumber--;
    }
}
