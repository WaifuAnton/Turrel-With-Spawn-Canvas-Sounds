using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    [SerializeField] Slider slider;

    void Awake()
    {
        Messenger<int>.AddListener(GameEvent.HEALTH_CHANGED, OnHealthChanged);
    }

    void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.HEALTH_CHANGED, OnHealthChanged);
    }
 	// Use this for initialization
	void Start () {
        slider.value = 100;
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnHealthChanged(int health)
    {
        slider.value = health;
    }
}
