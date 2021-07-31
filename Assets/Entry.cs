using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entry : MonoBehaviour
{
    [SerializeField] private Spawner explosiveSpawner;
    [SerializeField] private Spawner characterSpawner;
    void Start()
    {
        explosiveSpawner.Setup();
        characterSpawner.Setup();
    }


}
