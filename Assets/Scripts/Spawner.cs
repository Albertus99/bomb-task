using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector3 spawnExtents;
    [SerializeField] private GameObject[] spawnables;
    [SerializeField] private float spawnInterval = 2;

    private void Start()
    {
        Setup();
    }

    public void Setup()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            var x = Random.Range(spawnExtents.x, -spawnExtents.x);
            var y = Random.Range(spawnExtents.y, -spawnExtents.y);
            var z = Random.Range(spawnExtents.z, -spawnExtents.z);

            Vector3 position = transform.position + new Vector3(x, y, z) * 0.5f;

            Instantiate(spawnables[Random.Range(0, spawnables.Length)], position, Quaternion.identity); //тут вполне мог мы быть пул)
            
            yield return new WaitForSeconds(spawnInterval);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, spawnExtents);
    }
}
