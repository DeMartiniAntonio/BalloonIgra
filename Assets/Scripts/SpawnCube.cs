using System.Collections;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    
    void Start()
    {
        StartCoroutine(CreateStairs());
    }

    private IEnumerator CreateStairs(int i = 0)
    {
        InstantiateCube(i);
        
        yield return new WaitForSeconds(1);

        i++;
        
        StartCoroutine(CreateStairs(i));
    }

    private void InstantiateCube(int i)
    {
        Instantiate(prefab, new Vector3(0, i, i), Quaternion.identity);
    }
}
