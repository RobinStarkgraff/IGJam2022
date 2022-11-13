using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cloud;

    private int speed = 2;

    private float eventDownTime = 0;
    private const float MinimumEventDowntime = 0.5f;
    private const float MaximumEventDowntime = 3;

    private void Update()
    {
        SpawnCloud();
    }

    private void SpawnCloud()
    {
        if (eventDownTime <= 0)
        {
            eventDownTime -= Time.deltaTime;
            return;
        }

        eventDownTime = Random.Range(MinimumEventDowntime, MaximumEventDowntime);
        Instantiate(cloud, new Vector3(1000, 0, 0), Quaternion.identity);
    }
}