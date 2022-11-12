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

    [SerializeField] private GameObject prefabShootLevelEvent;
    [SerializeField] private GameObject prefabJumpLevelEvent;
    [SerializeField] private GameObject prefabShootPlayerEvent;
    [SerializeField] private GameObject prefabJumpPlayerEvent;
    
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
            playerEvent.UpdatePosition(relativeSpeed);
        }
    }

    private void HandleLevelEvents(float relativeSpeed)
    {
        foreach (LevelEvent levelEvent in _upcomingLevelEvents)
        {
            levelEvent.UpdatePosition(relativeSpeed);
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
        GameObject playerEventObject = Instantiate(prefabJumpPlayerEvent);
        PlayerEvent playerEvent = playerEventObject.GetComponent<PlayerEvent>();

        _upcomingPlayerEvents.Add(playerEvent);
        eventDownTime = playerEvent.duration + Random.Range(minimumEventDowntime, maximumEventDowntime);
    }

    public void SpawnJumpLevelEvent()
    {
        GameObject levelEventObject = Instantiate(prefabJumpLevelEvent);
        LevelEvent levelEvent = levelEventObject.GetComponent<LevelEvent>();

        _upcomingLevelEvents.Add(levelEvent);
    }

    public void SpawnShootLevelEvent()
    {
        GameObject levelEventObject = Instantiate(prefabShootLevelEvent);
        LevelEvent levelEvent = levelEventObject.GetComponent<LevelEvent>();

        _upcomingLevelEvents.Add(levelEvent);
    }
}
