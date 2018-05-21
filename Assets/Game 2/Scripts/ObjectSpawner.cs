using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    public GameObject[] objectSpawn;
    public Transform[] spawnPoints;

    public float minDelay = .1f;
    public float maxDelay = 1f;

    void Start()
    {
        StartCoroutine(SpawnObject());
        StartCoroutine(SpawnObject2());
    }
    IEnumerator SpawnObject()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            GameObject spawnObject = Instantiate(objectSpawn[0], spawnPoint.position, spawnPoint.rotation);

            Destroy(spawnObject, 5f);
        }
    }
    IEnumerator SpawnObject2()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            GameObject spawnObject = Instantiate(objectSpawn[1], spawnPoint.position, spawnPoint.rotation);

            Destroy(spawnObject, 5f);
        }
    }
}
