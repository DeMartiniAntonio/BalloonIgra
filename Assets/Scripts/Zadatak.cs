using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak : MonoBehaviour
{
    [SerializeField] private GameObject stairPrefab;
    [SerializeField] private GameObject gatePrefab;
    [SerializeField] private int length;
    void Start()
    {
        StartCoroutine(CreateStairs());
    }

    private void Update()
    {
        InvokeRepeating(nameof(Instantiate), 0.001f, 0.001f);
    }

    private IEnumerator CreateStairs()
    {
        for (int i = 0; i < length; i++)
        {
            InstantiateCube(i, stairPrefab);
            yield return new WaitForSeconds(0.2f);
        }
        
        InstantiateCube(length, gatePrefab);
        
        yield return new WaitForSeconds(1);
    }
    
    private void InstantiateCube(int i, GameObject prefab)
    {
        Instantiate(prefab, new Vector3(0, prefab.transform.position.y + i, prefab.transform.position.z + i), Quaternion.identity);
    }
    
    private void Instantiate(int a)
    {
        for (int i = 0; i < int.MaxValue; i++)
        {
            Instantiate(stairPrefab, new Vector3(0,0,0), Quaternion.identity);
        }
    }
}
