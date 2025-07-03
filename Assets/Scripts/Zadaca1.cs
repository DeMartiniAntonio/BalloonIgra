using System.Collections;
using UnityEngine;

public class Zadaca1 : MonoBehaviour
{
    [SerializeField] private GameObject powerUpPrefab;
    
    private GameObject powerUpGO;
    
    private bool isPoweredUp;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isPoweredUp)
        {
            StartCoroutine(GetPowerUp());
        }       
    }

    private IEnumerator GetPowerUp()
    {
        isPoweredUp = true;
        
        if (!powerUpGO)
        {
            powerUpGO = Instantiate(powerUpPrefab,
                new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), Quaternion.identity);
        }
        else
        {
            powerUpGO.SetActive(true);
        }
        
        yield return new WaitForSeconds(5);
        powerUpGO.SetActive(false);
        
        isPoweredUp = false;
    }
}
