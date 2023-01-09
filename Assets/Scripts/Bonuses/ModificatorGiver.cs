using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Modificator))]
public class ModificatorGiver : MonoBehaviour
{
    [SerializeField] private Modificator modificator;

    private void Start()
    {
        modificator = GetComponent<Modificator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var statsManager = other.GetComponent<StatsManager>();
        if (statsManager) 
        {
            statsManager.AddModificator(modificator);
        }
    }
}
