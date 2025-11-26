using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // These numbers is the box location where the items will be able to be spawned into 
    [SerializeField] private float minX = 0f; 
    [SerializeField] private float maxX = 0f;
    [SerializeField] private float minZ = 0f;
    [SerializeField] private float maxZ = 0f;

    // How high above the ground the items will drop from
    [SerializeField] private float spawnHeight = 0f;

    // All of the object prefabs stored in this array
    [SerializeField] private GameObject[] itemPrefabs;

    // How long to wait before next item spawn
    [SerializeField] private float spawnTime = 0f;

    // Timer that counts up every frame so we know when to spawn something
   private float timer;

    void Update()
    {
        // Add the time between frames towards the timer
        timer += Time.deltaTime;

        // If the timer is bigger than the spawnTime that means its time to spawn a new object
        if (timer >= spawnTime)
        {
            SpawnItem(); // Drops a randomly chosen item
            timer = 0f; // Resets the counter
        }
    }

    void SpawnItem()
    {
        // Picks a random X and Z position inside the allowed spawn area
        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);

        // This is the spot in the world the objects will actually appear in
        Vector3 spawnPosition = new Vector3(x, spawnHeight, z);

        // Choose one of the random prefabs from the itemPrefabs list
        GameObject prefab = itemPrefabs[Random.Range(0, itemPrefabs.Length)];
        
        // Actually spawn the object at the randomly selected position
        Instantiate(prefab, spawnPosition, Quaternion.identity); 
    }
}
