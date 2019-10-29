using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour {
    public int health = 100;

    public void ChangeHealth(int value)
    {
        health += value;
        Messenger<int>.Broadcast(GameEvent.HEALTH_CHANGED, health);
        if (health == 0)
            Die();
    }

    public void Die()
    {
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }
}
