using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    // Start is called before the first frame update
    int maxHealth;
    int health;

    void Start()
    {
        StaticTrap.OnEnteringTrap += TakeDamage;
    }
    void TakeDamage()
    {
        health--;
        GetComponent<Health>().DecreasHealth();
        if (health < 0)
        {
            Debug.Log("GameOver");
        }
    }
}
