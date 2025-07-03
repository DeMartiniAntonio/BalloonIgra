using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Zadatak2 : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;

    private void Start()
    {
        StartCoroutine(CoroutineForLoop());
    }

    private IEnumerator CoroutineForLoop()
    {
        int index = GetRandomNumber(prefabs.Length);
        
        Instantiate(prefabs[index], GetRandomPosition(-1000, 1001), Quaternion.identity);

        yield return new WaitForSeconds(5);
        
        StartCoroutine(CoroutineForLoop());
    }
    
    private int GetRandomNumber(int length)
    {
        return Random.Range(0, length);
    }
    
    private Vector3 GetRandomPosition(int min, int max)
    {
        int x = Random.Range(min, max);
        int y = Random.Range(min, max);
        int z = Random.Range(min, max);
        
        return new Vector3(x, y, z);
    }
}
