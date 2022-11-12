using System;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public abstract class PlayerEvent : AbstractEvent
{
    private Vector3 ownStartPoint = new Vector3(4, 0, 0);
    private Vector3 ownEndPoint = new Vector3(-4, 0, 0);

    [DoNotSerialize] public new const int Progress = 100;

    public float duration = 1.5f;

    private bool _executedAction = false;

    private void Awake()
    {
        transform.position = new Vector3(0, 4.4f, 0);
        startPoint = ownStartPoint;
        endPoint = ownEndPoint;
    }

    public void Update()
    {
        if (!(transform.position.x <= endPoint.x) || _executedAction) return;

        ExecutePlayerAction();
        _executedAction = true;
    }

    protected abstract void ExecutePlayerAction();
}