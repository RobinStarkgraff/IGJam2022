using System;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public abstract class PlayerEvent : AbstractEvent
{
    private Vector3 ownStartPoint = new Vector3(4, 4.4f, 0);
    private Vector3 ownEndPoint = new Vector3(-4, 4.4f, 0);

    public float duration = 1.5f;

    private bool _executedAction = false;

    private void Awake()
    {
        startPoint = ownStartPoint;
        endPoint = ownEndPoint;
        transform.position = ownStartPoint;
    }

    public void Update()
    {
        if (!(transform.position.x <= endPoint.x) || _executedAction) return;

        ExecutePlayerAction();
        _executedAction = true;
    }

    protected abstract void ExecutePlayerAction();
}