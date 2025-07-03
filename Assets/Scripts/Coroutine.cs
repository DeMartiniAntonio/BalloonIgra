using System;
using System.Collections;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int length;

    private void Start()
    {
        StartCoroutine(CoroutineForLoop(length));
    }

    private IEnumerator CoroutineForLoop(int length)
    {
        for (int i = 0; i < length; i++)
        {
            InstantiateCube(i);
            yield return new WaitForSeconds(0.5f);
        }
        
        yield return new WaitForSeconds(1);
    }
    
    private void InstantiateCube(int i)
    {
        Instantiate(prefab, new Vector3(0, i, i), Quaternion.identity);
    }
}
