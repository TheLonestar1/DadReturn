using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Stats", menuName = "Stats", order = 3)]
public class Stats : ScriptableObject
{
    [SerializeField] private List<Stat> stats = new List<Stat>();

    public float GetStatValue(StatType type)
    {
        foreach (var stat in stats)
        {
            if (stat.Type == type)
            {
                return stat.Value;
            }
        }

        return -1;
    }

    [System.Serializable]
    public class Stat
    {
        [SerializeField] private StatType type;
        [SerializeField] private float value;

        public StatType Type { get { return type; } }
        public float Value { get { return value; } }
    }
}