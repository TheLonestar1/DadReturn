using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Не используется
public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _playerObject;
    
    void Start()
    {
        Instantiate(_playerObject, transform.position, transform.rotation);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "SpawnIcon");
    }
}
