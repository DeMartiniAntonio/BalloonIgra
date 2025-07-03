using System;
using System.Collections;
using UnityEngine;

public class Petlja : MonoBehaviour
{
    private void Start()
    {
        //StartCoroutine(Loop());
        InvokeRepeating(nameof(Print), 5, 3);
    }

    private IEnumerator Loop()
    {
        Debug.Log($"Start");
        
        yield return new WaitForSeconds(5);

        for (int i = 0; i < 10; i++)
        {
            Debug.Log($"Nešto");
        }

        Debug.Log($"Done");
    }

    private void Print()
    {
        Debug.Log($"Nešto");
    }
}
