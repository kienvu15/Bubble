using System.Collections;
using UnityEngine;

public class InfinitePrefabSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] prefabs; 
    [SerializeField] private float spawnDelay = 1f; 

    [SerializeField] private float minX = -15f; 
    [SerializeField] private float maxX = 17f;  
    [SerializeField] private float fixedY = -5f;

    [SerializeField] private float minGravity = -0.3f; 
    [SerializeField] private float maxGravity = -1f;

    private Coroutine spawnCoroutine;

    void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnPrefabsForever());
    }

    IEnumerator SpawnPrefabsForever()
    {
        while (true)
        {
            SpawnPrefabAtRandomPosition();
            float randomDelay = Random.Range(1f, 3f);
            yield return new WaitForSeconds(randomDelay);
        }
    }

    void SpawnPrefabAtRandomPosition()
    {
        if (prefabs.Length == 0) return;

        GameObject randomPrefab = prefabs[Random.Range(0, prefabs.Length)];

        
        float spawnX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(spawnX, fixedY, 0);

       
        GameObject spawnedObject = Instantiate(randomPrefab, spawnPosition, Quaternion.identity);

        
        Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = Random.Range(minGravity, maxGravity);
        }
    }

    public void StopSpawning()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }
}
