using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMobs : MonoBehaviour
{

    public GameObject mob;
    public GameObject[] spawnPoint;
    public float timeForSpawner;
    float time;

    private void Start()
    {
        time = timeForSpawner;
    }

    private void Update()
    {
        if (time <= 0)
            Spawn();
        else
            time -= Time.deltaTime;
    }

    void Spawn()
    {
        time = timeForSpawner;
        var nomer = Random.Range(0, spawnPoint.Length);
        Instantiate(mob, spawnPoint[nomer].transform.position, spawnPoint[nomer].transform.rotation);
    }

}
