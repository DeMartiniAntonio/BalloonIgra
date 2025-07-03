using System;
using System.Collections;
using UnityEngine;

public class Zadatak4 : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    private bool isRegenerating;

    private void Update()
    {
        StartCoroutine(CheckHealth());
    }
    
    private IEnumerator CheckHealth()
    {
        if (currentHealth < maxHealth && !isRegenerating)
        {
            isRegenerating = true;
            yield return StartCoroutine(RegenerateHealth());
        }
    }

    private IEnumerator RegenerateHealth()
    {
        yield return new WaitForSeconds(5f);
        while (currentHealth < maxHealth)
        {
            currentHealth++;
            yield return new WaitForSeconds(1f);
        }
        
        isRegenerating = false;
    }
}
