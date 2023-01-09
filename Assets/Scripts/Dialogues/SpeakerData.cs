using UnityEngine;

// Информация о спикере, выводящаяся в окно диалога
[CreateAssetMenu(fileName = "NewSpeakerData", menuName = "Dialogues/Create New Speaker", order = 2)]
public class SpeakerData : ScriptableObject
{
    public string speakerName;
    public Sprite portrait;
    public Color color;
}