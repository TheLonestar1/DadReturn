using UnityEngine;

public class Modificator : MonoBehaviour
{
    [SerializeField] private StatType type;
    // Модифицируется в процентах
    [SerializeField] private float percentage;
    [SerializeField] private int additionalHealth;
 
    public StatType Type { get { return type; } }
    public float Percentage { get { return percentage; } }
    public int AdditionalHealth { get { return additionalHealth; } }
}