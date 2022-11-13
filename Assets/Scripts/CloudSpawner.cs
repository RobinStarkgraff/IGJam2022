using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cloud;

    private float eventDownTime = 0;
    private const float MinimumEventDowntime = 5.5f;
    private const float MaximumEventDowntime = 20;

    private void Update()
    {
        SpawnCloud();
    }

    private void SpawnCloud()
    {
        eventDownTime -= Time.deltaTime;

        if (eventDownTime > 0)
        {
            return;
        }

        eventDownTime = Random.Range(MinimumEventDowntime, MaximumEventDowntime) / GameController.Instance.GetGameSpeed();
        Instantiate(cloud, new Vector3(1000, 0, 0), Quaternion.identity);
    }
}