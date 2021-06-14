using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    [Min(0f)]
    public float SpawnInitialDelay;
    [Min(0f)]
    public float TimeBetweenSpawn;
    [Min(0)]
    public int NumObjectsToSpawn;
    [Min(0f)]
    public float SpawnRangeX;
    [Min(0f)]
    public float SpawnRangeY;

    private float remainingTime; 
    
    // Start is called before the first frame update
    void Start()
    {
        remainingTime = SpawnInitialDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime >= 0)
        {
            remainingTime -= Time.deltaTime;
            return;
        }

        for (int i = 0; i < NumObjectsToSpawn; ++i)
        {
            GameObject objToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
            Vector3 pos = transform.position + Vector3.up * Random.Range(-SpawnRangeY, SpawnRangeY) 
                          + Vector3.right *Random.Range(-SpawnRangeX, SpawnRangeX);

            Instantiate(objToSpawn, pos, Quaternion.identity);
        }

        remainingTime = TimeBetweenSpawn;
    }
}
