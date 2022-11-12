using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    private readonly List<PlayerEvent> _upcomingPlayerEvents = new List<PlayerEvent>();
    private readonly List<LevelEvent> _upcomingLevelEvents = new List<LevelEvent>();
    public Sprite shape;
    [SerializeField] private int gameSpeed = 3;
    [SerializeField] private int minimumEventDowntime = 2;
    [SerializeField] private int maximumEventDowntime = 4;

    private float eventDownTime = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnPlayerEvent();
    }

    private void Update()
    {
        float relativeSpeed = gameSpeed * Time.deltaTime;

        RandomPlayerEventSpawner();

        HandlePlayerEvents(relativeSpeed);
        HandleLevelEvents(relativeSpeed);
    }

    private void HandlePlayerEvents(float relativeSpeed)
    {
        foreach (PlayerEvent playerEvent in _upcomingPlayerEvents)
        {
            playerEvent.progress -= relativeSpeed;
            playerEvent.UpdatePosition();
        }
    }

    private void HandleLevelEvents(float relativeSpeed)
    {
        foreach (LevelEvent levelEvent in _upcomingLevelEvents)
        {
            levelEvent.progress -= relativeSpeed * 2;
            levelEvent.UpdatePosition();
        }
    }

    public void RandomPlayerEventSpawner()
    {
        eventDownTime -= Time.deltaTime;

        if (eventDownTime > 0)
        {
            return;
        }

        SpawnPlayerEvent();
    }

    public void SpawnPlayerEvent()
    {
        GameObject newObject = new GameObject();
        PlayerEvent playerEvent = newObject.AddComponent<PlayerEvent>();
        playerEvent.UpdatePosition();
        _upcomingPlayerEvents.Add(playerEvent);

        playerEvent.StartPoint = new Vector3(4, 4.4f,0);
        playerEvent.EndPoint = new Vector3(-4, 4.4f,0);

        eventDownTime = playerEvent.duration + Random.Range(minimumEventDowntime, maximumEventDowntime);
    }

    public void SpawnLevelEvent()
    {
        GameObject levelObject = new GameObject();
        levelObject.AddComponent<BoxCollider2D>().isTrigger = true;
        LevelEvent levelEvent = levelObject.AddComponent<LevelEvent>();
        levelEvent.UpdatePosition();
        _upcomingLevelEvents.Add(levelEvent);
        
        levelEvent.StartPoint = new Vector3(9, 0,0);
        levelEvent.EndPoint = new Vector3(-4, 0,0);

    }
}
