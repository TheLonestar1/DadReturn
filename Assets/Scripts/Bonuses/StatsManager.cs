using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField] private Stats stats;
    [SerializeField] private List<Modificator> modificators = new List<Modificator>();

    public void AddModificator(Modificator modificator)
    {
        // Если игрок подобрал модификатор такого же типа, но с другими характеристиками
        RemoveModificator(modificator.Type);
        modificators.Add(modificator);
    }

    public void RemoveModificator(StatType type)
    {
        for (int i = 0; i < modificators.Count; i++)
        {
            if (modificators[i].Type == type)
            {
                modificators.Remove(modificators[i]);
            }
        }
    }

    public float GetModifiedStat(StatType type)
    {
        return stats.GetStatValue(type) * GetModificators(type);
    }

    private float GetModificators(StatType type)
    {
        float percentage = 1f;
        foreach (var mod in modificators)
        {
            if (mod.Type == type)
            {
                percentage += (mod.Percentage / 100);
            }
        }

        return percentage;
    }

    
}
