using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cloud;

    private float eventDownTime = 2;
    private const float MinimumEventDowntime = 0.2f;
    private const float MaximumEventDowntime = 1f;

    private void Update()
    {
        SpawnCloud();
    }

    private void SpawnCloud()
    {
        eventDownTime -= Time.timeSinceLevelLoad;

        if (eventDownTime > 0)
        {
            return;
        }

        eventDownTime = Random.Range(MinimumEventDowntime, MaximumEventDowntime);
        Instantiate(cloud, new Vector3(1000, 0, 0), Quaternion.identity);
    }
}