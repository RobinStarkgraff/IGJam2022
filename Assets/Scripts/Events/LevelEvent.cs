using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class LevelEvent : AbstractEvent
{
    protected Vector3 ownStartPoint = new Vector3(9, 0, 0);
    protected Vector3 ownEndPoint = new Vector3(-4, 0, 0);

    protected bool hasScored = false;

    protected abstract int pointsForEvent { get; }

    private void Awake()
    {
        startPoint = ownStartPoint;
        endPoint = ownEndPoint;
    }

    public override void UpdateProgress(float relativeSpeed)
    {
        progress -= relativeSpeed * 2;

        if (!hasScored)
        {
            CheckHasScored();
        }
    }

    protected void CheckHasScored()
    {
        if (progress <= 0)
        {
            hasScored = true;
            GameController.Instance.Score += pointsForEvent;
        }
    }
}
