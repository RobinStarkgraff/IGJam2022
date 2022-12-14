using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    [SerializeField] private GameObject prefabProjectile;
    

    private float gameSpeed = 0;
    [SerializeField] private float minimumEventDowntime = 0.5f;
    [SerializeField] private float maximumEventDowntime = 3;

    public int Score = 0;

    private float eventDownTime = 0;

    public TMP_Text ScoreText;
    
    private void Awake()
    {
        Instance = this;
        Time.timeScale = 0;
    }

    public float GetGameSpeed()
    {
        return gameSpeed;
    }

    private void Update()
    {
        float relativeSpeed = gameSpeed * Time.deltaTime;

        RandomPlayerEventSpawner();

        HandlePlayerEvents(relativeSpeed);
        HandleLevelEvents(relativeSpeed);
        EnvironmentController.Instance.UpdateTexture(relativeSpeed);
        ScoreText.text = Score.ToString();

        gameSpeed = (float)Math.Pow(Time.timeSinceLevelLoad * 4, 0.7f) + 10f;
    }

    public void AddScore(int scoreToBeAdded)
    {
        Score += scoreToBeAdded;
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
        eventDownTime -= Time.deltaTime * gameSpeed/10;

        if (eventDownTime > 0)
        {
            return;
        }
        Debug.Log(Time.timeSinceLevelLoad);

        if (Random.Range(0, 100) > 30)
        {
            SpawnPlayerJumpEvent();
            return;
        }

        SpawnPlayerShootEvent();
    }

    public void SpawnPlayerJumpEvent()
    {
        GameObject playerEventObject = Instantiate(prefabJumpPlayerEvent, new Vector3(1000, 0, 0), Quaternion.identity);
        PlayerEvent playerEvent = playerEventObject.GetComponent<PlayerEvent>();

        _upcomingPlayerEvents.Add(playerEvent);
        eventDownTime = playerEvent.duration + Random.Range(minimumEventDowntime, maximumEventDowntime);
    }
    
    public void SpawnPlayerShootEvent()
    {
        GameObject playerEventObject = Instantiate(prefabShootPlayerEvent, new Vector3(1000, 0, 0), Quaternion.identity);
        PlayerEvent playerEvent = playerEventObject.GetComponent<PlayerEvent>();

        _upcomingPlayerEvents.Add(playerEvent);
        eventDownTime = playerEvent.duration + Random.Range(minimumEventDowntime, maximumEventDowntime);
    }

    public void SpawnJumpLevelEvent()
    {
        GameObject levelEventObject = Instantiate(prefabJumpLevelEvent, new Vector3(1000, 0, 0), Quaternion.identity);
        LevelEvent levelEvent = levelEventObject.GetComponent<LevelEvent>();

        _upcomingLevelEvents.Add(levelEvent);
    }

    public void SpawnShootLevelEvent()
    {
        GameObject levelEventObject = Instantiate(prefabShootLevelEvent, new Vector3(1000, 0, 0), Quaternion.identity);
        LevelEvent levelEvent = levelEventObject.GetComponent<LevelEvent>();

        _upcomingLevelEvents.Add(levelEvent);
    }

    
    public void SpawnProjectileLevelEvent()
    {
        GameObject levelEventObject = Instantiate(prefabProjectile, new Vector3(1000, 0, 0), Quaternion.identity);
        LevelEvent levelEvent = levelEventObject.GetComponent<LevelEvent>();

        _upcomingLevelEvents.Add(levelEvent);
    }

    public void RemoveLevelEvents(LevelEvent levelEvent)
    {
        _upcomingLevelEvents.Remove(levelEvent);
    }
}
