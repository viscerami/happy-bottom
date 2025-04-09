using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject trashPrefab; 
    public float spawnInterval = 30f; 

    private void Start()
    {
        InvokeRepeating("SpawnTrash", 30f, spawnInterval);
    }

    void SpawnTrash()
    {
        float randomX = Random.Range(-8f, 8f); 
        Vector2 spawnPosition = new Vector2(randomX, 6f); 
        Instantiate(trashPrefab, spawnPosition, Quaternion.identity);
    }
}
