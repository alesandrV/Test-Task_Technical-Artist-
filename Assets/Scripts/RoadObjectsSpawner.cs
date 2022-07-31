using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObjectsSpawner : MonoBehaviour
{
    
    [SerializeField] private GameObject[] objectsToInstantiate;

    [Space(10)]

    public float xRangeNum;
    public float zRangeNum;

    [Space(10)]

    private float xAxisPos;
    private float zAxisPos;
    private float yAxisPos = 0.5f;

    private float numOfObjects;
    [SerializeField] private int maxNumberOfObjects = 5;

    void Start()
    {
        numOfObjects = 0;
    }

    void Update()
    {
        if (numOfObjects <= maxNumberOfObjects)
        {
            SpawnObjectOnRoad();
            numOfObjects++;
        }
    }

    // Randomly generate objects (prefab, generated position, orientation).
    private void SpawnObjectOnRoad()
    {
        xAxisPos = Random.Range(-xRangeNum, xRangeNum);
        zAxisPos = Random.Range(-zRangeNum, zRangeNum);

        Instantiate(objectsToInstantiate[Random.Range(0, 2)], new Vector3(xAxisPos, yAxisPos, zAxisPos), Quaternion.identity);
    }
}
