using System;
using System.Collections;
using UnityEngine;

public class Zadaca2 : MonoBehaviour
{
    private void Start()
    {
        InvokeRepeating(nameof(EruptPeriodically), 2, 5);
    }

    private void EruptPeriodically()
    {
        StartCoroutine(PrintVulkanErupting());
    }

    private IEnumerator PrintVulkanErupting()
    {
        Debug.Log($"Vulkan will erupt in 2 seconds!");
        yield return new WaitForSeconds(2f);
        Debug.Log($"Vulkan erupted");
    }
}
