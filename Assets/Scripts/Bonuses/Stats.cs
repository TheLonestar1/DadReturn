using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Stats", order = 1)]
public class Stats : ScriptableObject
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float jumpStrength = 1f;

    public float Speed { get { return moveSpeed; } }
    public float JumpStrength { get { return jumpStrength; } }
}