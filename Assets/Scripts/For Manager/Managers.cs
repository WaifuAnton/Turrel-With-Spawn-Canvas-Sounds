using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour {
    public static DataManager Data { get; private set; }
    public static PlayerManager Player { get; private set; }

    void Awake()
    {
        Data = GetComponent<DataManager>();
        Player = GetComponent<PlayerManager>();
    }
}
