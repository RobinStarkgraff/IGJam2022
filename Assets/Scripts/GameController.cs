using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    private readonly List<PlayerEvent> _upcomingPlayerEvents = new List<PlayerEvent>();
    [SerializeField] private int gameSpeed = 3;
    public Sprite shape;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameObject newObject = Instantiate(new GameObject());
        PlayerEvent playerEvent = newObject.AddComponent<PlayerEvent>();
        _upcomingPlayerEvents.Add(playerEvent);
    }

    private void Update()
    {
        float relativeSpeed = gameSpeed * Time.deltaTime;

        foreach (PlayerEvent playerEvent in _upcomingPlayerEvents)
        {
            playerEvent.progress -= relativeSpeed;
        }
    }
}
