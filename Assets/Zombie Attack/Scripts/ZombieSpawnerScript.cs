using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieSpawnerScript : MonoBehaviour
{
    public float spawnTime = 4;
    public GameObject zombiePrefab;
    public Transform target;

    public float spawnRange = 10;

    public UnityEvent ZombieDied;

    void Start()
    {
        //SpawnZombie();
        InvokeRepeating("SpawnZombie", 2, spawnTime);
    }

    public Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-spawnRange,spawnRange), 1, Random.Range(-spawnRange,spawnRange));
    }

    public void SpawnZombie()
    {
        // ADD CODE HERE
        GameObject instance;
        instance = Instantiate(zombiePrefab, RandomPosition(), Quaternion.identity);
        instance.GetComponent<ZombieScript>().Init(target, this);
        // END OF CODE
    }
    IEnumerator ZombieSpawnRepeater()
    {
        yield return new WaitForSeconds(spawnTime);
    }

    public void ZombieHasDied()
    {
        ZombieDied?.Invoke();
    }
}
