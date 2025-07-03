using UnityEngine;

public class Zadatak3 : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    
    private GameObject cube;
    
    void Start()
    {
        cube = GetGameObject();
        Debug.Log("Initial position: " + cube.transform.position);
        Invoke(nameof(ChangeAndPrintCubePosition), 1.5f);
    }

    private GameObject GetGameObject()
    {
        return Instantiate(prefab);
    }

    private void ChangeAndPrintCubePosition()
    {
        Vector3 position = GetRandomPosition(-100, 101);
        cube.transform.position = position;
        
        Debug.Log("End position: " + cube.transform.position);
    }
    
    private Vector3 GetRandomPosition(int min, int max)
    {
        int x = Random.Range(min, max);
        int y = Random.Range(min, max);
        int z = Random.Range(min, max);
        
        return new Vector3(x, y, z);
    }
}
