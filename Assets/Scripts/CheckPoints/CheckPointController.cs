using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 curretCheckPoint;
    void Start()
    {
        curretCheckPoint = transform.position;
        CheckPointSave.OnSavePoint += SaveNewPoint;
        StaticTrap.OnEnteringTrap += TeleportOnPoint;
    }

    void SaveNewPoint(Vector3 point)
    {
        curretCheckPoint = point;
    }
    
    void TeleportOnPoint()
    {
        transform.position = curretCheckPoint;
    }
}
